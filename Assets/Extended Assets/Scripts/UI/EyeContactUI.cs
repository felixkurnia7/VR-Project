using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EyeContactUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI eyeContactTextPractice;
    [SerializeField]
    private TextMeshProUGUI eyeContactTextResult;

    public int total;

    // Update is called once per frame
    void Update()
    {
        CheckEyeContactUI();
    }

    private void CheckEyeContactUI()
    {
        if (eyeContactTextPractice != null)
            eyeContactTextPractice.text = total.ToString();

        if (eyeContactTextResult != null)
            eyeContactTextResult.text = total.ToString();
    }

    public void EyeContactFinish()
    {
        total++;
    }

    public void ResetEyeContact()
    {
        total = 0;
    }
}
