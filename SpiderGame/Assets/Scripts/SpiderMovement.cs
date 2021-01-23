using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{

    public float patrolY;
    public float patrolMinX;
    public float patrolMaxX;
    public float patrolStartX;
    
    public float patrolSpeed;
    public float chaseSpeed;
    public float returnSpeed;

    public float chaseDistance;
    public float killDistance;
    
    public Transform player;


    private float distance = 100; //Start default
    private string state = "Patrol";
    private int patrolDirection = 1;

    // States:
    // Patrol - change x pos on the line by patrolSpeed
    // Chase - move chaseSpeed towards player
    // Return - move y up to nearest track point by returnSpeed
    // Kill - trigger kill event (TBD) - not a full state but a result

    // Transitions:
    // Patrol -> Chase : if (distance < hearable distance) && $$playerVelocity > 0
    // Chase -> Kill : If dist < killDist
    // Chase -> Return : if player velocity <= 0 (add slight delay?)
    // Return -> Patrol : if spiderY ~= patrolY
    // Return -> Chase : (same as Patrol -> Chase)

    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(patrolStartX, patrolY, this.transform.position.z);
    }

    void Update()
    {
        float nextX = this.transform.position.x;
        float nextY = this.transform.position.y;
        //distance = //TODO:

        switch(state){
            case "Patrol":
                //Move along the patrol line
                nextX = this.transform.position.x + patrolSpeed * patrolDirection * Time.deltaTime;
                
                //If beyond either bound switch direction
                if (this.transform.position.x > patrolMaxX){
                    patrolDirection = -1;
                }else if (this.transform.position.x < patrolMinX){
                    patrolDirection = 1;
                }

                //Patrol -> Chase - if (distance < hearable distance) && $$playerVelocity > 0
                //if (distance < chaseDistance){

                //}
                break;
            case "Chase":
                // Chase - move chaseSpeed towards player
                // Chase -> Kill : If dist < killDist
                // Chase -> Return : if player velocity <= 0 (add slight delay?)
                break;
            case "Return":
                // Return - move y up to nearest track point by returnSpeed
                // Return -> Patrol : if spiderY ~= patrolY
                // Return -> Chase : (same as Patrol -> Chase)
                break;
            default:
                //Sth wrong
                break;
        }
        this.transform.position = new Vector3(nextX, nextY, this.transform.position.z);
    }
}
