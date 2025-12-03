using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public Image fadePanel;
   

    void Start()
    {
       
        fadePanel.color = new Color(1, 1, 1, 0);

        

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

        yield return new WaitForSeconds(0.5f);

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
