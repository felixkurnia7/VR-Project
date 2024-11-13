using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] UserData userData;
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] List<UserData> AllUserData = new List<UserData>();

    private IDataService DataService = new JSONDataService();
    private long saveTime;
    private long loadTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SerializeJson()
    {
        long startTime = TimeSpan.TicksPerMillisecond;
        if (DataService.SaveData("/save-data", userData, true))
        {
            saveTime = TimeSpan.TicksPerMillisecond - startTime;
            Debug.Log($"Save Time:  {(saveTime / 1000f):N4}ms");
        }
        else
        {
            Debug.LogError("Could not save file! Show something on the UI about it!");
        }
    }

    public void LoadData()
    {
        long startTime = TimeSpan.TicksPerMillisecond;
        try
        {
            UserData data = DataService.LoadData<UserData>("/save-data", true);
            loadTime = TimeSpan.TicksPerMillisecond - startTime;
            inputText.text = "Loaded from file: \r\n" + JsonConvert.SerializeObject(data, Formatting.Indented);
            Debug.Log($"Load Time:  {(loadTime / 1000f):N4}ms");
        }
        catch (Exception e)
        {
            Debug.LogError($"Could not read file! Show somwthing on the UI here!");
        }
    }

    public void LoadAllData()
    {
        AllUserData = DataService.LoadAllUserData<UserData>(true);
        
        foreach (UserData data in AllUserData)
        {
            //inputText.text += "Loaded from file: \r\n" + JsonConvert.SerializeObject(data, Formatting.Indented);
            inputText.text += "Loaded from file: \r\n";

            if (data.textSpeechRecognition != null)
            {
                inputText.text += $"{data.textSpeechRecognition.text}";
            }
        }
    }
}
