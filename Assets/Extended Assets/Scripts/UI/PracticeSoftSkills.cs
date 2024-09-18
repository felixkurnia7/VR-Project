using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSoftSkills : MonoBehaviour
{
    [Header("SPEECH RECOGNITION")]
    [SerializeField]
    private GameObject speechRecognition;
    [SerializeField]
    private GameObject welcomeSR;
    [SerializeField]
    private GameObject ASR;
    [SerializeField]
    private GameObject WPM;
    [SerializeField]
    private GameObject volumeSpeak;
    [SerializeField]
    private GameObject timer;

    [Header("EYE CONTACT")]
    [SerializeField]
    private GameObject eyeContact;
    [SerializeField]
    private GameObject welcomeEC;
    [SerializeField]
    private GameObject panelEC;

    [Header("HAND MOVEMENT")]
    [SerializeField]
    private GameObject handMovement;
    [SerializeField]
    private GameObject welcomeHM;
    [SerializeField]
    private GameObject leftPanel;
    [SerializeField]
    private GameObject rightPanel;

    private int index;

    public void SelectPractice(int value)
    {
        index = value;
        SpawnPractice();
    }

    void SpawnPractice()
    {
        switch(index)
        {
            case 1:
                speechRecognition.SetActive(true);
                welcomeSR.SetActive(true);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);

                eyeContact.SetActive(false);
                welcomeEC.SetActive(false);
                panelEC.SetActive(false);

                handMovement.SetActive(false);
                welcomeHM.SetActive(false);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);

                gameObject.SetActive(false);
                break;
            case 2:
                speechRecognition.SetActive(false);
                welcomeSR.SetActive(false);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);

                eyeContact.SetActive(true);
                welcomeEC.SetActive(true);
                panelEC.SetActive(false);

                handMovement.SetActive(false);
                welcomeHM.SetActive(false);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);

                gameObject.SetActive(false);
                break;
            case 3:
                speechRecognition.SetActive(false);
                welcomeSR.SetActive(false);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);

                eyeContact.SetActive(false);
                welcomeEC.SetActive(false);
                panelEC.SetActive(false);

                handMovement.SetActive(true);
                welcomeHM.SetActive(true);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);

                gameObject.SetActive(false);
                break;
            default:
                speechRecognition.SetActive(false);
                welcomeSR.SetActive(false);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);

                eyeContact.SetActive(false);
                welcomeEC.SetActive(false);
                panelEC.SetActive(false);

                handMovement.SetActive(false);
                welcomeHM.SetActive(false);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);

                gameObject.SetActive(false);
                break;
        }
    }
}
