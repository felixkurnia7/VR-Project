using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLookAtPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float rotationSpeed = 5.0f; // Speed of rotation
    public bool trainingStart;
    public Transform npcPos;

    private void Awake()
    {
        player = Camera.main.transform;
        trainingStart = false;
    }

    void Update()
    {
        transform.position = npcPos.position;
        if (player != null && trainingStart == true)
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

    public void StartTraining()
    {
        trainingStart = true;
    }

    public void StopTraining()
    {
        trainingStart = false;
    }
}
