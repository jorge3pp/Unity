using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
    
    private Rigidbody rb;
    
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
        
    }

	// Each physics step..
	void FixedUpdate ()
	{
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoorController door = GameObject.Find("DoorPro").GetComponent<DoorController>();
            door.isOpen = !door.isOpen;
            door.Interact();
        }
    }
    
}
 