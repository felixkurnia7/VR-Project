using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField]
    private TextMeshProUGUI leftHandText;
    [SerializeField]
    private TextMeshProUGUI rightHandText;

    private Vector3 prevLeftHandPosition;
    private Vector3 prevRightHandPosition;
    private float stationaryTime;
    private float smoothedLeftVelocity;
    private float smoothedRightVelocity;

    // Start is called before the first frame update
    void Start()
    {
        prevLeftHandPosition = leftHand.position;
        prevRightHandPosition = rightHand.position;
        stationaryTime = 0.0f;
        smoothedLeftVelocity = 0.0f;
        smoothedRightVelocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curLeftHandPosition = leftHand.position;
        Vector3 curRightHandPosition = rightHand.position;
        float leftVelocity = (curLeftHandPosition - prevLeftHandPosition).magnitude / Time.deltaTime;

        float rightVelocity = (curRightHandPosition - prevRightHandPosition).magnitude / Time.deltaTime;

        // Apply exponential moving average for smoothing
        smoothedLeftVelocity = smoothFactor * leftVelocity + (1 - smoothFactor) * smoothedLeftVelocity;
        smoothedRightVelocity = smoothFactor * rightVelocity + (1 - smoothFactor) * smoothedRightVelocity;
        //Debug.Log(smoothedVelocity);
        if (smoothedLeftVelocity > movementThreshold)
        {
            stationaryTime = 0.0f;
            //Debug.Log("Left Hand is moving");
            leftHandText.text = "Moving";
        }
        else
        {
            stationaryTime += Time.deltaTime;
            if (stationaryTime >= stationaryTimeThreshold)
            {
                //Debug.Log("Left Hand is stationary");
                leftHandText.text = "";
            }
        }

        if (smoothedRightVelocity > movementThreshold)
        {
            stationaryTime = 0.0f;
            //Debug.Log("Right Hand is moving");
            rightHandText.text = "Moving";
        }
        else
        {
            stationaryTime += Time.deltaTime;
            if (stationaryTime >= stationaryTimeThreshold)
                rightHandText.text = "";
                //Debug.Log("Right Hand is stationary");
        }

        prevLeftHandPosition = curLeftHandPosition;
        prevRightHandPosition = curRightHandPosition;
    }
}
