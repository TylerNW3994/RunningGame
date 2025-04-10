using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[Header("Movement")]
	public float speed = 5f;
	private Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		float moveZ = Input.GetAxis("Horizontal");
		rb.velocity = new Vector3(0f, 0f, moveZ * speed);
	}
}
