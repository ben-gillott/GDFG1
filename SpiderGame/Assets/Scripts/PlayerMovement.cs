using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; 
    public Animator animator;
    public float speedModifier;
    public float maxSpeed;
    private bool facingRight = true;

    void Start() { 
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate() 
    { 
        animator.SetFloat("Speed", rb.velocity.magnitude);
        Move(); 
    } 
    
    void Move() { 
        
        float x_movement = Input.GetAxisRaw("Horizontal"); 

        //Player Movement. Check for horizontal movement
        if (x_movement > 0.2f || x_movement < -0.2f) 
        {
            // transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            if (x_movement > 0.2f && !facingRight) {
                //If we're moving right but not facing right, flip the sprite and set     facingRight to true.
                animator.transform.Rotate(0, 180, 0);
                facingRight = true;
            } 
            else if (Input.GetAxisRaw("Horizontal") < 0.5f && facingRight) {
                //If we're moving left but not facing left, flip the sprite and set facingRight to false.
                animator.transform.Rotate(0, 180, 0);
                facingRight = false;
            }
        }

        if (rb.velocity.magnitude < maxSpeed){
            Vector2 movement = new Vector2(x_movement*speedModifier, 0);
            rb.AddForce(movement);
        }
    }
}
