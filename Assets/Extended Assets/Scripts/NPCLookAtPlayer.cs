using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLookAtPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float rotationSpeed = 5.0f; // Speed of rotation

    private void Awake()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Get the direction to the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Ignore the Y component to keep the character upright

            if (direction != Vector3.zero) // Prevent zero vector errors
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                // Smoothly rotate towards the player on the Y-axis
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
