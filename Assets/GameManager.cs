using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private float lastReset; // The last time that the game was reset

	[SerializeField] private GameObject panel; // The title, the play button, and the background panel
	[SerializeField] private Text time; // The timer in the top left corner
	[Space]
	public bool running = false; // Whether the game is running or not

	private void Update ( ) {
		if (running) { // If the game is running
			time.text = "" + Math.Round(Time.time - lastReset, 2); // Update the timer text to display the current time
		}
	}

	public void StartGame ( ) { // Called when the play button is pressed
		running = true;
		lastReset = Time.time;

		panel.SetActive(false); // Disable the title screen so the actual game is shown
	}

	public void EndGame ( ) { // Called when the player dies
		running = false;

		panel.SetActive(true); // Set the title screen back to visible
	}
}
