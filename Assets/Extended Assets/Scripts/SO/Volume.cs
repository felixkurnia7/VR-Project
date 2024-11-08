using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Features/Volume", fileName = "Create New Volume")]
public class Volume : MonoBehaviour
{
    public float volume;
    public int numberOfVolumes;

    public void Reset()
    {
        volume = 0f;
        numberOfVolumes = 0;
    }
}
