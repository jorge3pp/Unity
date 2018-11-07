using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class SquisherController : MonoBehaviour {
    
    // Create public variables for player speed, and for the Text UI game objects
    public float cameraSpeed;
    public GameObject ballPrefab;
    public Transform ballSpawn;

    public float fireRate;

    private float nextFire;



    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
    private Rigidbody rb;

    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        nextFire = 0.0f;
        
        //Fire cadence
        fireRate = 1.0f;
    }

    // Each physics step..
    void FixedUpdate()
    {
        // Set some local float variables equal to the value of our Horizontal and Vertical Inputs
        float moveHorizontal = Input.GetAxis("HorizontalP2");
        float moveVertical = Input.GetAxis("VerticalP2");

        if (Input.GetKeyDown(KeyCode.Space) && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }

        // Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //2 Different methods to move the camera

        //rb.AddForce(movement*cameraSpeed);

        rb.velocity = movement * cameraSpeed;
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var ball = (GameObject)Instantiate(
            ballPrefab,
            ballSpawn.position,
            ballSpawn.rotation);

        // Add velocity to the bullet
        ball.GetComponent<Rigidbody>().velocity = ball.transform.up * -10;

        // Destroy the bullet after 2 seconds
        Destroy(ball, 3.0f);
    }

}
