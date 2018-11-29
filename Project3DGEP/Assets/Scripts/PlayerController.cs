using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
    public Text countText;
	public Text winText;
    public Text timeText;
    public Canvas gameOver;

    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
    private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

        gameOver.gameObject.SetActive(false);

		// Set the count to zero 
		count = 0;
        
        // Run the SetCountText function to update the UI (see below)
        SetCountText ();

        // Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winText.text = "";
        timeText.text = "";
    }

	// Each physics step..
	void FixedUpdate ()
	{
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Set the text value of our 'winText'
            winText.text = "You Lost!";
            float tiempo = Time.realtimeSinceStartup;
            timeText.text = "Time: " + tiempo + " seconds";
            gameOver.gameObject.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Counts: " + count.ToString ();

        // Check if our 'count' is equal to or exceeded 12
        if (count >= 28)
        {
            // Set the text value of our 'winText'
            winText.text = "You Win!";
            float tiempo = Time.realtimeSinceStartup;
            timeText.text = "Time: " + tiempo + " seconds";
        }
	}
    
}
 