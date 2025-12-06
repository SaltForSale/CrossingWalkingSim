using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip pickupSound;
    public Transform player;

    public Image fadePanel;
    void Start()
    {
       
        fadePanel.color = new Color(1, 1, 1, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            StartFade();
        }
    }

    public void StartFade()
    {
        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        
        float t = 0;
        while (t < 2f)
        {
            t += Time.deltaTime;
            fadePanel.color = new Color(1, 1, 1, t);
            
            yield return null;
        }
        audioSource.PlayOneShot(pickupSound);
        player.GetComponent<FirstPersonDrifter>().enabled = false;
        
        yield return new WaitForSeconds(3.5f);

        QuitGame();

    
    }

    void QuitGame()
    {
        
        Application.Quit();

        
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
