using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreModifier : MonoBehaviour {
	[SerializeField] private string operatorSymbol = "";
	[SerializeField] private int modifierValue = 0;
	[SerializeField] private Material HappyMaterial;
	[SerializeField] private Material BadMaterial;

	void Awake() {
		Operators = new Dictionary<string, OperatorInfo> {
			{
				"+", new OperatorInfo {
					Numbers = new List<int> { 10, 20, 30 },
					Operation = (currentScore, value) => currentScore + value,
					Mat = HappyMaterial
				}
			},
			{
				"-", new OperatorInfo {
					Numbers = new List<int> { 10, 20, 30 },
					Operation = (currentScore, value) => currentScore - value,
					Mat = BadMaterial
				}
			},
			{
				"*", new OperatorInfo {
					Numbers = new List<int> { 0, 1, 2, 3 },
					Operation = (currentScore, value) => currentScore * value,
					Mat = HappyMaterial
				}
			},
			{
				"/", new OperatorInfo {
					Numbers = new List<int> { 1, 2, 3 },
					Operation = (currentScore, value) => currentScore / value,
					Mat = BadMaterial
				}
			}
		};
		AssignOperation();
	}

	/// <summary>
	/// Assigns a new Operation.
	/// </summary>
	public void AssignOperation() {
		System.Random random = new();
		List<string> keys = Operators.Keys.ToList();
		operatorSymbol = keys[random.Next(keys.Count)];

		if (Operators.TryGetValue(operatorSymbol, out var operatorInfo)) {
			int randomIndex = random.Next(operatorInfo.Numbers.Count);
			modifierValue = operatorInfo.Numbers[randomIndex];

			Renderer planeRenderer = GetComponent<Renderer>();
			planeRenderer.material = operatorInfo.Mat;
		}
	}

	/// <summary>
	/// Applies the stored operation to the given score and returns the result.
	/// </summary>
	public float ApplyScoreModifier(float currentScore) {
		if (Operators.TryGetValue(operatorSymbol, out var operatorInfo)) {
			return operatorInfo.Operation(currentScore, modifierValue);
		}
		else {
			Debug.LogWarning($"Unknown operator '{operatorSymbol}'");
			return currentScore;
		}
	}

	/// <summary>
	/// Returns the modifier as a formatted string.
	/// </summary>
	public string GetModifierString() {
		return $"{operatorSymbol}{modifierValue}";
	}

	private class OperatorInfo {
		public List<int> Numbers { get; set; }
		public Func<float, float, float> Operation { get; set; }
		public Material Mat { get; set; }
	}

	private static Dictionary<string, OperatorInfo> Operators = new();
}
