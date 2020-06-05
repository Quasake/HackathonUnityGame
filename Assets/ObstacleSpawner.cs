using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
	public GameObject obstaclePrefab;
	private GameManager gm;

	public float timer;
	private float lastSpawnTime;
	private float lastModTime;
	private float timeMod;

	public float startTime;

	private void Start ( ) {
		gm = FindObjectOfType<GameManager>( );
	}

	private void Update ( ) {
		if (gm.running) {
			if (Time.time - lastModTime >= timer * 2 && timeMod <= 0.8f) {
				timeMod += 0.01f;

				lastModTime = Time.time;
			}

			if (Time.time - lastSpawnTime + timeMod >= timer) {
				int count = Random.Range(1, 5);

				for (int i = 0; i < count; i++) {
					GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
				}

				lastSpawnTime = Time.time;
			}
		}
	}

	public void ResetObject ( ) {
		lastSpawnTime = Time.time;
		startTime = Time.time;
		timeMod = 0;

		GetComponent<Rigidbody>( ).angularVelocity = Random.insideUnitSphere;
	}
}
