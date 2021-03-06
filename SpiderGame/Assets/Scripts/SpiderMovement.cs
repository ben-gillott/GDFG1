﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiderMovement : MonoBehaviour
{
    //Event systems
    public delegate void KillAction();
    public static event KillAction OnKill;

    public float patrolY;
    public float patrolMinX;
    public float patrolMaxX;
    public float patrolStartX;
    
    public float patrolSpeed;
    public float chaseSpeed;
    public float returnSpeed;

    public float chaseDistance;
    public float killDistance;
    public float audibleVelocity;
    
    public Rigidbody2D player;

    private string state = "Patrol";
    private int patrolDirection = 1;
    private bool notDeadYet = true;
    public float hoverTime;
    private float hoverElapsedTime = 0;


    void Start()
    {
        notDeadYet = true;
        this.transform.position = new Vector3(patrolStartX, patrolY, this.transform.position.z);
    }
    
    void OnEnable()
    {
        PlayerColliderScript.OnDoorOpen += DoorOpensSpiderState;
    }

    void OnDisable()
    {
        PlayerColliderScript.OnDoorOpen -= DoorOpensSpiderState;
    }

    void DoorOpensSpiderState(){
        state = "PlayerEscaped";
    }



    void Update()
    {
        Vector2 spiderPos = this.transform.position;
        Vector2 playerPos = player.position;
        Vector2 nextPos = new Vector2(spiderPos.x, spiderPos.y);

        float distance = Vector2.Distance(spiderPos, playerPos);

        switch(state){
            case "Patrol":
                //Move along the patrol line
                nextPos.x = spiderPos.x + patrolSpeed * patrolDirection * Time.deltaTime;
                
                //If beyond either bound switch direction
                if (spiderPos.x > patrolMaxX){
                    patrolDirection = -1;
                }else if (spiderPos.x < patrolMinX){
                    patrolDirection = 1;
                }

                //Patrol -> Chase
                if (distance < chaseDistance && player.velocity.magnitude >= audibleVelocity){
                    state = "Chase";
                }
                break;
            case "Chase":
                // Chase - move chaseSpeed towards player
                float step = chaseSpeed * Time.deltaTime;
                nextPos = Vector2.MoveTowards(spiderPos, playerPos, step);
                
                // Chase -> Kill : If dist < killDist
                
                //Chase -> Return
                if (player.velocity.magnitude <= audibleVelocity){
                    hoverElapsedTime = 0f;
                    state = "Hover";
                } else if (distance < killDistance){
                    state = "Kill";
                }
                break;
            case "Hover":
                hoverElapsedTime = hoverElapsedTime + Time.deltaTime;

                if (distance < chaseDistance && player.velocity.magnitude > audibleVelocity){
                    state = "Chase";
                }else if (hoverElapsedTime > hoverTime){
                    state = "Return";
                }
                //Hover
                break;
            case "Return":
                // Return - move y up to nearest track point by returnSpeed
                nextPos.y = spiderPos.y + returnSpeed * Time.deltaTime;

                // Return -> Patrol : if spiderY ~= patrolY
                if (spiderPos.y >= patrolY){
                    nextPos.y = patrolY;
                    state = "Patrol";
                } else if (distance < chaseDistance && player.velocity.magnitude > audibleVelocity){
                    state = "Chase";
                }
                break;
            case "Kill":
                if(OnKill != null && notDeadYet){
                    notDeadYet = false; //Read this in a british accent?
                    OnKill();
                } else if (!notDeadYet){
                    //Already triggered kill event, fade away
                    nextPos.y = spiderPos.y + returnSpeed * Time.deltaTime;
                }
                break;
            case "PlayerEscaped":
                nextPos.y = spiderPos.y + returnSpeed * 5 * Time.deltaTime;
                break;
            default:
                Debug.Log("State does not exist");
                break;
        }
        this.transform.position = new Vector3(nextPos.x, nextPos.y, this.transform.position.z);
    }
}
