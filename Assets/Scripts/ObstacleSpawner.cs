using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
	private GameManager gameManager; // The game manager object
	private float timeMod; // The time modifier that makes the spawn time less and less over time
	private float lastSpawnTime; // The last time obstacles were spawned
	private float lastModTime; // The last time the time modifier was increased

	[SerializeField] private GameObject obstaclePrefab; // The obstacle prefab
	[Space]
	[SerializeField] private float timer; // The time between each spawn of obstacles
	public float startTime; // The time that the game was started

	private void Start ( ) {
		gameManager = FindObjectOfType<GameManager>( ); // Instantiate the game manager object
	}

	private void Update ( ) {
		if (gameManager.running) { // If the game is running
			if (Time.time - lastModTime >= timer * 2 && timeMod <= 0.8f) { // If it is time to increase the time modifier
				timeMod += 0.01f; // Increase the time modifier (make the spawning quicker)

				lastModTime = Time.time;
			}

			if (Time.time - lastSpawnTime + timeMod >= timer) { // If it is time to spawn anther obstacle
				int count = Random.Range(1, 5); // Get a random number of obstacles to spawn

				for (int i = 0; i < count; i++) { // Spawn all the obstacles
					Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
				}

				lastSpawnTime = Time.time;
			}
		}
	}

	public void ResetObject ( ) { // Called whenever the game is started
		lastSpawnTime = Time.time;
		startTime = Time.time;
		timeMod = 0;

		GetComponent<Rigidbody>( ).angularVelocity = Random.insideUnitSphere; // Give the object a random rotation
	}
}
