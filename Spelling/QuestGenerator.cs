using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class QuestGenerator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text wordText;

    private Stack<Word> currentWordStack = new Stack<Word>();
    private Word currentWord;
    
    private string DisplayWord => currentWord.Letters.Aggregate("", (accum, next) => accum + (next.Missing ? '_' : next.Character));
    private bool HasDisplayWordChanged {get; set;} 

    private void Awake()
    {
        var id = RetrieveWordListID();
        var spellingList = new WordList(id);

        if (spellingList != null && spellingList.Words.Count > 0)
        {
            currentWordStack = ShuffleWordList(spellingList);
            currentWord = GetNextQuestWord();
        }
    }

    private void Start()
    {
        HasDisplayWordChanged = true;
        //TODO: spawn the missing letters
    }

    private void Update()
    {
        if (!currentWord.Letters.Any(l => l.Missing))
        {
            currentWord = GetNextQuestWord();
            HasDisplayWordChanged = true;
        }

        if (HasDisplayWordChanged)
        {
            wordText.SetText(DisplayWord);
            HasDisplayWordChanged = false;
        }
    }

    private Stack<Word> ShuffleWordList(WordList currentList)
    {
        var shuffler = new System.Random();
        var wordStack = new Stack<Word>();
        int rng;
        int numberOfWords = currentList.Words.Count;

        for (int i = numberOfWords - 1; i > 0; i--)
        {
            rng = shuffler.Next(0, i + 1);
            wordStack.Push(currentList.Words[rng]);
        }

        return wordStack;
    }

    private int RetrieveWordListID()
    {
        var idFromURL = Application.absoluteURL?.Split('/').Last();
        return Int32.TryParse(idFromURL, out int result) ? result : 0; 
    }

    private Word GetNextQuestWord()
    {
        var next = currentWordStack.Pop();

        var rng = new System.Random();
        var numOfMissingLetters = next.Letters.Length / 2;
        numOfMissingLetters = numOfMissingLetters < 2 ? 2 : numOfMissingLetters;

        while(numOfMissingLetters > 0)
        {
            next.Letters[rng.Next(0, next.Letters.Length)].Missing = true;
            numOfMissingLetters--;
        }

        return next;
    }
}