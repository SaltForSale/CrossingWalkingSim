using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Ring,       // Blue
    Guitar,     // Red
    WoodenDog   // Yellow
}

public class PickableItem : MonoBehaviour
{
    public float pickupRange = 3f;
    public Transform player;

    
    public ItemType itemType;

    
    public List<MeshRenderer> streetLightRenderers = new List<MeshRenderer>();
    public List<Light> streetLights = new List<Light>();

    
    public Material blueMaterial;
    public Material redMaterial;
    public Material yellowMaterial;

    private Color targetColor;

    public GameObject pressEUI;

    


 
   
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (pressEUI != null)
            pressEUI.SetActive(false);  
        

        
        switch (itemType)
        {
            case ItemType.Ring:
                targetColor = Color.blue;
                break;

            case ItemType.Guitar:
                targetColor = Color.red;
                break;

            case ItemType.WoodenDog:
                targetColor = Color.yellow;
                break;
        }
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= pickupRange)
        {
            if (pressEUI != null)
                pressEUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.AddItem(itemType);
                 
                
                ChangeStreetLightMaterials();

                
                foreach (Light light in streetLights)
                {
                    light.color = targetColor;
                }

                

                Destroy(gameObject);
                Destroy(pressEUI);
            }
        }
        else
        {
            
            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }

    void ChangeStreetLightMaterials()
    {
        Material chosenMaterial = null;

        switch (itemType)
        {
            case ItemType.Ring:
                chosenMaterial = blueMaterial;
                break;

            case ItemType.Guitar:
                chosenMaterial = redMaterial;
                break;

            case ItemType.WoodenDog:
                chosenMaterial = yellowMaterial;
                break;
        }

        foreach (MeshRenderer rend in streetLightRenderers)
        {
            rend.material = chosenMaterial;
        }
    }
     
}
