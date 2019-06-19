using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;


public class LetterSpawn : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;
    [SerializeField]
    private char _displayLetter;
    [SerializeField]
    private GameEvent answerFound;

    public char DisplayLetter 
    { 
        get => _displayLetter;
        set
        {
            _displayLetter = value;
            displayText.SetText(_displayLetter.ToString());
        } 
    }
    public bool IsCorrectAnswer {get; set;}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsCorrectAnswer)
        {
            //TODO: animate trigger
            IsCorrectAnswer = false;
            answerFound.Raise();
        }
    }
}
