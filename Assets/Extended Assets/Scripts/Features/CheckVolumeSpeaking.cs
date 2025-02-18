using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class CheckVolumeSpeaking : MonoBehaviour
{
    [SerializeField] private SpeechRecognition speechRecognition;
    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private FloatValue volume;
    [SerializeField] private int numberOfVolume = 0;
    public string microphoneName; // The name of the microphone
    public int sampleRate = 44100; // Sample rate for the microphone
    public int bufferSize = 256; // Buffer size for audio samples

    void Start()
    {
        //speechRecognition.StartCheckVolume += StartVolumeRecording;
        //speechRecognition.StopCheckVolume += StopVolumeRecording;
        ResetVolumeSpeaking();
        speechRecognition.CheckVolume += CheckVolume;
    }

    private void OnDestroy()
    {
        //speechRecognition.StartCheckVolume -= StartVolumeRecording;
        //speechRecognition.StopCheckVolume -= StopVolumeRecording;
        speechRecognition.CheckVolume -= CheckVolume;
    }

    private void ResetVolumeSpeaking()
    {
        volume.ResetValue();
        numberOfVolume = 0;
    }

    void CheckVolume(float[] samples)
    {
        float currentVolume = CalculateVolume(samples);
        numberOfVolume++;

        volume.listValues.Add(currentVolume);
        volume.value = (volume.value + currentVolume) / numberOfVolume;

        // Accumulate volume data
        //totalVolume += currentVolume;
        //volumeSampleCount++;
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
}
