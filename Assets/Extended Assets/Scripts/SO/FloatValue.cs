using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Features/Float", fileName = "Create New Float")]
public class FloatValue : ScriptableObject
{
    public float value;
    public int numberOfValue;
    public List<float> listValues = new();

    public void ResetValue()
    {
        value = 0f;
        numberOfValue = 0;
        listValues.Clear();
    }
}
