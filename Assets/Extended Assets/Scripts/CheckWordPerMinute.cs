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
    private int wordCount = 0;
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
        int newWordCount = CountWords(responseText);
        Debug.Log(newWordCount);
        // Update word count
        wordCount += newWordCount;
        Debug.Log(wordCount);

        if (time.value < 60)
        {
            wordsPerMinute = wordCount;
        }
        else
        {
            // Calculate WPM
            float durationInMinutes = time.value / 60f; // Convert seconds to minutes
            wordsPerMinute = wordCount / durationInMinutes;
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
