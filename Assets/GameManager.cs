using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject panel;
	public Text time;

	public bool running = false;
	private float lastReset;

	private void Update ( ) {
		if (running) {
			time.text = "" + Math.Round(Time.time - lastReset, 2);
		}
	}

	public void StartGame ( ) {
		running = true;
		lastReset = Time.time;

		panel.SetActive(false);
	}

	public void EndGame ( ) {
		running = false;

		panel.SetActive(true);
	}
}
