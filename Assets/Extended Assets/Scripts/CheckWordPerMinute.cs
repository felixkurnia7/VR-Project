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

    public string apiUrl = "https://api-inference.huggingface.co/models/your-model"; // Replace with your model's URL
    public string apiKey = "your-api-key"; // Replace with your Hugging Face API key

    private float speechStartTime;
    private float speechEndTime;
    private int wordCount = 0;
    private bool isSpeaking = false;

    private void Awake()
    {
        speechRecognition.CheckWMP += CountWPM;
    }

    void Update()
    {
        // Example check to start and stop speech recording
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRecording();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopRecording();
        }
    }

    private void OnDestroy()
    {
        speechRecognition.CheckWMP -= CountWPM;
    }

    void CountWPM(string responseText, float time)
    {
        int newWordCount = CountWords(responseText);

        // Update word count
        wordCount += newWordCount;

        // Calculate WPM
        float durationInMinutes = time / 60f;
        float wordsPerMinute = wordCount / durationInMinutes;

        text.text = wordsPerMinute.ToString();
    }

    void StartRecording()
    {
        // Implement your speech recording logic here
        // For example, start recording audio or send it to ASR
        speechStartTime = Time.time;
        isSpeaking = true;
    }

    void StopRecording()
    {
        // Implement your logic to stop recording and get transcription
        // For example, stop recording audio or send the recorded audio to ASR
        speechEndTime = Time.time;
        isSpeaking = false;

        // Simulate getting transcription result
        StartCoroutine(GetTranscriptionResult());
    }

    IEnumerator GetTranscriptionResult()
    {
        // Simulate API request
        using UnityWebRequest www = UnityWebRequest.Post(apiUrl, "");
        www.SetRequestHeader("Authorization", "Bearer " + apiKey);
        // Add audio file or parameters to the request here

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            // Parse the response to get transcription
            string responseText = www.downloadHandler.text;
            int newWordCount = CountWords(responseText);

            // Update word count
            wordCount += newWordCount;

            // Calculate WPM
            float durationInMinutes = (speechEndTime - speechStartTime) / 60f;
            float wordsPerMinute = wordCount / durationInMinutes;

            Debug.Log($"Words per minute: {wordsPerMinute}");
        }
        else
        {
            Debug.LogError("Error: " + www.error);
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
