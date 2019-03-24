using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private GameData gameDataRef;

	void Start ()
	{
		gameDataRef = GameObject.Find("GameManager").GetComponent<GameData>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			gameDataRef.playerLives -= 1;
			Destroy(other.gameObject);
		}
	}
}
