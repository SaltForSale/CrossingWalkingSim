using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepClips;  

    public float stepInterval = 0.5f;

    private CharacterController controller;
    private Vector3 lastPosition;
    private float stepTimer = 0f;

    private float moveThreshold = 0.1f;

    private bool isMoving = false;
    private bool wasMoving = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        lastPosition = transform.position;
    }

    void Update()
    {
     
        float moved = Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        isMoving = moved > moveThreshold && controller.isGrounded;

        if (isMoving)
        {
            stepTimer += Time.deltaTime;

        
            if (!wasMoving)
                stepTimer = 0f;

            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
           
            stepTimer = 0f;
        }

        wasMoving = isMoving;
    }

    void PlayFootstep()
    {
        if (footstepClips.Length == 0) return;

        audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
    }
}
