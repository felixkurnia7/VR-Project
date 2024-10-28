using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookAtPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    private void Awake()
    {
        player = Camera.main.transform;
    }
    void Update()
    {
        if (player != null)
        {
            // Make the character look at the player's position
            transform.LookAt(player.position);
        }
    }
}
