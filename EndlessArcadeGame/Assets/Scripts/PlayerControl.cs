using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private CharacterController controller;
    public GameControlScript control;
    public CountDownScript count;
    public PauseMenuScript pause;
    public AudioSource powerUpCollectSound;
    public AudioSource obstacleCollectSound;
    public AudioSource jumpSound;

    private bool isGrounded = false;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (control.isGameOver)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
        }

        if (controller.isGrounded && count.isCountDown)
        {
            //GetComponent<Animation>().Play("HumanoidRun");            // Play "run" animation if spacebar is not pressed
            //animation.Play("run");
            if (!pause.isPaused)
            {
                gameObject.GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<AudioSource>().enabled = false;
            }

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  // Get keyboard input to move in the horizontal direction
            moveDirection = transform.TransformDirection(moveDirection);  // Apply this direction to the character
            moveDirection *= speed;            // Increase the speed of the movement by the factor "speed" 

            jumpSound.Stop();
            if (Input.GetButton("Jump"))
            {
                // Play "Jump" animation if character is grounded and spacebar is pressed
                // GetComponent<Animation>().Stop("run");
                // GetComponent<Animation>().Play("jump_up");
                jumpSound.Play();
                gameObject.GetComponent<AudioSource>().enabled = false;
                moveDirection.y = jumpSpeed; // Add the jump height to the character
            }
            // Set the flag isGrounded to true if character is grounded
            //isGrounded = true;
        }

        if (pause.isPaused == false)
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
        }

        moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity
        controller.Move(moveDirection * Time.deltaTime);      //Move the controller
	}

    // Check if the character collects the powerups or the obstacles
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Powerup(Clone)")
        {
            powerUpCollectSound.Play();
            control.PowerUpCollected();
        }
        else if (other.gameObject.name == "Obstacle(Clone)")
        {
            obstacleCollectSound.Play();
            control.ObstacleCollected();
        }
        Destroy(other.gameObject);
    }
}
