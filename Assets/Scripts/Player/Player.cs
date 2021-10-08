
/*
 * -----------------------------------------
 * -- Project: Endless Runner 2D -----------
 * -- Author: Rubén Rodríguez Estebban -----
 * -- Date: 98/10/2021 ---------------------
 * -----------------------------------------
 */

using UnityEngine;

/*
 * Script that controls the movements of the player during the game
 */


public class Player : MonoBehaviour
{
    // Reference to the rigidbody component
    private Rigidbody2D myRigidBody2D;

    // Reference to the animator component
    private Animator myAnimator;

    // Jumping sound effect
    public AudioSource jumpingSound;

    // Get item good sound effect
    public AudioSource itemGoodSound;

    // Get item bad sound effect
    public AudioSource itemBadSound;

    // Identifier of the player run animation
    private string runAnimationName = "Run";

    // Identifier of the player jump animation
    private string jumpAnimationName = "Jump";

    // Controls if the player was jumping in the previous frame
    private bool wasOnAirInLastFrame;

    // Speed of the player in axis x
    public float horizontalSpeed = 2f;

    // Jump force of the player in axis y
    public float jumpForce = 15f;

    // Multiplier factor to multiply the speed of the player
    public float speedIncreaserMultiplier = 2f;

    // Reference to the ground checker component
    public GroundCheck groundCheck;

    // Reference to the game manager
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the components (rigidbody, animator and audioSource)
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        jumpingSound = gameObject.GetComponent<AudioSource>();

        // Sets the animation of the player
        myAnimator.Play(runAnimationName);
    }


    // Update is called once per frame
    void Update()
    {
        // Moves the player horizontally in each frame
        HorizontalMovement();

        // Checks if the player is in the ground
        if (groundCheck.isGrounded)
        {
            // Checks if previousl was jumping
            if (wasOnAirInLastFrame)
            {
                // Changes the jump animation by the run animation
                myAnimator.Play(runAnimationName);
            }
            
            // Controls if the space key is pressed while the player is not jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Player jumps
                Jump();
            }
        }
        // Updates the status of the player in the previous frame
        wasOnAirInLastFrame = !groundCheck.isGrounded;
    }

    // Player runs
    private void HorizontalMovement()
    {
        // Calculates the speed of the player
        myRigidBody2D.velocity = new Vector2(horizontalSpeed, myRigidBody2D.velocity.y);
    }

    // Player jumps
    private void Jump()
    {
        // Reproduces the jump sound
        jumpingSound.Play();

        // Sets the jump animation and updates the speed of the player in axis y 
        myAnimator.Play(jumpAnimationName);
        myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, jumpForce);
    }


    // Sent when another object enters a trigger collider attached to this object 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player is colliding with a good item
        if (collision.CompareTag("ItemGood"))
        {
            // Increases an energy point and destroys the good item
            gameManager.AddEnergyPoints();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("ItemBad"))
        {
            // Decreases an energy point and destroys the bad item
            gameManager.DecreaseEnergyPoints();
            Destroy(collision.gameObject);
        }
        // Checking if the player is colliding with the death zone
        else if (collision.CompareTag("DeathZone"))
        {
            // Sets the game over status
            gameManager.GameOver();
        }
        // Checks if the player has finished the testing level
        else if (collision.CompareTag("SpeedIncreaser"))
        {
            // Increments the speed of the player
            horizontalSpeed *= speedIncreaserMultiplier;
            Destroy(collision.gameObject);
        }
    }

    // Sent when an incoming collider makes contact with this object's collider (2D physics only).
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with a trap
        if (collision.collider.CompareTag("Trap"))
        {
            // Sets the game over status
            gameManager.GameOver();
        }
    }
}
