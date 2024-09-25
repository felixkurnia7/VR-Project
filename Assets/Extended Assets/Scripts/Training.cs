using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField]
    private StringValue text;
    [SerializeField]
    private IntValue WPM;
    [SerializeField]
    private FloatValue volume;
    [SerializeField]
    private FloatValue timer;
    [SerializeField]
    private NPC NPC1;
    [SerializeField]
    private NPC NPC2;
    [SerializeField]
    private NPC NPC3;
    [SerializeField]
    private NPC NPC4;
    [SerializeField]
    private NPC NPC5;
    [SerializeField]
    private Hand leftHand;
    [SerializeField]
    private Hand rightHand;

    [Header("User Interface")]
    [SerializeField]
    private GameObject UI_WPM;
    [SerializeField]
    private GameObject UI_volume;
    [SerializeField]
    private GameObject UI_timer;
    [SerializeField]
    private GameObject UI_eyecontact;
    [SerializeField]
    private GameObject UI_handmovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTraining()
    {
        text.ResetText();
        WPM.ResetValue();
        volume.ResetValue();
        timer.ResetValue();
        NPC1.ResetNPC();
        NPC2.ResetNPC();
        NPC3.ResetNPC();
        NPC4.ResetNPC();
        NPC5.ResetNPC();
        leftHand.ResetValue();
        rightHand.ResetValue();
    }

    public void StopTraining()
    {
        UI_WPM.SetActive(true);
        UI_volume.SetActive(true);
        UI_timer.SetActive(true);
        UI_handmovement.SetActive(true);
        UI_eyecontact.SetActive(true);
    }
}
