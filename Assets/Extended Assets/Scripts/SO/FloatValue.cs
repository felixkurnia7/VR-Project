using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Float Value", fileName = "Float")]
public class FloatValue : ScriptableObject
{
    public float value;

    public void ResetTimer()
    {
        value = 0f;
    }
}
