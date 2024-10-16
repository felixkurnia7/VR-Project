using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSoftSkills : MonoBehaviour
{
    [Header("SPEECH RECOGNITION")]
    [SerializeField]
    private GameObject speechRecognition;
    [SerializeField]
    private GameObject speechRecognitionSystem;
    [SerializeField]
    private GameObject checkVolumeSystem;
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
    [SerializeField]
    private GameObject secondaryButton;

    [Header("EYE CONTACT")]
    [SerializeField]
    private GameObject eyeContact;
    [SerializeField]
    private GameObject eyeContactSystem;
    [SerializeField]
    private GameObject welcomeEC;
    [SerializeField]
    private GameObject panelEC;
    [SerializeField]
    private GameObject eyeContactUI;

    [Header("HAND MOVEMENT")]
    [SerializeField]
    private GameObject handMovement;
    [SerializeField]
    private GameObject handMovementSystem;
    [SerializeField]
    private GameObject welcomeHM;
    [SerializeField]
    private GameObject leftPanel;
    [SerializeField]
    private GameObject rightPanel;
    [SerializeField]
    private GameObject resetButton;

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
                speechRecognitionSystem.SetActive(true);
                checkVolumeSystem.SetActive(true);
                welcomeSR.SetActive(true);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);

                eyeContact.SetActive(false);
                eyeContactSystem.SetActive(false);
                welcomeEC.SetActive(false);
                panelEC.SetActive(false);
                eyeContactUI.SetActive(false);

                handMovement.SetActive(false);
                handMovementSystem.SetActive(false);
                welcomeHM.SetActive(false);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);
                resetButton.SetActive(false);

                gameObject.SetActive(false);

                secondaryButton.SetActive(true);
                break;
            case 2:
                speechRecognition.SetActive(false);
                speechRecognitionSystem.SetActive(false);
                checkVolumeSystem.SetActive(false);
                welcomeSR.SetActive(false);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);

                eyeContact.SetActive(true);
                eyeContactSystem.SetActive(true);
                welcomeEC.SetActive(true);
                panelEC.SetActive(false);
                eyeContactUI.SetActive(false);

                handMovement.SetActive(false);
                handMovementSystem.SetActive(false);
                welcomeHM.SetActive(false);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);
                resetButton.SetActive(false);

                gameObject.SetActive(false);

                secondaryButton.SetActive(false);
                break;
            case 3:
                speechRecognition.SetActive(false);
                speechRecognitionSystem.SetActive(false);
                checkVolumeSystem.SetActive(false);
                welcomeSR.SetActive(false);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);

                eyeContact.SetActive(false);
                eyeContactSystem.SetActive(false);
                welcomeEC.SetActive(false);
                panelEC.SetActive(false);
                eyeContactUI.SetActive(false);

                handMovement.SetActive(true);
                handMovementSystem.SetActive(true);
                welcomeHM.SetActive(true);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);
                resetButton.SetActive(false);

                gameObject.SetActive(false);

                secondaryButton.SetActive(false);
                break;
            default:
                speechRecognition.SetActive(false);
                speechRecognitionSystem.SetActive(false);
                checkVolumeSystem.SetActive(false);
                welcomeSR.SetActive(false);
                ASR.SetActive(false);
                WPM.SetActive(false);
                volumeSpeak.SetActive(false);
                timer.SetActive(false);

                eyeContact.SetActive(false);
                eyeContactSystem.SetActive(false);
                welcomeEC.SetActive(false);
                panelEC.SetActive(false);
                eyeContactUI.SetActive(false);

                handMovement.SetActive(false);
                handMovementSystem.SetActive(false);
                welcomeHM.SetActive(false);
                leftPanel.SetActive(false);
                rightPanel.SetActive(false);
                resetButton.SetActive(false);

                gameObject.SetActive(false);

                secondaryButton.SetActive(false);
                break;
        }
    }
}
