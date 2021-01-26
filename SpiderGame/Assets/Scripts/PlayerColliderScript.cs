using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    public delegate void DoorOpen();
    public static event DoorOpen OnDoorOpen;

    void OnTriggerEnter2D(Collider2D triggerObj){
        if(triggerObj.gameObject.tag == "Door"){
            //Trigger door open event
            if(OnDoorOpen != null){
                OnDoorOpen();
            }
        } 
        else if(triggerObj.gameObject.tag == "Key"){
            //TODO: Implement key bool logic
            //Have door non trigger then enable trigger here?
        }
    }

}
