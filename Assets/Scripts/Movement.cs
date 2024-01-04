using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // For WalkingSound 
    [Header("-------Walking Sound-------")]
    public float minSpeed;
    public float maxSpeed;
    public AudioSource marbleWalking;
    private float currentSpeed;

    public float minPitch;
    public float maxPitch;
    private float pitchFromMarble;

    //For Horizontal and Vertical Movement
    [Header("-------Horizontal and Vertical Movement-------")]
    public Rigidbody rb;
    public float moveSpeed = 10f;

    private float xInput;
    private float zInput;

    // For JumpSound and movement     
    [Header("-------JumpSound and Jump Movement-------")]
    public AudioSource jumpSound;
    public float jumpForce;

    // For collision the ground 
    private bool isOnGround = true;

    void Start()
    {
        marbleWalking.enabled = true;
        jumpSound.enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /// For Jump Movement
        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
            // If I jump, walkingsound is off, jumpSound is on            
            rb.AddForce(new Vector3(0f, 20f, 0f)* jumpForce);
            marbleWalking.enabled = false;
            jumpSound.enabled = true;
            isOnGround = false;
            moveSpeed = 1.0f;
            
        }

        
    }
    // For Horizontal and Vertical Movement
    void FixedUpdate()
    {   
        // Horizontal and Vertical Movement Inputs

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");      
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);

        // For Marble Walking Sound 
        if (isOnGround == true && !Input.GetButtonDown("Jump"))
        {
            MarbleWalkingSoundTone();
            moveSpeed = 8.0f;
        }               
    }
    

    // Walking SoundTone , If I speed up, to make sound louder

    void MarbleWalkingSoundTone()
    {       
        currentSpeed = rb.velocity.magnitude;
        pitchFromMarble = rb.velocity.magnitude / 10f;

        if(currentSpeed < minSpeed)
        {
            marbleWalking.pitch = minPitch;
        }

        else if (currentSpeed > minSpeed && currentSpeed < maxSpeed)
        {
            marbleWalking.pitch = minPitch + pitchFromMarble;
        }

        else
        {
            marbleWalking.pitch = maxPitch;
        }
    }

    // Collision the ground 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpSound.enabled = false;
            marbleWalking.enabled = true;
            
        }
        // Destroy bullet 
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }

    }

}
