using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] GameObject hourHand;
    [SerializeField] GameObject minuteHand;
    [SerializeField] GameObject secondHand;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("UpdateClock", 0f, 1f);
    }

    private void Update()
    {
        Debug.Log(System.DateTime.Now.Hour + " " + System.DateTime.Now.Minute + " " + System.DateTime.Now.Second);
    }

    void UpdateClock()
    {
        float hourAngle = ((System.DateTime.Now.Hour + (System.DateTime.Now.Minute / 60)) * 30) + 90;
        float minuteAngle = (System.DateTime.Now.Minute * (360f / 60)) + 90;
        float secondAngle = (System.DateTime.Now.Second * (360 / 60)) + 90;

        Vector3 targetHour = new Vector3(hourAngle, 0, -90);
        Vector3 targetMinute = new Vector3(minuteAngle, 0, -90);
        Vector3 targetSecond = new Vector3(secondAngle, 0, -90);

        hourHand.transform.localRotation = Quaternion.Euler(targetHour);
        minuteHand.transform.localRotation = Quaternion.Euler(targetMinute);
        secondHand.transform.localRotation = Quaternion.Euler(targetSecond);

        //hourHand.transform.rotation = Quaternion.Slerp(hourHand.transform.rotation, targetHour, Time.deltaTime * smooth);
        //minuteHand.transform.rotation = Quaternion.Slerp(minuteHand.transform.rotation, targetMinute, Time.deltaTime * smooth);
        //secondHand.transform.rotation = Quaternion.Slerp(secondHand.transform.rotation, targetSecond, Time.deltaTime * smooth);
    }
}
