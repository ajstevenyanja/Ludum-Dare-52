using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

// shows time left in [minutes : seconds]

public class MinutesTimer : MonoBehaviour
{
    public float timeLimitMinutes = 2f;
    [SerializeField] TMP_Text timerText;
    [SerializeField] UnityEvent OnWin;
    [SerializeField] UnityEvent OnLoss;

    float timeLeftSeconds;
    bool running = true;

    private void Awake()
    {
        timeLeftSeconds = timeLimitMinutes * 60f;

        // if rounded value, then remove 1 second
        if (timeLeftSeconds % 60 == 0)
        {
            timeLeftSeconds -= 1f;
        }
    }

    private void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if (!running)
        {
            return;
        }

        timeLeftSeconds -= Time.deltaTime;

        // string.ToString will round minutes float to a same or one upper integer
        // ex: 0.5.ToString("00") will return "1";
        // ex: 0.4.ToString("00") will return "0";
        // which can cause problem. example : 00:59 will be displayed as 01:59
        // so we Mathf.Floor() to make sure minutes is always rounded to the smallest integer
        float minutes = Mathf.Floor(timeLeftSeconds / 60f);
        float seconds = timeLeftSeconds % 60f;  // use mod to ceil value to 60, any number % modulo = modulo or less number

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (timeLeftSeconds < 0)
        {
            StopTimeOnLoss();
        }
    }

    public void StopTimeOnLoss()
    {
        timerText.text = "-- : --";
        running = false;
        OnLoss.Invoke();
    }

    public void StopTimeOnWin()
    {
        running = false;
        OnWin.Invoke();
    }
}
