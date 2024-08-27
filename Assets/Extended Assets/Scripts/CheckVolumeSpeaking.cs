using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class CheckVolumeSpeaking : MonoBehaviour
{
    //[SerializeField] private Button startButton;
    //[SerializeField] private Button stopButton;
    //[SerializeField] private TextMeshProUGUI text;
    //[SerializeField] private int sampleSize;

    //private AudioClip clip;
    //private bool recording;

    //private void Start()
    //{
    //    startButton.onClick.AddListener(StartRecording);
    //    stopButton.onClick.AddListener(StopRecording);
    //    stopButton.interactable = false;
    //}

    //private void Update()
    //{
    //    if (recording && Microphone.GetPosition(null) >= clip.samples)
    //    {
    //        StopRecording();
    //    }
    //}

    //private void StartRecording()
    //{
    //    text.color = Color.white;
    //    text.text = "Recording...";
    //    startButton.interactable = false;
    //    stopButton.interactable = true;
    //    clip = Microphone.Start(null, false, 10, 44100);
    //    recording = true;
    //}

    //private void StopRecording()
    //{
    //    var position = Microphone.GetPosition(null);
    //    Microphone.End(null);
    //    var samples = new float[sampleSize];
    //    clip.GetData(samples, position - sampleSize);
    //    recording = false;

    //    float volume = GetRMS(samples); // Calculate the volume (RMS value)

    //    // Optionally, use the volume for something, e.g., display it in the UI
    //    Debug.Log("Volume: " + volume);

    //    startButton.interactable = true;
    //    stopButton.interactable = false;
    //}

    //private float GetRMS(float[] samples)
    //{
    //    float sum = 0f;

    //    // Calculate the squared sum
    //    for (int i = 0; i < samples.Length; i++)
    //    {
    //        sum += samples[i] * samples[i];
    //    }

    //    // Calculate the mean
    //    float mean = sum / samples.Length;

    //    // Calculate the square root of the mean
    //    return Mathf.Sqrt(mean);
    //}

    public int sampleRate = 44100; // Sample rate of the audio
    public int sampleSize = 1024;  // Size of the audio sample
    private AudioClip microphoneClip;
    private float[] samples;

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            string micName = Microphone.devices[0]; // Select the first microphone
            microphoneClip = Microphone.Start(micName, true, 1, sampleRate);
            samples = new float[sampleSize];
            Debug.Log("Microphone initialized: " + micName);
            Debug.Log("Clip length: " + microphoneClip.length);
        }
        else
        {
            Debug.LogError("No microphone detected.");
        }
    }

    void Update()
    {
        if (Microphone.IsRecording(null))
        {
            int position = Microphone.GetPosition(null);
            if (position > sampleSize)
            {
                microphoneClip.GetData(samples, position - sampleSize);
                float rmsValue = GetRMS(samples); // Calculate the RMS value

                // Convert RMS to dB
                float dBValue = RMSToDecibels(rmsValue);

                // Output the dB value
                Debug.Log("Volume (dB): " + dBValue);
            }
        }
    }

    // Calculate the RMS (Root Mean Square) value of the audio samples
    private float GetRMS(float[] samples)
    {
        float sum = 0f;

        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }

        float mean = sum / samples.Length;
        return Mathf.Sqrt(mean);
    }

    // Convert RMS value to decibels
    private float RMSToDecibels(float rmsValue)
    {
        if (rmsValue < Mathf.Epsilon) // Avoid log of zero or very small values
        {
            return -80f; // A very low dB value to represent silence
        }

        // Convert RMS value to dB
        float dB = 20f * Mathf.Log10(rmsValue);
        return Mathf.Clamp(dB, -80f, 0f); // Clamping to avoid overly large negative values
    }
}
