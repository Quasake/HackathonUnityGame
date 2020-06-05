using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private GameManager gm;
	public GameObject playerPiecePrefab;

	private float angle;
	public float radius;
	public float speed;

	private void Start ( ) {
		gm = FindObjectOfType<GameManager>( );

		GetComponent<Rigidbody>( ).angularVelocity = UnityEngine.Random.insideUnitSphere;
	}

	private void FixedUpdate ( ) {
		if (gm.running) {
			angle += Input.GetAxisRaw("Horizontal") * speed;

			float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
			float z = -Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

			transform.position = new Vector3(x, transform.position.y, z);
		}
	}

	private void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles") && gm.running) {
			gm.EndGame( );

			for (int i = 0; i < 10; i++) {
				Instantiate(playerPiecePrefab, transform.position, Quaternion.identity);
			}
		}
	}
}
