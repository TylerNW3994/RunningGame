using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawnController : MonoBehaviour {
    public GameObject gates;

	public float spawnInterval = 5f;

	void Start() {
		StartCoroutine(SpawnRoutine());
	}

	IEnumerator SpawnRoutine() {
		while (true) {
			Instantiate(gates, transform.position, transform.rotation);

			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
