using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Integer Value", fileName = "Int")]
public class IntValue : ScriptableObject
{
    public int value;

    public void ResetValue()
    {
        value = 0;
    }
}
