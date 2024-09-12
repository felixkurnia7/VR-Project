using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Text", fileName = "Text")]
public class StringValue : ScriptableObject
{
    public string text;

    public void ResetText()
    {
        text = "";
    }
}
