public class Word
{
    public Letter[] Letters { get; private set; }

    public Word(string word)
    {
        var capatilizedWord = word.ToUpper();
        char[] wordArray = capatilizedWord.ToCharArray();

        CreateLetterCollection(wordArray);
    }

    private void CreateLetterCollection(char[] word)
    {
        Letters = new Letter[word.Length];

        for (int i = 0; i < word.Length; i++)
        {
            Letters[i].Character = word[0];
            Letters[i].Type = LetterTypeEvaluation(word[0]);
            Letters[i].Missing = false;
        }
    }

    private LetterType LetterTypeEvaluation(char letter)
    {
        switch (letter)
        {
            case 'A':
            case 'E':
            case 'I':
            case 'O':
            case 'U':
                return LetterType.Vowel;
            case 'B':
            case 'C':
            case 'D':
            case 'F':
            case 'G':
            case 'H':
            case 'J':
            case 'K':
            case 'L':
            case 'M':
            case 'N':
            case 'P':
            case 'Q':
            case 'R':
            case 'S':
            case 'T':
            case 'V':
            case 'W':
            case 'X':
            case 'Y':
            case 'Z':
                return LetterType.Consonant;
            default:
                return LetterType.Consonant;
        }
    }
}
