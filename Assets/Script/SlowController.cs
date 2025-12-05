using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZoneTrigger : MonoBehaviour
{
    public float slowSpeed = 2f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonDrifter fp = other.GetComponent<FirstPersonDrifter>();
            if (fp != null)
            {
                fp.targetWalkSpeed = slowSpeed; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonDrifter fp = other.GetComponent<FirstPersonDrifter>();
            if (fp != null)
            {
                fp.targetWalkSpeed = fp.walkSpeed; 
            }
        }
    }
}
