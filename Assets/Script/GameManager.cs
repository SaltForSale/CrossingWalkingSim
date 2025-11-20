using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int collectedCount = 0;
    public GameObject barrier; 

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem()
    {
        collectedCount++;

        

        if (collectedCount >= 3)
        {
            barrier.SetActive(false);   
        }
    }
}
