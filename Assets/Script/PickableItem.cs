using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public float pickupRange = 3f; 
    public Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= pickupRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.AddItem();  
                Destroy(gameObject);
            }
        }
    }
}
