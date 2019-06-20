using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class QuestGenerator : MonoBehaviour
{
    [SerializeField]
    private AudioManager audio;
    [SerializeField]
    private TMP_Text wordText;
    private Stack<Word> currentWordStack = new Stack<Word>();
    
    private string DisplayWord => CurrentWord.Letters.Aggregate("", (accum, next) => accum + (next.Missing ? '_' : next.Character));
    private bool HasDisplayWordChanged {get; set;}

    private List<string> Alphabet {get; set;}
    private LetterSpawn[] Spawners {get; set;} 
    
    public Word CurrentWord {get; private set;}
    private Letter CurrentLetter => CurrentWord.Letters.Where(l => l.Missing).First();
    private bool HasLettersMissing => CurrentWord.Letters.Any(x => x.Missing);

    private void Awake()
    {
        var id = RetrieveWordListID();
        var spellingList = new WordList(id);

        if (spellingList.Words.Count > 0)
        {
            currentWordStack = ShuffleWordList(spellingList);
            CurrentWord = GetNextQuestWord();
        }

        Alphabet = Enumerable.Range('a', 26)
                            .Select(x => Convert.ToChar(x)
                                                .ToString()
                                                .ToUpper())
                            .ToList();
    }

    private void Start()
    {
        Spawners = GetComponentsInChildren<LetterSpawn>();
        SpawnLetters();
    }

    private void Update()
    {
        if (HasDisplayWordChanged)
        {
            wordText.SetText(DisplayWord);
            HasDisplayWordChanged = false;
        }
    }

    public void CorrectAnswerFound()
    {
        audio.Play("Correct");
        CurrentLetter.Missing = false;
        // Need next letter in current word
        if (HasLettersMissing)
        {
            SpawnLetters();
        }
        // Need next word and letter
        else if (currentWordStack.Count > 0)
        {
            audio.Play("WordComplete");
            CurrentWord = GetNextQuestWord();
            SpawnLetters();
        }
        // Game Over
        else
        {
            HasDisplayWordChanged = true;

            //TODO: Game Over Event Triggered
        }
    }

    private Stack<Word> ShuffleWordList(WordList currentList)
    {
        var shuffler = new System.Random();
        var wordStack = new Stack<Word>();
        int rng;
        int numberOfWords = currentList.Words.Count;

        for (int i = numberOfWords; i > 0; i--)
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

    private void SpawnLetters()
    {
        var rng = new System.Random();

        foreach (var spawner in Spawners)
        {
            spawner.DisplayLetter = Alphabet.Where(x => x.First() != CurrentLetter.Character)
                                            .ElementAt(rng.Next(0, Alphabet.Count - 1))
                                            .First();
            spawner.IsCorrectAnswer = false;
        }

        var index = rng.Next(0,Spawners.Length);
        Spawners[index].DisplayLetter = CurrentLetter.Character;
        Spawners[index].IsCorrectAnswer = true;

        HasDisplayWordChanged = true;
    }
}