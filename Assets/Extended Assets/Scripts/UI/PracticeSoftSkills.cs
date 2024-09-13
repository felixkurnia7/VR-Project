using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSoftSkills : MonoBehaviour
{
    [SerializeField]
    private GameObject speechRecognition;
    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private GameObject eyeContact;
    [SerializeField]
    private GameObject handMovement;

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
                timer.SetActive(true);
                eyeContact.SetActive(false);
                handMovement.SetActive(false);
                break;
            case 2:
                eyeContact.SetActive(true);
                speechRecognition.SetActive(false);
                timer.SetActive(false);
                handMovement.SetActive(false);
                break;
            case 3:
                handMovement.SetActive(true);
                speechRecognition.SetActive(false);
                timer.SetActive(false);
                eyeContact.SetActive(false);
                break;
            default:
                speechRecognition.SetActive(false);
                timer.SetActive(false);
                eyeContact.SetActive(false);
                handMovement.SetActive(false);
                break;
        }
    }
}
