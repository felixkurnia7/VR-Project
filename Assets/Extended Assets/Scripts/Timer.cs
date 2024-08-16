using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private bool isCountdown;
    [SerializeField]
    private float time;
    [SerializeField]
    private bool isRunning;

    TimeSpan timespan;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (isCountdown)
                time -= Time.deltaTime;
            else
                time += Time.deltaTime;

            if (isCountdown && time < 0)
            {
                time = 0;
                isRunning = false;
            }

            timespan = TimeSpan.FromSeconds(time);

            timerText.text = String.Format("{0:D2}:{1:D2}:{2:D2}", timespan.Hours, timespan.Minutes, timespan.Seconds);
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
