 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed ; // Sets the movement speed of the player to 5

    public Rigidbody2D rb; // Links the rigidbody from the player
    public Animator animator; // Links the animator 

    public bool canMove;

    Vector2 movement; // Stores an x and y

    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update() // Registering Input
    {   
        if (canMove == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal"); // Returns the value of the horizontal virtual axis 
            movement.y = Input.GetAxisRaw("Vertical"); // Returns the value of the vertical virtual axis 

            animator.SetFloat("Horizontal", movement.x); // Send float values to animator
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        else if (canMove == false)
        {
         
            animator.SetFloat("Horizontal", 0); // Send float values to animator
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
        
    }

    void FixedUpdate() // Used for physics
    {
        if (canMove == true)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // FDeltaTime relates to seconds at which physics are performed
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.CompareTag("Cans"))
        {
            Destroy(other.gameObject);
        }
    }
}
