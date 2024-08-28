using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWordPerMinute : MonoBehaviour
{
    //private const string ASR_API_URL = "YOUR_HUGGING_FACE_API_URL"; // Replace with your Hugging Face ASR API URL
    //private const string ASR_API_KEY = "YOUR_HUGGING_FACE_API_KEY"; // Replace with your Hugging Face API Key

    private float speechStartTime;
    private float speechEndTime;
    private bool isSpeaking = false;
    private int wordCount = 0;

    // Update is called once per frame
    void Update()
    {
        // Example of detecting start and stop of speech (you need actual implementation)
        if (IsUserSpeaking())
        {
            if (!isSpeaking)
            {
                isSpeaking = true;
                speechStartTime = Time.time;
            }
        }
        else
        {
            if (isSpeaking)
            {
                isSpeaking = false;
                speechEndTime = Time.time;
                AnalyzeSpeechSegment();
            }
        }
    }

    private bool IsUserSpeaking()
    {
        // Implement your method to determine if the user is speaking
        // For example, you might use a microphone input or ASR status
        return false;
    }

    private void AnalyzeSpeechSegment()
    {
        if (speechEndTime > speechStartTime)
        {
            float durationInSeconds = speechEndTime - speechStartTime;
            float wordsPerMinute = CalculateWPM(wordCount, durationInSeconds);

            Debug.Log($"Speech Duration: {durationInSeconds} seconds");
            Debug.Log($"Words Per Minute: {wordsPerMinute}");
        }

        // Reset for the next segment
        wordCount = 0;
        speechStartTime = 0;
        speechEndTime = 0;
    }

    private float CalculateWPM(int wordCount, float durationInSeconds)
    {
        if (durationInSeconds <= 0)
            return 0;

        float durationInMinutes = durationInSeconds / 60f;
        return wordCount / durationInMinutes;
    }

    // Example method to call the ASR API
    //public IEnumerator GetTranscriptFromAudio(byte[] audioData)
    //{
    //    using (UnityWebRequest request = new UnityWebRequest(ASR_API_URL, "POST"))
    //    {
    //        request.uploadHandler = new UploadHandlerRaw(audioData);
    //        request.downloadHandler = new DownloadHandlerBuffer();
    //        request.SetRequestHeader("Authorization", $"Bearer {ASR_API_KEY}");
    //        request.SetRequestHeader("Content-Type", "audio/wav"); // Adjust content type if needed

    //        yield return request.SendWebRequest();

    //        if (request.result == UnityWebRequest.Result.Success)
    //        {
    //            string responseText = request.downloadHandler.text;
    //            string transcript = ExtractTranscriptFromResponse(responseText);
    //            wordCount += CountWords(transcript);
    //            Debug.Log($"Transcript: {transcript}");
    //        }
    //        else
    //        {
    //            Debug.LogError($"Error: {request.error}");
    //        }
    //    }
    //}

    //private string ExtractTranscriptFromResponse(string responseText)
    //{
    //    // Implement response parsing logic
    //    // Example: Extracting transcript from JSON response
    //    return Regex.Match(responseText, @"(?<=""text":")[^""]*").Value;
    //}

    private int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        return text.Split(new[] { ' ', '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
