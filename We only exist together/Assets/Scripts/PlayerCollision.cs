using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;


    //zoom
    public CinemachineVirtualCamera vcam;
    public float zoomIn = 8f;
    public float zoomOut = 18f;

    // Bounce
    public float bounceForce;
    

    // Platforms
    public float dissapearingTime;

    // Change character 
    private PowersScript powers;
    private readonly int[] arr1 = { 4, 3, 2 };
    private readonly int[] arr2 = { 4, 3, 1 };
    private readonly int[] arr3 = { 4, 2, 1 };
    private readonly int[] arr4 = { 1, 2, 3 };

    // Death particle
    public ParticleSystem deathParticle;
    
    int randomNum;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powers = GetComponent<PowersScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            Debug.Log("Collectable");
            randomNum = Random.Range(1, 4);
            if (powers.persona == 1)
            {
                if (randomNum == 1) {
                   powers.persona = 2;
                }
                if (randomNum == 2)
                {
                    powers.persona = 3;
                }
                if (randomNum == 3)
                {
                    powers.persona = 4;
                }
                
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Collectable");
                return;
            }
            if (powers.persona == 2)
            {
                if (randomNum == 1)
                {
                    powers.persona = 1;
                }
                if (randomNum == 2)
                {
                    powers.persona = 3;
                }
                if (randomNum == 3)
                {
                    powers.persona = 4;
                }
                
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Collectable");
                return;
            }
            if (powers.persona == 3)
            {
                if (randomNum == 1)
                {
                    powers.persona = 1;
                }
                if (randomNum == 2)
                {
                    powers.persona = 2;
                }
                if (randomNum == 3)
                {
                    powers.persona = 4;
                }
                
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Collectable");
                return;
            }
            if (powers.persona == 4)
            {
                if (randomNum == 1)
                {
                    powers.persona = 1;
                }
                if (randomNum == 2)
                {
                    powers.persona = 2;
                }
                if (randomNum == 3)
                {
                    powers.persona = 3;
                }
                
                Destroy(collision.gameObject);
                FindObjectOfType<AudioManager>().Play("Collectable");
                return;
            }
        }

        if(collision.tag == "PressurePlate")
        {
            FindObjectOfType<AudioManager>().Play("PressurePlate");
        }

        if (collision.gameObject.tag == "ZoomIn") {
            vcam.m_Lens.OrthographicSize= zoomIn;
        }
        if (collision.gameObject.tag == "ZoomOut") {
            vcam.m_Lens.OrthographicSize = zoomOut;
        }

       
            
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("ENEMY");
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<GameManager>().EndGame();
            Destroy(this.gameObject);
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            
        }
        if (other.gameObject.tag == "Bouncy")
        {
            rb.velocity = Vector2.up * bounceForce;
            FindObjectOfType<AudioManager>().Play("Bounce");
        }
        
        if(other.gameObject.tag == "Dissapearing")
        {
            Destroy(other.gameObject, dissapearingTime);
            
        }

        if (other.gameObject.tag == "MovingPlatform") {
            this.transform.parent = other.transform;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
    }

}
