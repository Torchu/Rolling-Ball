using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiltScript : MonoBehaviour
{
    private Touch touch;


    private float rotationX, rotationZ;

    private float tiltSpeedModifier = 5f;

    // Variable to be set to true if you win
	static bool youWin;

    // Reference to WinText game object to control its appearance
	// Text game object can be added in inspector because of [SerializeField] line
	[SerializeField]
	GameObject winText;

    private void Start() {

        // Turn WinText off at the start
		winText.gameObject.SetActive(false);

        // You don't win at the start
		youWin = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 tilt = Input.acceleration;

        rotationX = -tilt.x * tiltSpeedModifier;
        transform.rotation *= Quaternion.Euler(rotationX, 0f, 0f);
        
        rotationZ = -tilt.y * tiltSpeedModifier;
        transform.rotation *= Quaternion.Euler(0f, 0f, rotationZ);

        // If you win
		if (youWin) {

			// then turn YouWin sign on
			winText.gameObject.SetActive (true);

			// Restart scene to play again in 2 seconds
			Invoke ("RestartScene", 2f);
		}
    }

    // Method is invoked by exit hole game object when ball touches its collider
	public static void setYouWinToTrue()
	{
		youWin = true;
	}

    // Method to restart current scene
	void RestartScene()
	{
		SceneManager.LoadScene ("SampleScene");
	}
}