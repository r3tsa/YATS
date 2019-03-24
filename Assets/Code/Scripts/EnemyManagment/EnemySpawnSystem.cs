using UnityEngine;
using System.Collections;

public class EnemySpawnSystem : MonoBehaviour {

	public Rigidbody [] enemyPrefab;

	public float timerMax = 3.0f;
	public float timer = 0.0f;
	//private int levelNumber = 0;

	// Use this for initialization
	void Start () {
		timer = timerMax;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameData.currentLevel == 1)
			timerMax = 1.25f;
		if (GameData.currentLevel == 0)
			timerMax = 3.0f;
	}

	public void SpawnEnemy()
	{
//		Rigidbody enemyInstance;
		Vector3 spawnPosition = new Vector3 (
			Random.Range(StaticMethods.Boundary.xMin + 1.5f, StaticMethods.Boundary.xMax - 1.5f),
			0,
			StaticMethods.Boundary.zMax + 1.5f
			);
		Instantiate(enemyPrefab[GameData.currentLevel], spawnPosition, enemyPrefab[GameData.currentLevel].rotation);
		GameData.enemiesSpawned += 1;
	}
}
