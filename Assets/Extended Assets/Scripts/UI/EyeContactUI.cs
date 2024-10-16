using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EyeContactUI : MonoBehaviour
{
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
    private TextMeshProUGUI eyeContactText;

    private int eyeContactFinish = 0;
    public int total;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
