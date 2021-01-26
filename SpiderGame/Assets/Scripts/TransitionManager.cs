using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public AudioSource audioData;
    public GameObject blackOutSquare;
    public Button retryButton;
    public Text retryText;
    // public GameObject retryButton;


    void Start() { 
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 1);
        blackOutSquare.GetComponent<Image>().color = objectColor;
    
        StartCoroutine(FadeBlackOutSquare(false)); //Fade in
    }

    void OnEnable()
    {
        SpiderMovement.OnKill += KillTransition;
    }

    void OnDisable()
    {
        SpiderMovement.OnKill -= KillTransition;
    }

    void KillTransition()
    {
        audioData.Play();
        StartCoroutine(FadeBlackOutSquare());
        //TODO: display buttons to change scenes

        retryButton.enabled = true;
        retryText.enabled = true;
        
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float fadeSpeed = .5f){
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if(fadeToBlack){
            while (blackOutSquare.GetComponent<Image>().color.a < 1){
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else{
            while (blackOutSquare.GetComponent<Image>().color.a > 0){
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        
        // yield return new WaitForEndOfFrame();
    }
}
