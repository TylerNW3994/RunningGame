using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour {
	public TMP_Text scoreText;

	private int score = 100;

	// Start is called before the first frame update.
	void Start() {
		UpdateScoreUI();
	}

	public void SetScore(int points) {
		score = points;
		UpdateScoreUI();
	}

	public int GetScore() { return score; }

	// Updates the text display to show the current score.
	void UpdateScoreUI() {
		scoreText.text = "Score: " + score.ToString();
	}
}
