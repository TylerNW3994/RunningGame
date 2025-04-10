using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextController : MonoBehaviour
{
	public TextMeshPro planeTextPro;
	private ScoreModifier scoreModifier;
	void Start() {
		scoreModifier = GetComponent<ScoreModifier>();
		if (scoreModifier == null) {
			Debug.LogError("ModifierGenerator component not found on the plane!");
			return;
		}

		// If the planeText isn’t assigned in the Inspector, search in children.
		if (planeTextPro == null) {
			planeTextPro = GetComponentInChildren<TextMeshPro>();
			if (planeTextPro == null) {
				Debug.LogError("TextMeshProUGUI component not found in children!");
				return;
			}
		}
		//Debug.Log(scoreModifier.GetModifierString());

		planeTextPro.text = scoreModifier.GetModifierString();
	}
}
