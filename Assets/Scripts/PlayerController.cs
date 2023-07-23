using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


// Include the namespace required to use Unity UI and Input System
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0 ; 
    private Rigidbody rb ;
    private float movementX ;
    private float movementY ;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;
    private int score;
    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Set the count to zero 
		count = 0;
		SetCountText ();
        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
     private void Update()
    {
        // Check if the player's Y-axis position is negative.
        if (transform.position.y < 0 && !gameEnded)
        {
            // Set the gameEnded flag to avoid multiple restarts.
            gameEnded = true;

            // Restart the game by reloading the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnMove(InputValue movementValue)
    {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x ;
            movementY = movementVector.y ;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            
            other.gameObject.SetActive(false);			
            // Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
            RotatingCollectible rotatingCollectible = other.GetComponent<RotatingCollectible>();
            int currentMaterialIndex = rotatingCollectible.GetCurrentMaterialIndex();

             switch (currentMaterialIndex){
                case 0:
                     score+=1 ; 
                    break;
                case 1:
                    score -=1;
                    break;
                case 2:
                    score +=2;
                    speed*=2 ;
                    break;
             }

			SetCountText ();
        }
    }
      void SetCountText()
	{
		countText.text = "Score: " + score.ToString();

		if (count >= 16) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}

	}
}
