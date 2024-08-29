using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Timer Value", fileName = "Timer")]
public class TimerValue : ScriptableObject
{
    public float value;

    public void ResetTimer()
    {
        value = 0;
    }
}
