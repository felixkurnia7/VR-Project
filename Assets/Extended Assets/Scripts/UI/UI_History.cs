using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UI_History : MonoBehaviour
{
    public Action<UserData, GameObject> InitializeData;
    [SerializeField] SaveLoadSystem saveLoadManager;
    [SerializeField] GameObject saveSlot;
    [SerializeField] List<string> uniqueID = new List<string>();

    // List to store references to instantiated prefabs
    private List<GameObject> instantiatedPrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        saveLoadManager.CreateHistorySlot += CreateSlot;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        saveLoadManager.CreateHistorySlot -= CreateSlot;
    }

    public void DeleteAllHistoryWhenOpen()
    {
        foreach (GameObject prefab in instantiatedPrefabs)
        {
            Destroy(prefab);
        }

        instantiatedPrefabs.Clear();
    }

    private void CreateSlot(UserData data)
    {
        uniqueID.Add(data.uniqueID);

        int eyeContactDone = 0;
        if (data.NPC1.eyeContactDone == true)
            eyeContactDone++;

        if (data.NPC2.eyeContactDone == true)
            eyeContactDone++;

        if (data.NPC3.eyeContactDone == true)
            eyeContactDone++;

        if (data.NPC4.eyeContactDone == true)
            eyeContactDone++;

        if (data.NPC5.eyeContactDone == true)
            eyeContactDone++;

        float handMovement = (data.leftHand.score + data.rightHand.score) / 2;

        GameObject slot = Instantiate(saveSlot);
        instantiatedPrefabs.Add(slot);
        slot.transform.SetParent(transform, false);

        TextMeshProUGUI[] texts = slot.GetComponentsInChildren<TextMeshProUGUI>();

        if (texts[2] != null)
        {
            texts[2].text = data.wpm.value.ToString();
        }

        if (texts[4] != null)
        {
            texts[4].text = eyeContactDone.ToString();
        }

        if (texts[6] != null)
        {
            texts[6].text = data.volume.value.ToString();
        }

        if (texts[8] != null)
        {
            texts[8].text = data.timer.value.ToString();
        }

        if (texts[10] != null)
        {
            texts[10].text = handMovement.ToString();
        }
    }
}
