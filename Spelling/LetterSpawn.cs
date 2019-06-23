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
    private ParticleSystem correctAnswerParticles;

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

    private void Start()
    {
        correctAnswerParticles = GetComponentInChildren<ParticleSystem>();
        var em = correctAnswerParticles.emission;
        em.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsCorrectAnswer)
        {
            var em = correctAnswerParticles.emission;
            em.enabled = true;
            StartCoroutine(ParticleTimer(1f));
            IsCorrectAnswer = false;
            answerFound.Raise();
        }
    }

    private IEnumerator ParticleTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        var em = correctAnswerParticles.emission;
        em.enabled = false;
    }
}
