
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

    public GameObject pressEUI;

    void Start()
    {

        if (pressEUI != null)
            pressEUI.SetActive(false);  

        player = GameObject.FindWithTag("Player").transform;
        
    }

    void Update()
{
    float dist = Vector3.Distance(itselfObject.transform.position, player.position);
    

    if (dist <= range)
    {
       if (pressEUI != null)
            pressEUI.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            

            CharacterController cc = player.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            player.position = otherLocation.transform.position;

           

            if (cc != null) cc.enabled = true;
        }
    }
    else
    {
            
        if (pressEUI != null)
            pressEUI.SetActive(false);
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
