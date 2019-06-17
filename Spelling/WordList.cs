using System.Collections.Generic;

public class WordList
{
    public List<Word> Words;

    public WordList(int id)
    {
        if (id == 0)
        {
            DefaultWordList();
        }
        
        // call API with id
        // parse JSON
        // store words in Words
    }

    private void DefaultWordList()
    {
        Words = new List<Word>
        {
            new Word("spelling"),
            new Word("quest"),
            new Word("default")
        };
    }
}
