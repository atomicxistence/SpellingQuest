using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "WordList", menuName = "SpellingQuest/WordList")]
public class WordList : ScriptableObject
{
    public List<Word> Words; 
}
