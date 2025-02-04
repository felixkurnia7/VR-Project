using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using HuggingFace.API;
using System;

public class SpeechRecognition : MonoBehaviour
{

    public Action<string> CheckWMP;
    public Action StartTimer;
    public Action StopTimer;
    public Action<float[]> CheckVolume;

    [SerializeField] private Button startButton;
    [SerializeField] private Button stopButton;
//[SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int bufferSize;
    [SerializeField] private StringValue textSO;
    [SerializeField] private int sampleSize;

    private AudioClip clip;
    private byte[] bytes;
    private float[] samples;

    private void Start()
    {
        ResetText();
        //startButton.onClick.AddListener(StartRecording);
        //stopButton.onClick.AddListener(StopRecording);
        //stopButton.interactable = false;
    }

    private void Update()
    {
        //if (recording && Microphone.GetPosition(null) >= clip.samples)
        //{
        //    Debug.Log("Iterasi");
        //}
        //if (recording)
        //{
        //    CheckVolume(samples);
        //}
        //if (recording)
        //{
        //    float elapsedTime = Time.time - recordingStartTime;
        //    Debug.Log("Time: " + elapsedTime);
        //    if (elapsedTime >= 10)
        //    {
        //        var position = Microphone.GetPosition(null);
        //        int offset = (position - bufferSize) % clip.samples;
        //        Microphone.End(null);
        //        samples = new float[clip.samples * clip.channels];
        //        //clip.GetData(samples, 0);
        //        try
        //        {
        //            clip.GetData(samples, offset);
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.LogError($"Error getting audio data: {ex.Message}");
        //        }
        //        //SaveWavFile(savePath, clip);
        //        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        //        SendToASR(bytes);
        //    }
        //}
    }

    public void ResetText()
    {
        textSO.ResetText();
    }

    public void StartRecording()
    {
        //text.color = Color.white;
        //text.text = "Recording...";
        startButton.interactable = false;
        stopButton.interactable = true;
        clip = Microphone.Start(null, true, 10, 44100);
        //recording = true;
        //recordingStartTime = Time.time;
        StartTimer?.Invoke();
    }

    public void StopRecording()
    {
        StopTimer?.Invoke();
        var position = Microphone.GetPosition(null);
        int offset = (position - bufferSize) % clip.samples;
        Microphone.End(null);
        samples = new float[clip.samples * clip.channels];
        //clip.GetData(samples, 0);
        try
        {
            clip.GetData(samples, offset);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error getting audio data: {ex.Message}");
        }
        //SaveWavFile(savePath, clip);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        CheckVolume(samples);
        //recording = false;
        Debug.Log("Encoding...");
        File.WriteAllBytes(Application.dataPath + "/test.wav", bytes);
        

        SendRecording();

    }

    private void SendRecording()
    {
        //text.color = Color.yellow;
        stopButton.interactable = false;
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
            Debug.Log(response);
            //textSO.text += response;
            textSO.text += " " + response;
            //text.color = Color.white;
            //text.text = textSO.text;
            startButton.interactable = true;
            CheckWMP?.Invoke(response);
        }, error => {
            Debug.Log(error);
            startButton.interactable = true;
        });
    }

    //private void SendToASR(byte[] bytes)
    //{
    //    HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
    //        Debug.Log(response);
    //        textSO.text += response;
    //        text.color = Color.white;
    //        text.text = response;
    //        startButton.interactable = true;
    //        CheckWMP?.Invoke(response);
    //    }, error => {
    //        text.color = Color.red;
    //        text.text = error;
    //        startButton.interactable = true;
    //    });
    //}

    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using var memoryStream = new MemoryStream(44 + samples.Length * 2);
        using (BinaryWriter writer = new(memoryStream))
        {
            writer.Write("RIFF".ToCharArray());
            writer.Write(36 + samples.Length * 2);
            writer.Write("WAVE".ToCharArray());
            writer.Write("fmt ".ToCharArray());
            writer.Write(16);
            writer.Write((ushort)1);
            writer.Write((ushort)channels);
            writer.Write(frequency);
            writer.Write(frequency * channels * 2);
            writer.Write((ushort)(channels * 2));
            writer.Write((ushort)16);
            writer.Write("data".ToCharArray());
            writer.Write(samples.Length * 2);

            foreach (var sample in samples)
            {
                writer.Write((short)(sample * short.MaxValue));
            }
        }
        return memoryStream.ToArray();
    }

    //private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    //{
    //    using var memoryStream = new MemoryStream();
    //    using (var writer = new BinaryWriter(memoryStream))
    //    {
    //        int bytesPerSample = 2; // 16-bit samples
    //        int sampleCount = samples.Length;

    //        // Write WAV header
    //        writer.Write("RIFF".ToCharArray()); // ChunkID
    //        writer.Write(36 + sampleCount * bytesPerSample); // ChunkSize
    //        writer.Write("WAVE".ToCharArray()); // Format

    //        writer.Write("fmt ".ToCharArray()); // Subchunk1ID
    //        writer.Write(16); // Subchunk1Size (16 for PCM)
    //        writer.Write((ushort)1); // AudioFormat (1 for PCM)
    //        writer.Write((ushort)channels); // NumChannels
    //        writer.Write(frequency); // SampleRate
    //        writer.Write(frequency * channels * bytesPerSample); // ByteRate
    //        writer.Write((ushort)(channels * bytesPerSample)); // BlockAlign
    //        writer.Write((ushort)(bytesPerSample * 8)); // BitsPerSample

    //        writer.Write("data".ToCharArray()); // Subchunk2ID
    //        writer.Write(sampleCount * bytesPerSample); // Subchunk2Size

    //        // Write sample data
    //        foreach (var sample in samples)
    //        {
    //            short intSample = (short)(sample * short.MaxValue);
    //            writer.Write(intSample);
    //        }
    //    }
    //    return memoryStream.ToArray();
    //}

    //void SaveWavFile(string filename, AudioClip clip)
    //{
    //    var samples = new float[clip.samples * clip.channels];
    //    clip.GetData(samples, 0);

    //    using (var fileStream = CreateEmpty(filename))
    //    {
    //        WriteHeader(fileStream, clip);

    //        var bytes = ConvertAudioToBytes(samples);
    //        fileStream.Write(bytes, 0, bytes.Length);
    //    }

    //    Debug.Log("File saved to: " + filename);
    //}

    //FileStream CreateEmpty(string filename)
    //{
    //    var fileStream = new FileStream(filename, FileMode.Create);
    //    return fileStream;
    //}

    //void WriteHeader(FileStream fileStream, AudioClip clip)
    //{
    //    var fileSize = 36 + clip.samples * clip.channels * 2;
    //    var sampleRate = clip.frequency;

    //    WriteString(fileStream, "RIFF");
    //    WriteInt(fileStream, fileSize);
    //    WriteString(fileStream, "WAVE");
    //    WriteString(fileStream, "fmt ");
    //    WriteInt(fileStream, 16);
    //    WriteShort(fileStream, 1);
    //    WriteShort(fileStream, (short)clip.channels);
    //    WriteInt(fileStream, sampleRate);
    //    WriteInt(fileStream, sampleRate * clip.channels * 2);
    //    WriteShort(fileStream, (short)(clip.channels * 2));
    //    WriteShort(fileStream, 16);
    //    WriteString(fileStream, "data");
    //    WriteInt(fileStream, clip.samples * clip.channels * 2);
    //}

    //byte[] ConvertAudioToBytes(float[] audioData)
    //{
    //    var bytes = new byte[audioData.Length * 2];
    //    int rescaleFactor = 32767; // to convert float to Int16

    //    for (int i = 0; i < audioData.Length; i++)
    //    {
    //        short sample = (short)(audioData[i] * rescaleFactor);
    //        bytes[i * 2] = (byte)(sample & 0xff);
    //        bytes[i * 2 + 1] = (byte)((sample >> 8) & 0xff);
    //    }

    //    return bytes;
    //}

    //void WriteString(FileStream fileStream, string value)
    //{
    //    var bytes = System.Text.Encoding.ASCII.GetBytes(value);
    //    fileStream.Write(bytes, 0, bytes.Length);
    //}

    //void WriteInt(FileStream fileStream, int value)
    //{
    //    var bytes = System.BitConverter.GetBytes(value);
    //    fileStream.Write(bytes, 0, bytes.Length);
    //}

    //void WriteShort(FileStream fileStream, short value)
    //{
    //    var bytes = System.BitConverter.GetBytes(value);
    //    fileStream.Write(bytes, 0, bytes.Length);
    //}
}
