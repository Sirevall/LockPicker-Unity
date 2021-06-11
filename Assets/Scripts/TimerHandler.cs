using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] float timerTime;
    [SerializeField] Text timerText;

    private bool timerStop;
    private bool timerStart;
    private float timeLeft;

    private void Start()
    {
        ResetTimer();
    }
    private void Update()
    {
        TimerWork();
    }
    public bool StopTimer
    {
        get
        {
            return timerStop;
        }
        set
        {
            timerStop = value;
        }
    }
    public float TimeLeft
    {
        get
        {
            return timeLeft;
        }
    }
    public void StartTimer()
    {
        timerStart = true;
    }
    public void ResetTimer()
    {
        timerStop = false;
        timerStart = false;
        timeLeft = timerTime;
    }
    private void TimerWork()
    {
        if (timerStart == true && timeLeft > 0f)
        {
            CalculateTime();
            DisplayTime();
        }
        else if (timeLeft <= 0f)
        {
            timerStop = true;
        }
    }
    private void CalculateTime()
    {
        timeLeft -= Time.deltaTime;
    }
    private void DisplayTime()
    {
        timerText.text = Math.Ceiling(timeLeft).ToString();
    }
}
