public class Word
{
    public Letter[] Letters { get; private set; }

    public Word(string word)
    {
        var wordArray = word.ToUpper().ToCharArray();
        Letters = new Letter[wordArray.Length];
        
        for (int i = 0; i < wordArray.Length; i++)
        {
            Letters[i] = new Letter
            {
                Character = wordArray[i],
                Missing = false
            };
        }
    }
}
