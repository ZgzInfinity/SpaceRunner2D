
/*
 * -----------------------------------------
 * -- Project: Endless Runner 2D -----------
 * -- Author: Rubén Rodríguez Estebban -----
 * -- Date: 98/10/2021 ---------------------
 * -----------------------------------------
 */

using UnityEngine;

/*
 * Script that implements the lateral displacement
 * of the camera on the x-axis
 */

public class CameraFollow2D : MonoBehaviour
{
    // Reference to the player's position
    public Transform target;

    // Offset between player and camera position
    public float horizontalOffset = 3f;

    // Camera position update at the end of each frame
    private void LateUpdate()
    {
        // Calculation of the new camera position based on the player
        float followPosX = target.position.x + horizontalOffset;

        // Updates the position
        transform.position = new Vector3(followPosX, transform.position.y, transform.position.z);
    }
}
