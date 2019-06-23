using System;
using System.Linq;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public WordList SpellingList { get; private set; }

    private WordListProcessor processor;
    [SerializeField]
    private TMP_Text spellingListText;

    private void Awake()
    {
        processor = GetComponent<WordListProcessor>();
    }

    private void Start()
    {
        var id = RetrieveWordListID();
        SpellingList = new WordList(new string[]{ "Spelling", "Quest", "Default"});
        if (id > 0)
        {
            processor.LoadWordList(id, UpdateSpellingList);
        }
    }

    private int RetrieveWordListID()
    {
        var idFromURL = Application.absoluteURL?.Split('/').Last();
        
        return Int32.TryParse(idFromURL, out int result) ? result : -1; 
    }

    private void UpdateSpellingList(WordListModel wordStrings)
    {
        SpellingList = new WordList(wordStrings.words);
        spellingListText.SetText(wordStrings.title);
    }
}