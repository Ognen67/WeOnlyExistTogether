using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody2D rb;
    public float destroyTime;
    private float timer1;
    private float timer2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlatformManager.Instance.StartCoroutine("SpawnPlatform",
                new Vector2(transform.position.x, transform.position.y));
            Destroy(gameObject, 2f);
        }
    }

}
