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
    private TextMeshProUGUI text;
    [SerializeField]
    private FloatValue time;
    [SerializeField]
    private IntValue WPM;
    private float wordsPerMinute;

    private void Awake()
    {
        speechRecognition.CheckWMP += CountWPM;
    }

    private void OnDestroy()
    {
        speechRecognition.CheckWMP -= CountWPM;
    }

    void CountWPM(string responseText)
    {
        WPM.ResetValue(); ;
        int newWordCount = CountWords(responseText);
        Debug.Log(newWordCount);
        // Update word count
        WPM.value += newWordCount;
        Debug.Log(WPM.value);

        if (time.value < 60)
        {
            wordsPerMinute = WPM.value;
        }
        else
        {
            // Calculate WPM
            float durationInMinutes = time.value / 60f; // Convert seconds to minutes
            wordsPerMinute = WPM.value / durationInMinutes;
        }

        text.text = wordsPerMinute.ToString();
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
