using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneGroupController : MonoBehaviour {
    private ScoreModifier[] scoreModifiers;
	public float speed = 5f;
	private Rigidbody rb;
	void Start() {
		rb = GetComponent<Rigidbody>();
		scoreModifiers = GetComponentsInChildren<ScoreModifier>();
        ScoreModifier leftScoreMod = scoreModifiers[0];
        ScoreModifier rightScoreMod = scoreModifiers[1];

        while (leftScoreMod.GetModifierString() == rightScoreMod.GetModifierString()) {
            Debug.Log("Rerolled right scoreMod operation");
            rightScoreMod.AssignOperation();
        }
	}

	void Update() {
		rb.velocity = new Vector3(speed, 0f, 0f);
	}
}
