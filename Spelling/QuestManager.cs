using System;
using System.Linq;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public WordList SpellingList { get; private set; }
    public static QuestManager SharedInstance { get; private set;}

    [SerializeField]
    private TMP_Text spellingListText;

    private void Awake()
    {
        #region Singleton
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else if (SharedInstance != this)
        {
            Destroy(gameObject);
        }
        #endregion

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        var id = RetrieveWordListID();
        SpellingList = new WordList(new string[]{ "Spelling", "Quest", "Default"});
        if (id > 0)
        {
            SubmitIDtoAPIProcessor(id);
        }
    }
    
    public void SubmitIDtoAPIProcessor(string id)
    {
        SubmitIDtoAPIProcessor(Convert.ToInt32(id));
    }

    private void SubmitIDtoAPIProcessor(int id)
    {
        WordListProcessor.SharedInstance.LoadWordList(id, UpdateSpellingList);
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