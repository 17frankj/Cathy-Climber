using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Player_Controller_3D : MonoBehaviour
{
    private Rigidbody rb;

    // movenment
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float rotationSpeed = 1;

    // Jumping
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float groundDistance = 1f; // check distance for ground
    [SerializeField] private LayerMask groundLayer;  // mask to detect ground
    [SerializeField] private Transform foot; // foot of player

    //slopes
    public float maxSlopeAngle;
    public Transform orientation;
    Vector3 moveDirection;
    public float angle;
    private RaycastHit slopeHit;

    // animation stuff
    [SerializeField] private Animator anim;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        air
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        StateHandler();
        PlayerMoving();
        PlayerJumping();
        UpdatePlayerRotation();
        RunAnimation();
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
        if(OnSlope() && angle > 60)
        {
            speed = 1f;
        }

        float vertical = Input.GetAxis("Vertical") * speed; // W/S keys

        Vector3 forwardDirection = transform.forward;

        // on ground
        if(isGrounded())
        {
            rb.linearVelocity = new Vector3(forwardDirection.x * vertical, rb.linearVelocity.y, forwardDirection.z * vertical);
        }
    }

    private void PlayerJumping()
    {
        if(Input.GetButtonDown("Jump") && isGrounded() && angle < 60)
        {
            //anim.SetBool("isJumping", true);
            //Debug.Log("Jump Pressed");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    private bool isGrounded()
    {
        Debug.DrawRay(foot.position, Vector2.down * groundDistance, Color.green);
        return Physics.Raycast(foot.position, Vector2.down, groundDistance);
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit))
        {
            angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        moveDirection = orientation.forward * Input.GetAxisRaw("Vertical") + orientation.right * Input.GetAxisRaw("Horizontal");
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    private void StateHandler()
    {
        //sprinting
        if(isGrounded() && Input.GetKey(KeyCode.LeftShift))
        {
            state = MovementState.sprinting;
            speed = sprintSpeed;
        }

        //walking
        else if(isGrounded())
        {
            state = MovementState.walking;
            speed = walkSpeed;
        }

        // air
        else
        {
            state = MovementState.air;
        }
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
        else if((rb.linearVelocity.x > 0.1f) || (rb.linearVelocity.z > 0.1f) && isGrounded())
        {
            // player on ground and running 
            //anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", true);
        }
        
        /*
        // player in air 
        else
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
        }
        */
    }
}
