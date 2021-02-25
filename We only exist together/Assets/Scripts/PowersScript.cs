using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersScript : MonoBehaviour
{
    private CharacterController2D controller2D;
    private MovementScript movement;
    private Rigidbody2D rb;
    private ClimbScript collision;

    private Animator animator;

    public Sprite skin1;
    public Sprite skin2;
    public Sprite skin3;
    public Sprite skin4;

    public int persona=0;
    public int jumpCount = 1;
    public bool canDash = false;
    public bool canClimb = false;
    public bool canGlide = false;

    private void Start()
    {
        movement = GetComponent<MovementScript>();
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<ClimbScript>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown("1") || persona == 1)
        {
            persona = 1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = skin1;
            jumpCount = 0;
            canDash = false;
            canClimb = false;
            canGlide = true;
            animator.SetBool("IsPersona1", true);
            animator.SetBool("IsPersona2", false);
            animator.SetBool("IsPersona3", false);
            animator.SetBool("IsPersona4", false);
            
        }
        if (Input.GetKeyDown("2") || persona == 2)
        {
            persona = 2;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = skin2;
            jumpCount = 2;
            canDash = false;
            canClimb = false;
            canGlide = false;
            rb.gravityScale = 3;
            animator.SetBool("IsPersona1", false);
            animator.SetBool("IsPersona2", true);
            animator.SetBool("IsPersona3", false);
            animator.SetBool("IsPersona4", false);
        }
        if (Input.GetKeyDown("3") || persona == 3)
        {
            persona = 3;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = skin3;
            jumpCount = 0;
            canDash = true;
            canClimb = false;
            canGlide = false;
            rb.gravityScale = 3;
            animator.SetBool("IsPersona1", false);
            animator.SetBool("IsPersona2", false);
            animator.SetBool("IsPersona3", true);
            animator.SetBool("IsPersona4", false);
        }
        if (Input.GetKeyDown("4") || persona == 4)
        {
            persona = 4;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = skin4;
            jumpCount = 0;
            canDash = false;
            canClimb = true;
            canGlide = false;
            if(!collision.onWall)
            {
                rb.gravityScale = 3;
            }
            animator.SetBool("IsPersona1", false);
            animator.SetBool("IsPersona2", false);
            animator.SetBool("IsPersona3", false);
            animator.SetBool("IsPersona4", true);
        }
    }

    
}
