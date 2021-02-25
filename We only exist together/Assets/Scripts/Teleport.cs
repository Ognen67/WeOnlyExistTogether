using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Transform Portal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Teleport");
            other.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
            FindObjectOfType<AudioManager>().Play("Teleport");
        }
    }

   
}
