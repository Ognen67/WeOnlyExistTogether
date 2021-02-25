using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    private CharacterController2D controller2D;
    private Animator animator;
    private Transform playerTrans;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    public float runSpeed = 40f;
    

    private bool jump = false;
    private bool crouch = false;

    private PowersScript powers;

    //climb
    public float climbSpeed = 50f;
    public bool wallGrab = false;
    private ClimbScript collision;
    private Rigidbody2D m_Rigidbody2D;

    //Dash
    public float dashCoolDown = 2f;
    float nextDashTime = 0f;
    public float dashSpeed;
    float dashTime;
    public float startDashTime;
    public GameObject dashParticleRight;
    public GameObject dashParticleLeft;

    //Gliding
    public bool IsGliding;
    public float m_FallSpeed=0f;
    
    private AudioManager audioManager;
    private AudioSource source;
    public bool isMoving;


    private void Start()
    {
        collision = GetComponent<ClimbScript>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        powers = GetComponent<PowersScript>();
        controller2D = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        audioManager = GetComponent<AudioManager>();
        source = GetComponent<AudioSource>();
        playerTrans = GetComponent<Transform>();
        dashTime = startDashTime;
    }

    void Update()
    {


        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
 

        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if (horizontalMove == 0)
        {
            animator.SetBool("IsIdle", true);
        }
        else {
            animator.SetBool("IsIdle",false);
        }

        if ((m_Rigidbody2D.velocity.x > 0.01 || m_Rigidbody2D.velocity.x < -0.01) && controller2D.m_Grounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving)
        {
            if(!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            source.Stop();
        }

       


        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
       

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        // Climb 
        if (powers.canClimb)
        {
            verticalMove = Input.GetAxis("Vertical") * climbSpeed;


            if (collision.onWall == true && Input.GetKeyDown(KeyCode.X))
            {
                wallGrab = true;
                //FindObjectOfType<AudioManager>().Play("Climb");
                
            }
            if (!collision.onWall == true || Input.GetKeyUp(KeyCode.X))
            {
                wallGrab = false;
                //FindObjectOfType<AudioManager>().Stop("Climb");
                
            }
            if (wallGrab)
            {
                m_Rigidbody2D.gravityScale = 0f;
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, verticalMove);
                animator.SetFloat("IsClimbing", Mathf.Abs(verticalMove));

            }
            else
            {
                
                m_Rigidbody2D.gravityScale = 3f;
                //FindObjectOfType<AudioManager>().Stop("Climb");
               
            }
           
        }
        animator.SetBool("HoldingOnWall", wallGrab);
        //Dash

        if (Time.time > nextDashTime)
        {
           
            if (Input.GetKeyDown(KeyCode.X) && powers.canDash == true)
            {
                if (dashTime <= 0)
                {
                    dashTime = startDashTime;
                    m_Rigidbody2D.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if (controller2D.m_FacingRight)
                    {
                        animator.SetBool("Dash", true);
                        m_Rigidbody2D.velocity = Vector2.right * dashSpeed;
                        FindObjectOfType<AudioManager>().Play("Dash");
                        Instantiate(dashParticleRight, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        animator.SetBool("Dash", true);
                        m_Rigidbody2D.velocity = Vector2.left * dashSpeed;
                        FindObjectOfType<AudioManager>().Play("Dash");
                        Instantiate(dashParticleLeft, transform.position, Quaternion.identity);

                    }
                }
                nextDashTime = Time.time + dashCoolDown;
                animator.SetBool("Dash", false);
            }
            
        }

        //Glide
        if (IsGliding && m_Rigidbody2D.velocity.y < 0f && Mathf.Abs(m_Rigidbody2D.velocity.y) > m_FallSpeed) {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, Mathf.Sign(m_Rigidbody2D.velocity.y) * m_FallSpeed);
        }
        if (controller2D.m_Grounded == false && powers.canGlide)
        {
             if (Input.GetKeyDown(KeyCode.X))
             {
                StartGliding();
                FindObjectOfType<AudioManager>().Play("Glide");

            }
             if (Input.GetKeyUp(KeyCode.X))
             {
                StopGliding();
                FindObjectOfType<AudioManager>().Stop("Glide");
            }
        }
        else
        {
            StopGliding();
            FindObjectOfType<AudioManager>().Stop("Glide");
        }
        //move
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsGliding", false);
    }
    private void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void StartGliding()
    {
        IsGliding = true;
        animator.SetBool("IsGliding", true);
    }

    public void StopGliding()
    {
        IsGliding = false;
    }
}
