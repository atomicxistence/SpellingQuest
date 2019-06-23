using System.Linq;
using System.Collections.Generic;

public class WordList
{
    public List<Word> Words;

    public WordList(string[] wordStrings)
    {
        Words = wordStrings.Select(x => new Word(x)).ToList();
    }
}
