using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHandMovement : MonoBehaviour
{
    [SerializeField]
    private Transform leftHand;
    [SerializeField]
    private Transform rightHand;

    [SerializeField]
    private float movementThreshold;
    [SerializeField]
    private float stationaryTimeThreshold;
    [SerializeField]
    private float smoothFactor;

    private Vector3 prevLeftHandPosition;
    private Vector3 prevRightHandPosition;
    private float stationaryTime;
    private float smoothedVelocity;

    // Start is called before the first frame update
    void Start()
    {
        prevLeftHandPosition = leftHand.position;
        prevRightHandPosition = rightHand.position;
        stationaryTime = 0.0f;
        smoothedVelocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curLeftHandPosition = leftHand.position;
        Vector3 curRightHandPosition = rightHand.position;
        float rawVelocity = ((curLeftHandPosition - prevLeftHandPosition).magnitude / Time.deltaTime)
                            + ((curRightHandPosition - prevRightHandPosition).magnitude / Time.deltaTime);

        // Apply exponential moving average for smoothing
        smoothedVelocity = smoothFactor * rawVelocity + (1 - smoothFactor) * smoothedVelocity;
        //Debug.Log(smoothedVelocity);
        if (smoothedVelocity > movementThreshold)
        {
            stationaryTime = 0.0f;
            //Debug.Log("Left Controller is moving");
        }
        else
        {
            stationaryTime += Time.deltaTime;
            if (stationaryTime >= stationaryTimeThreshold)
            {
                //Debug.Log("Left Controller is stationary");
            }
        }

        prevLeftHandPosition = curLeftHandPosition;
        prevRightHandPosition = curRightHandPosition;
    }
}
