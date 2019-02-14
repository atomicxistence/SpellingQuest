using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    [SerializeField]
    private WordList currentList;

    private Queue<Word> randomizedWordQueue = new Queue<Word>();
    private Word currentWord;

    private void Awake()
    {
        if (currentList != null && currentList.Words.Count > 0)
        {
            ShuffleWordList();

            foreach (var word in currentList.Words)
            {
                randomizedWordQueue.Enqueue(word);
            }

            //TODO: randomly set letters in currentWord to missing
        }
    }

    private void Start()
    {
        //TODO: display the current word and spawn the missing letters
    }

    private void ShuffleWordList()
    {
        var shuffler = new System.Random();
        Word temp;
        int rng;
        int numberOfWords = currentList.Words.Count;

        for (int i = numberOfWords - 1; i > 0; i--)
        {
            rng = shuffler.Next(0, i + 1);
            temp = currentList.Words[i];
            currentList.Words[i] = currentList.Words[rng];
            currentList.Words[rng] = temp;
        }
    }
}
