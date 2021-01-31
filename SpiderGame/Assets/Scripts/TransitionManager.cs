using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public AudioSource audioData;
    public GameObject blackOutSquare;
    public GameObject whiteOutSquare;
    public Button retryButton;
    public Text retryText;
    public Button quitButton;
    public Text quitText;
    public GameObject player;

    public delegate void PlayerStop();
    public static event PlayerStop OnPlayerStop;


    void Start() { 
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 1);
        blackOutSquare.GetComponent<Image>().color = objectColor;
    
        StartCoroutine(FadeBlackOutSquare(false)); //Fade in
    }

    void OnEnable()
    {
        SpiderMovement.OnKill += KillTransition;
        PlayerColliderScript.OnDoorOpen += DoorTransition;
    }

    void OnDisable()
    {
        SpiderMovement.OnKill -= KillTransition;
        PlayerColliderScript.OnDoorOpen -= DoorTransition;
    }

    void DoorTransition(){
        OnPlayerStop();
        StartCoroutine(FadeWhiteOutSquare());

        retryButton.enabled = true;
        retryText.enabled = true;
        retryText.color = new Color(0, 0, 0);

        quitButton.enabled = true;
        quitText.enabled = true;
        quitText.color = new Color(0, 0, 0);
    }

    void KillTransition()
    {
        OnPlayerStop();
        audioData.Play();
        StartCoroutine(FadeBlackOutSquare());

        retryButton.enabled = true;
        retryText.enabled = true;
    

        quitButton.enabled = true;
        quitText.enabled = true;
    }


    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float fadeSpeed = .4f){
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
    }


    public IEnumerator FadeWhiteOutSquare(bool fadeToWhite = true, float fadeSpeed = .2f){
        Color objectColor = whiteOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if(fadeToWhite){
            while (whiteOutSquare.GetComponent<Image>().color.a < 1){
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                whiteOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else{
            while (whiteOutSquare.GetComponent<Image>().color.a > 0){
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                whiteOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
