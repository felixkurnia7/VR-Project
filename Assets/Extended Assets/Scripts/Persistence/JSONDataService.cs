using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class JSONDataService : IDataService
{
    public bool SaveData<T>(string RelativePath, T Data, bool Encrypted)
    {
        string uniqueID = System.Guid.NewGuid().ToString();
        string path = Application.persistentDataPath + RelativePath + uniqueID + ".json";

        try
        {
            if (File.Exists(path))
            {
                Debug.Log("Data exists. Deleting old file and writing a new one!");
                File.Delete(path);
            }
            else
            {
                Debug.Log("Writing file for the first time!");
            }
            using FileStream stream = File.Create(path);
            stream.Close();
            File.WriteAllText(path, JsonConvert.SerializeObject(Data, Formatting.Indented));
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Unable to save data due to: {e.Message} {e.StackTrace}");
            return false;
        }
    }

    public T LoadData<T>(string RelativePath, bool Encrypted)
    {
        string path = Application.persistentDataPath + RelativePath + ".json";

        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load file at {path}. File does not exist!");
            throw new FileNotFoundException($"{path} does not exist!");
        }

        try
        {
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
            throw e;
        }
    }

    public List<T> LoadAllUserData<T>(bool Encrypted)
    {
        List<T> allUserData = new List<T>();

        // Ensure the folder exists and check if there are any files
        string path = Application.persistentDataPath;
        if (Directory.Exists(path))
        {
            // Get all .json files in the folder
            string[] files = Directory.GetFiles(path, "*.json");

            foreach (string file in files)
            {
                // Read the JSON file and convert it to UserData
                string json = File.ReadAllText(file);
                T data = JsonConvert.DeserializeObject<T>(json);
                //UserData data = JsonUtility.FromJson<UserData>(json);

                if (data != null)
                {
                    allUserData.Add(data);
                }
            }
        }

        return allUserData;
    }
}
