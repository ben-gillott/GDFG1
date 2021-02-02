using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    public Collider2D doorCollider;
    public delegate void DoorOpen();
    public static event DoorOpen OnDoorOpen;
    public AudioSource lockedDoor;
    public AudioSource keySound;
    public AudioSource doorOpen;
    public GameObject lockedDoorTrigger;

    void OnTriggerEnter2D(Collider2D triggerObj){
        if(triggerObj.gameObject.tag == "LockedDoorTrigger"){
            lockedDoor.Play();
        }

        if(triggerObj.gameObject.tag == "Door"){
            //Trigger door open event
            doorOpen.Play();
            if(OnDoorOpen != null){
                OnDoorOpen();
            }
        }
        else if(triggerObj.gameObject.tag == "Key"){
            //Makes the door available to use as a trigger, and thus passable
            Destroy(triggerObj.gameObject);
            keySound.Play();
            doorCollider.isTrigger = true;
            Destroy(lockedDoorTrigger);
        }
    }

}
