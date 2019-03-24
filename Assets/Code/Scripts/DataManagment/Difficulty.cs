using UnityEngine;
using System.Collections;

public static class Difficulty {

	public static float receivedDamageModifier = 1.0f;
	public static float dealtDamageModifier = 1.0f;

	public static void SetDifficulty(string difficulty){
		if (difficulty == "Very Easy") {
			receivedDamageModifier = 0.5f;
			dealtDamageModifier = 1.5f;
		}
		if (difficulty == "Easy") {
			receivedDamageModifier = 0.75f;
			dealtDamageModifier = 1.25f;
		}
		if (difficulty == "Medium") {
			receivedDamageModifier = 1.0f;
			dealtDamageModifier = 1.0f;
		}
		if (difficulty == "Hard") {
			receivedDamageModifier = 1.25f;
			dealtDamageModifier = 0.75f;
		}
		if (difficulty == "Very Hard") {
			receivedDamageModifier = 1.5f;
			dealtDamageModifier = 0.5f;
		}
	}
}
