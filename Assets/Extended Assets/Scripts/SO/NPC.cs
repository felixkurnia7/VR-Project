using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create NPC", fileName = "NPC")]
public class NPC : ScriptableObject
{
    public float stare;
    public bool isStare;
    public bool eyeContactDone;

    public void ResetNPC()
    {
        stare = 0;
        isStare = false;
        eyeContactDone = false;
    }

    public void DoneEyeContact()
    {
        eyeContactDone = true;
    }
}
