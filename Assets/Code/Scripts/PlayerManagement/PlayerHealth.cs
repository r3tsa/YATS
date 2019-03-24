using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private GameData gameDataRef;

	// Use this for initialization
	void Start () {
		gameDataRef = GameObject.Find("GameManager").GetComponent<GameData>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameDataRef.playerCurrentHealth <= 0)
			gameDataRef.playerLives -= 1;
	}
	public void DealDamage(float value)
	{
		gameDataRef.playerCurrentHealth -= value;
	}
}
