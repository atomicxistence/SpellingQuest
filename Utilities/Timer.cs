using UnityEngine;
using TMPro;
using System.Text;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private TMP_Text finalTimeText;

    private string finalTimeElapsed;
    private bool isTimerRunning;
    private float seconds;

    public float Minutes { get; private set;}
    public float Seconds
    {
        get => seconds;
        set
        {
            if (value > 59)
            {
                seconds = 0;
                Minutes++;
            }
            else
            {
                seconds = value;
            }
        }
    } 

    private void Start()
    {
        StartTimer();
    }
    
    private void FixedUpdate()
    {
        if (isTimerRunning)
        {
            Seconds += Time.deltaTime;
            var timeElapsed = FormatTimeToString();
            timerText.SetText(timeElapsed);
        }
    }

    private StringBuilder FormatTimeToString()
    {
        var result = new StringBuilder();

        return result.Append(string.Format("{0:00}", Minutes))
                    .Append(':')
                    .Append(string.Format("{0:00}", Seconds));
    }

    private void StartTimer()
    {
        isTimerRunning = true;
        Minutes = 0;
        Seconds = 0;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        finalTimeElapsed = FormatTimeToString().ToString();
        timerText.SetText("");
        finalTimeText.SetText(finalTimeElapsed);
    }
}