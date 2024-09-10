using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    [SerializeField]
    private EyeContact eyeContact;
    [SerializeField]
    private NPC npc;
    [SerializeField]
    private float eyeContactThreshold;

    private void Awake()
    {
        npc.ResetNPC();
    }

    // Update is called once per frame
    void Update()
    {
        if (npc.stare >= eyeContactThreshold)
            npc.DoneEyeContact();
    }

    public void LookedAtNPC()
    {
        npc.stare += Time.deltaTime;
    }
}
