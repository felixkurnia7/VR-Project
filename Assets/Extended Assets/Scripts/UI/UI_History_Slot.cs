using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_History_Slot : MonoBehaviour
{
    [SerializeField] UI_History UiHistory;

    [Header("Text UI to Show Data")]
    [SerializeField] TextMeshProUGUI wpmText;
    [SerializeField] TextMeshProUGUI eyeContactText;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI handMovementText;

    // Start is called before the first frame update
    void Start()
    {
        UiHistory.InitializeData += GetData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        UiHistory.InitializeData -= GetData;
    }

    private void GetData(UserData data, GameObject go)
    {
        UiHistory = go.GetComponent<UI_History>();
        wpmText.text = data.wpm.value.ToString();
    }
}
