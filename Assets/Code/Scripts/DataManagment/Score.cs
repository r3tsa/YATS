using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	public static Dictionary<string, float> values = new Dictionary<string, float>()
	{
		{"Enemy1", 10 * Difficulty.receivedDamageModifier},
		{"Enemy2", 20 * Difficulty.receivedDamageModifier}
	};	
}
