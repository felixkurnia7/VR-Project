using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class CheckVolumeSpeaking : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private TextMeshProUGUI text;
    public string microphoneName; // The name of the microphone
    public int sampleRate = 44100; // Sample rate for the microphone
    public int bufferSize = 256; // Buffer size for audio samples
    private AudioClip audioClip;
    private float[] audioSamples;
    private bool isMicrophoneAvailable;
    private bool isRecording;

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            // Use the first available microphone
            microphoneName = Microphone.devices[0];
            audioClip = Microphone.Start(microphoneName, true, 1, sampleRate);
            audioSamples = new float[bufferSize];
            isMicrophoneAvailable = true;
        }
        else
        {
            Debug.LogError("No microphone detected");
            isMicrophoneAvailable = false;
        }
        startButton.onClick.AddListener(StartVolumeRecording);
        stopButton.onClick.AddListener(StopVolumeRecording);
        stopButton.interactable = false;
    }

    void Update()
    {
        if (isMicrophoneAvailable && isRecording)
        {
            int micPosition = Microphone.GetPosition(microphoneName);

            // Ensure that we are accessing valid data
            if (micPosition >= bufferSize)
            {
                // Correct the offset to avoid negative values
                int offset = (micPosition - bufferSize) % audioClip.samples;

                // Get the audio data
                audioClip.GetData(audioSamples, offset);
                float volume = CalculateVolume(audioSamples);
                text.text = volume.ToString();
                Debug.Log($"Volume: {volume}");
            }
        }
    }

    void StartVolumeRecording()
    {
        startButton.interactable = false;
        stopButton.interactable = true;
        isRecording = true;
    }

    void StopVolumeRecording()
    {
        isRecording = false;
        startButton.interactable = true;
        stopButton.interactable = false;
    }

    float CalculateVolume(float[] samples)
    {
        float sum = 0.0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i]; // Square of the sample
        }
        float rms = Mathf.Sqrt(sum / samples.Length); // Root Mean Square
        return rms * 1000.0f; // Scale for better visualization
    }

    void OnApplicationQuit()
    {
        if (isMicrophoneAvailable)
        {
            Microphone.End(microphoneName);
        }
    }
}
