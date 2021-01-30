using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepEventCall : MonoBehaviour
{
    // public AudioSource footstep_source;
    public AudioClip[] footstepsArray;
    public AudioSource audioSource;

    public void PlayFootstep () {
        // footstep_source.Play();
        AudioClip clip = (AudioClip)footstepsArray[Random.Range(0, footstepsArray.Length)];
        audioSource.PlayOneShot(clip, 1.0f);
    }

}
