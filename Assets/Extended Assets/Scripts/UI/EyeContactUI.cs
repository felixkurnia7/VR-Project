using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EyeContactUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI eyeContactText;

    public int total;

    // Update is called once per frame
    void Update()
    {
        CheckEyeContactUI();

    }

    private void CheckEyeContactUI()
    {
        eyeContactText.text = total.ToString();
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
