using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public AudioSource audioData;

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
    }
}
