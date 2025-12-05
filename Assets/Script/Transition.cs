
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Transform player;
    public float range = 1f;

    public GameObject itselfObject;
    public GameObject otherLocation;

    private bool canTeleport = true; 

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Debug.Log(player.position);
        Debug.Log(itselfObject.transform.position);
        Debug.Log(otherLocation.transform.position);
    }

    void Update()
{
    float dist = Vector3.Distance(itselfObject.transform.position, player.position);
    

    if (dist <= range)
    {
       

        if (Input.GetKeyDown(KeyCode.E))
        {
            

            CharacterController cc = player.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            player.position = otherLocation.transform.position;

           

            if (cc != null) cc.enabled = true;
        }
    }
}


    IEnumerator Teleport()
    {
        canTeleport = false;

        
        player.position = otherLocation.transform.position;
        Debug.Log("Teleported! New Position: " + player.position);
        
        yield return new WaitForSeconds(0.5f);

        canTeleport = true;
    }
}
