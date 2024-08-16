using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeContact : MonoBehaviour
{
    [SerializeField]
    private float _distance;
    [SerializeField]
    private LayerMask npcLayer;
    [SerializeField]
    private bool isLookingAtNPC;
    [SerializeField]
    private int _eyeContactScore = 0;

    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckEyeContact();
    }

    private void CheckEyeContact()
    {
        isLookingAtNPC = Physics.Raycast(transform.position, transform.forward, _distance, npcLayer);

        if (isLookingAtNPC)
        {
            // Increment eye contact value
            _eyeContactScore += 1;
            // NPC animation changed
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isLookingAtNPC ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * _distance);
    }
}
