using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed ; // Sets the movement speed of the player to 5

    public Rigidbody2D rb; // Links the rigidbody from the player
    public Animator animator; // Links the animator 

    Vector2 movement; // Stores an x and y

    

    // Update is called once per frame
    void Update() // Registering Input
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // Returns the value of the horizontal virtual axis 
        movement.y = Input.GetAxisRaw("Vertical"); // Returns the value of the vertical virtual axis 

        animator.SetFloat("Horizontal", movement.x); // Send float values to animator
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate() // Used for physics
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // FDeltaTime relates to seconds at which physics are performed
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cans"))
        {
            Destroy(other.gameObject);
        }
    }
}
