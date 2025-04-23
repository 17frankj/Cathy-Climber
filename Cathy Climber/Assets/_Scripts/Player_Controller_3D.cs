using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Player_Controller_3D : MonoBehaviour
{
    private Rigidbody rb;

    // movenment
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 1;

    // Jumping
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float groundDistance = 1f; // check distance for ground
    [SerializeField] private LayerMask groundLayer;  // mask to detect ground
    [SerializeField] private Transform foot; // foot of player

    // animation stuff
    [SerializeField] private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
        PlayerJumping();
        UpdatePlayerRotation();
        RunAnimation();
    }

    void FixedUpdate()
    {
        
    }

    private void UpdatePlayerRotation()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed; // A/D keys
        // Only update rotation if there's input
        if (horizontal != 0)
        {
            // Rotate the player based on horizontal input (left or right)
            float rotationAmount = horizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationAmount, 0);
        }
    }

    private void PlayerMoving()
    {
        float vertical = Input.GetAxis("Vertical") * speed; // W/S keys

        Vector3 forwardDirection = transform.forward;

        rb.linearVelocity = new Vector3(forwardDirection.x * vertical, rb.linearVelocity.y, forwardDirection.z * vertical);
    }

    private void PlayerJumping()
    {
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            //Debug.Log("Jump Pressed");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    private bool isGrounded()
    {
        Debug.DrawRay(foot.position, Vector2.down * groundDistance, Color.green);
        return Physics.Raycast(foot.position, Vector2.down, groundDistance);
    }

    // run animation
    private void RunAnimation()
    {
        // player standing still
        if((rb.linearVelocity.magnitude < 0.1f) && isGrounded())
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
        }
        // player running on ground
        else if((rb.linearVelocity.magnitude > 0.1f) && isGrounded())
        {
            // player on ground and running 
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", true);
            
        }
        // player in air but running
        else
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
        }
    }
}
