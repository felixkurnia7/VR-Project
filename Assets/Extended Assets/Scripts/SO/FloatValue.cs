using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Features/Float", fileName = "Create New Float")]
public class FloatValue : ScriptableObject
{
    public float value;
    public int numberOfValue;

    public void ResetValue()
    {
        value = 0f;
        numberOfValue = 0;
    }
}
