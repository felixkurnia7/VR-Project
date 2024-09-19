using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Features/String", fileName = "Create New String")]
public class StringValue : ScriptableObject
{
    public string text;

    public void ResetText()
    {
        text = "";
    }
}
