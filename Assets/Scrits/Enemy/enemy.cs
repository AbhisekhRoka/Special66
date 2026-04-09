using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    // Player Object To Chase
    public GameObject Player;

    // Enemy/mob speed
    public float speed = 0.5f;

    bool playerDetected = false;

    void Update()
    {
        if (playerDetected) {
            // Rotate & Move to player
            Vector3 targetPosition = new Vector3(
            Player.transform.position.x, 
            transform.position.y, 
            Player.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);  
            transform.LookAt(targetPosition);
            }
    }

    void  OnTriggerEnter (Collider  collision) {
        // Detect collision with "Player" tag
        if (collision.gameObject.tag == "Player" ) {
            print ("MUAHAHHAA GOTCHU");
            playerDetected = true;
        }
    }
}

