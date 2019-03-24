using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponDamage : MonoBehaviour {

	public static Dictionary<string, float> playerValues = new Dictionary<string, float>()
	{
		{"basicWeapon", 34.0f * Difficulty.dealtDamageModifier}
	};	

	public static Dictionary<string, float> enemyValues = new Dictionary<string, float>()
	{
		{"basicWeapon", 12.0f * Difficulty.receivedDamageModifier}
	};	
}
