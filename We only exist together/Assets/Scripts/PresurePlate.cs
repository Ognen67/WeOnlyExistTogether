using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private DoorTrigger door;
    float timer;
    public float TimeOfTimer;

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorTrigger>();

    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f) {
                door.CloseDoor();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player") {
            door.OpenDoor();
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {

            timer = TimeOfTimer;
        }
    }
}
