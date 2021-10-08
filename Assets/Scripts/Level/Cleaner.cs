
/*
 * -----------------------------------------
 * -- Project: Endless Runner 2D -----------
 * -- Author: Rubén Rodríguez Estebban -----
 * -- Date: 98/10/2021 ---------------------
 * -----------------------------------------
 */

using UnityEngine;

/*
 * Script that clears the game objects once they
 * they are out of the scene
 */

public class Cleaner : MonoBehaviour
{
    // Sent when another object enters a trigger collider attached to this object 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destruction of the object with which the collision occurred
        Destroy(collision.gameObject);
    }
}
