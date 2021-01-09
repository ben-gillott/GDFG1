using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; 
    public float speedModifier;
    public float maxSpeed;
    void Start() { 
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate() 
    { 
        Move(); 
    } 
    
    void Move() { 
        float x_movement = Input.GetAxisRaw("Horizontal"); 

        if (rb.velocity.magnitude < maxSpeed){
            Vector2 movement = new Vector2(x_movement*speedModifier, 0);
            rb.AddForce(movement);
        }
    }
}
