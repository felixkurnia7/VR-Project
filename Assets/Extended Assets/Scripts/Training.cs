using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField]
    private StringValue text;
    [SerializeField]
    private FloatValue WPM;
    [SerializeField]
    private FloatValue volume;
    [SerializeField]
    private FloatValue time;
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
    //[SerializeField]
    //private GameObject timerCanvas;
    [SerializeField]
    private GameObject statistic;
    [SerializeField]
    private GameObject resultUI;

    [Header("Systems")]
    [SerializeField]
    private GameObject speechRecognition;
    [SerializeField]
    private GameObject eyeContactSystem;
    [SerializeField]
    private GameObject checkVolumeSystem;
    [SerializeField]
    private GameObject checkWPMSystem;
    [SerializeField]
    private GameObject fillerWordDetector;
    [SerializeField]
    private GameObject handMovementSystem;
    [SerializeField]
    private Timer timer;

    [Header("GameObject")]
    [SerializeField]
    private GameObject chair1;
    [SerializeField]
    private GameObject chair2;
    [SerializeField]
    private GameObject chair3;
    [SerializeField]
    private GameObject chair4;
    [SerializeField]
    private GameObject chair5;

    [Header("NPC")]
    [SerializeField]
    private GameObject Char_NPC1;
    [SerializeField]
    private GameObject Char_NPC2;
    [SerializeField]
    private GameObject Char_NPC3;
    [SerializeField]
    private GameObject Char_NPC4;
    [SerializeField]
    private GameObject Char_NPC5;

    public void StartTraining()
    {
        text.ResetText();
        WPM.ResetValue();
        volume.ResetValue();
        time.ResetValue();
        NPC1.ResetNPC();
        NPC2.ResetNPC();
        NPC3.ResetNPC();
        NPC4.ResetNPC();
        NPC5.ResetNPC();
        leftHand.ResetValue();
        rightHand.ResetValue();

        timer.StartTimer();

        speechRecognition.SetActive(true);
        eyeContactSystem.SetActive(true);
        checkVolumeSystem.SetActive(true);
        handMovementSystem.SetActive(true);
        checkWPMSystem.SetActive(true);
        fillerWordDetector.SetActive(true);

        chair1.GetComponent<ObjLookAtPlayer>().enabled = true;
        chair2.GetComponent<ObjLookAtPlayer>().enabled = true;
        chair3.GetComponent<ObjLookAtPlayer>().enabled = true;
        chair4.GetComponent<ObjLookAtPlayer>().enabled = true;
        chair5.GetComponent<ObjLookAtPlayer>().enabled = true;

        Char_NPC1.SetActive(true);
        Char_NPC2.SetActive(true);
        Char_NPC3.SetActive(true);
        Char_NPC4.SetActive(true);
        Char_NPC5.SetActive(true);
    }

    public void StopTraining()
    {
        speechRecognition.SetActive(false);
        eyeContactSystem.SetActive(false);
        checkVolumeSystem.SetActive(false);
        handMovementSystem.SetActive(false);
        checkWPMSystem.SetActive(false);
        fillerWordDetector.SetActive(false);

        timer.StopTimer();

        statistic.SetActive(true);
        resultUI.SetActive(true);

        chair1.GetComponent<ObjLookAtPlayer>().enabled = false;
        chair2.GetComponent<ObjLookAtPlayer>().enabled = false;
        chair3.GetComponent<ObjLookAtPlayer>().enabled = false;
        chair4.GetComponent<ObjLookAtPlayer>().enabled = false;
        chair5.GetComponent<ObjLookAtPlayer>().enabled = false;

        Char_NPC1.SetActive(false);
        Char_NPC2.SetActive(false);
        Char_NPC3.SetActive(false);
        Char_NPC4.SetActive(false);
        Char_NPC5.SetActive(false);
    }
}
