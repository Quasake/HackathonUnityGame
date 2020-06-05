using UnityEngine;

public class Obstacle : MonoBehaviour {
	private void Start ( ) {
		ObstacleSpawner obstacleSpawner = FindObjectOfType<ObstacleSpawner>( ); // The obstacle spawner object

		GetComponent<Rigidbody>( ).angularVelocity = Random.insideUnitSphere; // Give the obstacle a random rotation direction
		GetComponent<Rigidbody>( ).velocity = RandomDirection(Mathf.Sqrt(Time.time - obstacleSpawner.startTime)); // Give the obstacle a random velocity direction based on the time elapsed

		Destroy(gameObject, 10f); // Set this obstacle to destroy itself after 10 seconds
	}

	private Vector3 RandomDirection (float value) { // Gets a random direction for the obstacle to travel in
		float randomAngle = Random.Range(0, 360); // Get a random angle

		float x = Mathf.Cos(Mathf.Deg2Rad * randomAngle) * value; // Calculate that angle's values on a circle
		float z = Mathf.Sin(Mathf.Deg2Rad * randomAngle) * value;

		return new Vector3(x, 0f, z); // Return the velocity
	}
}
