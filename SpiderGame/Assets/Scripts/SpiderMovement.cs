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
    public float killDistance;
    
    public Transform player;

    private float distance; //Start default
    private string state;

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
        distance = 1000;//euclidian dist
        state = "Patrol";
        this.transform.position = new Vector3(patrolMaxX, patrolY, this.transform.position.z);
        
    }

    void Update()
    {
        // this.transform.position = new Vector3(curX, this.transform.position.y, this.transform.position.z);
    }
}
