using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScript : MonoBehaviour
{

    public GameObject message1;
    public GameObject message2;
    public GameObject message3;
    public GameObject message4;

    void Start()
    {
        
    }



    void Update()
    {
             
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "popup1")
        {
           message1.gameObject.SetActive(true);
           return;
        }
        if (other.tag == "popup2")
        {
            message2.gameObject.SetActive(true);
            return;
        }
        if (other.tag == "popup3")
        {
            message3.gameObject.SetActive(true);
            return;
        }
        if (other.tag == "popup4")
        {
            message4.gameObject.SetActive(true);
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "popup1")
        {
            message1.gameObject.SetActive(false);
            return;
        }
        if (other.tag == "popup2")
        {
            message2.gameObject.SetActive(false);
            return;
        }
        if (other.tag == "popup3")
        {
            message3.gameObject.SetActive(false);
            return;
        }
        if (other.tag == "popup4")
        {
            message4.gameObject.SetActive(false);
            return;
        }
    }
}
