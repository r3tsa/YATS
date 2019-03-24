using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
	[System.NonSerialized]
	public int playerLives = 3;
	[System.NonSerialized]
	public float score;
	[System.NonSerialized]
	public float playerMaxHealth = 100.0f;
	[System.NonSerialized]
	public float playerCurrentHealth;
	public static string playerName = "Enter your name";
	public static float sVolume = 1.0f;
	public static bool showFPS = false;
	public static int enemiesSpawned = 0;
	public static int enemiesDestroyed = 0;
	public static int weaponLevel = 1;
	public static int currentLevel = 0;



	void Start ()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	void Update()
	{
		if (playerCurrentHealth <= 0)
			playerCurrentHealth = playerMaxHealth;

		if (Input.GetKeyDown (KeyCode.F1))
			showFPS = !showFPS;

	}

	public void AddScore(float value)
	{
		score += value;
	}

}