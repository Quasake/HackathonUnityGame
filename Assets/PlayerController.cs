using UnityEngine;

public class PlayerController : MonoBehaviour {
	private GameManager gameManager; // The game manager object
	private float angle; // The angle of the player

	[SerializeField] private GameObject playerPiecePrefab; // The player piece prefab
	[Space]
	[SerializeField] private float radius; // The radius of the player circle
	[SerializeField] private float speed; // The speed of the player

	private void Start ( ) {
		gameManager = FindObjectOfType<GameManager>( ); // Instantiate the game manager object

		GetComponent<Rigidbody>( ).angularVelocity = UnityEngine.Random.insideUnitSphere; // Give the player and random rotation
	}

	private void FixedUpdate ( ) {
		if (gameManager.running) { // If the game is running
			angle += Input.GetAxisRaw("Horizontal") * speed; // Get the player's input

			float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius; // Calculate the player's position based on the angle
			float z = -Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

			transform.position = new Vector3(x, transform.position.y, z); // Set the player's position
		}
	}

	private void OnCollisionEnter (Collision collision) { // Called when an object collides with another object
		if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles") && gameManager.running) { // If the object that the player collides with is an obstacle
			gameManager.EndGame( ); // End the game

			for (int i = 0; i < 10; i++) { // Spawn in the player pieces
				Instantiate(playerPiecePrefab, transform.position, Quaternion.identity);
			}
		}
	}
}
