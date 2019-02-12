public class Word
{
    public Letter[] Letters { get; private set; }

    private char[] wordArray;

    public Word(string word)
    {
        var capatilizedWord = word.ToUpper();
        wordArray = capatilizedWord.ToCharArray();

        CreateLetterCollection();
    }

    private void CreateLetterCollection()
    {
        Letters = new Letter[wordArray.Length];

        for (int i = 0; i < wordArray.Length; i++)
        {
            Letters[i].LetterValue = wordArray[0];
            Letters[i].Type = LetterTypeEvaluation(wordArray[0]);
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
