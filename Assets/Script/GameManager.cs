using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int collectedCount = 0;
    public GameObject barrier; 

    public TextMeshProUGUI itemTextUI;
    public float textDuration = 2f;  

    private Coroutine textCoroutine;

    public AudioSource audioSource;
    public AudioClip pickupSound;

    private void Start()
    {
        
        if (itemTextUI != null)
        {
            itemTextUI.text = "";
            itemTextUI.gameObject.SetActive(false);
        }
    }
    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemType itemType)
    {

        audioSource.PlayOneShot(pickupSound);
        collectedCount++;

         switch (itemType)
        {
            case ItemType.Ring:
                ShowItemText("My hands shook so much I almost dropped it. She said yes before I even finished the question.");
                break;

            case ItemType.Guitar:
                ShowItemText("I used to play until my fingers went numb. Then “maybe later” turned into years.");
                break;

            case ItemType.WoodenDog:
                ShowItemText("He’d drag this across the kitchen floor until I looked up. I kept saying, “Just a minute, buddy.”");
                break;
        }

        
        

        
    }

    public void Update(){
        if (collectedCount >= 3)
        {
            barrier.SetActive(false);   
        }
    }

    public void ShowItemText(string message)
    {
        itemTextUI.gameObject.SetActive(true);
        itemTextUI.text = message;

        if (textCoroutine != null)
            StopCoroutine(textCoroutine);

        textCoroutine = StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(textDuration);

        if (itemTextUI != null)
        {
            itemTextUI.text = "";
            itemTextUI.gameObject.SetActive(false);
        }
    }
}
