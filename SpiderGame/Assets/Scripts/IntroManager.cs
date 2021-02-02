using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text moveText;
    public Text standText;
    public Image buttonImg;
    public Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        text1.color = new Color(text1.color.r, text1.color.b, text1.color.g, 0);
        text2.color = new Color(text2.color.r, text2.color.b, text2.color.g, 0);
        moveText.color = new Color(moveText.color.r, moveText.color.b, moveText.color.g, 0);
        standText.color = new Color(standText.color.r, standText.color.b, standText.color.g, 0);
        buttonText.color = new Color(buttonText.color.r, buttonText.color.b, buttonText.color.g, 0);
        buttonImg.color = new Color(buttonImg.color.r, buttonImg.color.b, buttonImg.color.g, 0);
        StartCoroutine(introFading());
    }

    IEnumerator introFading(){
        StartCoroutine(FadeTextIn(text1));
        yield return new WaitForSecondsRealtime(3);
        StartCoroutine(FadeTextIn(text2));
        yield return new WaitForSecondsRealtime(3);
        StartCoroutine(FadeTextIn(moveText));
        StartCoroutine(FadeTextIn(standText));
        yield return new WaitForSecondsRealtime(2.5f);
        StartCoroutine(FadeTextIn(buttonText));
        StartCoroutine(FadeImageIn(buttonImg));
    }

    public IEnumerator FadeTextIn(Text targetObj, float fadeSpeed = .4f){
        Color objColor = targetObj.color;
        float fadeAmount;

        while (targetObj.color.a < 1){
            fadeAmount = objColor.a + (fadeSpeed * Time.deltaTime);
            objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
            targetObj.color = objColor;
            yield return null;
        }
    }

        public IEnumerator FadeImageIn(Image targetObj, float fadeSpeed = .3f){
        Color objColor = targetObj.color;
        float fadeAmount;

        while (targetObj.color.a < 1){
            fadeAmount = objColor.a + (fadeSpeed * Time.deltaTime);
            objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
            targetObj.color = objColor;
            yield return null;
        }
    }
}
