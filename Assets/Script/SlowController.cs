using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZoneTrigger : MonoBehaviour
{
    public float slowSpeed = 2f;
    private FirstPersonDrifter fp;
    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fp = other.GetComponent<FirstPersonDrifter>();
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fp != null)
                fp.targetWalkSpeed = fp.walkSpeed; 

            fp = null;
            playerInside = false;
        }
    }

    private void Update()
    {
        if (!playerInside || fp == null)
            return;

    
        float yRot = fp.transform.eulerAngles.y;

        
        if (yRot >= 90f && yRot <= 270f)
        {
            fp.targetWalkSpeed = slowSpeed;
        }
        else
        {
            fp.targetWalkSpeed = 5f;
        }
    }
}
