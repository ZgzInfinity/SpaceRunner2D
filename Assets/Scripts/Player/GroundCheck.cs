
/*
 * -----------------------------------------
 * -- Project: Endless Runner 2D -----------
 * -- Author: Rubén Rodríguez Estebban -----
 * -- Date: 98/10/2021 ---------------------
 * -----------------------------------------
 */

using UnityEngine;

/*
 * Script that controls the contact between the
 * player and the ground of the scene
 */

public class GroundCheck : MonoBehaviour
{
    // Controls if the player is in contact with the ground
    public bool isGrounded;

    // Sent each frame where another object is within a trigger collider attached to this object
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Checks if the player is not colliding with the ground
        if (collision.CompareTag("Ground"))
        {
            // Collides
            isGrounded = true;
        }
    }

    // Sent when another object leaves a trigger collider attached to this object
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if the player is not colliding with the ground
        if (collision.CompareTag("Ground"))
        {
            // Does not collide
            isGrounded = false;
        }
    }

}
