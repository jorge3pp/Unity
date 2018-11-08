using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {


    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
    private Rigidbody rb;
    float horizontalInput;
    float verticalInput;
    bool canJump;

    //variables
    public float Movement = 1;
    public float Jump = 1;
    public float Rotation = 1;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {

        var horizontalInput = Input.GetAxis("Horizontal") * Movement;
        var verticalInput = Input.GetAxis("Vertical") * Movement;

        rb.AddForce(horizontalInput, rb.velocity.y, verticalInput);

        if(Input.GetKeyUp(KeyCode.Space) && canJump)
        {
            rb.AddForce(0, Jump,0,ForceMode.Impulse );
            canJump = false;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, Rotation, 0);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -Rotation, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
