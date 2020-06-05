using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	private System.Random random;
	
	private void Start ( ) {
		ObstacleSpawner os = FindObjectOfType<ObstacleSpawner>( );
		random = new System.Random( );

		GetComponent<Rigidbody>( ).angularVelocity = Random.insideUnitSphere;
		GetComponent<Rigidbody>( ).velocity = RandomDirection(Mathf.Sqrt(Time.time - os.startTime));

		Destroy(gameObject, 10f);
	}

	private Vector3 RandomDirection (float value) {
		float randomAngle = Random.Range(0, 360);

		float x = Mathf.Cos(Mathf.Deg2Rad * randomAngle) * value;
		float z = Mathf.Sin(Mathf.Deg2Rad * randomAngle) * value;

		return new Vector3(x, 0f, z);
	}
}
