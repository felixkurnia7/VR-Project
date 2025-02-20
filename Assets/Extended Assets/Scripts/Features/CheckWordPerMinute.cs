using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using TMPro;

public class CheckWordPerMinute : MonoBehaviour
{
    [SerializeField]
    private SpeechRecognition speechRecognition;
    [SerializeField]
    private WordPerMinuteUI wpmUI;
    [SerializeField]
    private FloatValue time;
    [SerializeField]
    private FloatValue WPM;
    public float words;

    private void Awake()
    {
        speechRecognition.CheckWMP += CountWPM;
    }

    private void Start()
    {
        ResetWPM();
    }

    private void OnDestroy()
    {
        speechRecognition.CheckWMP -= CountWPM;
    }

    private void ResetWPM()
    {
        WPM.ResetValue();
        time.ResetValue();
    }

    void CountWPM(string responseText)
    {
        //WPM.ResetValue();
        int newWordCount = CountWords(responseText);
        Debug.Log(newWordCount);
        // Update word count
        //WPM.value += newWordCount;
        words = newWordCount;

        if (time.value < 60)
        {
            WPM.value += words;
            WPM.listValues.Add(words);
        }
        else
        {
            // Calculate WPM
            float durationInMinutes = time.value / 60f; // Convert seconds to minutes
            WPM.listValues.Add(words);
            WPM.value += words / durationInMinutes;
        }
    }

    int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        // Split text by whitespace and count the words
        string[] words = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}
