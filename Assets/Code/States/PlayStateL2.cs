using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class PlayStateL2 : IStateBase
	{
		private StateManager manager;
		private PlayerController playerControllerRef;
		private EnemySpawnSystem enemySpawnSystemRef;
		private GameObject player;
		private ParticleSystem lJet;
		private WonState wonStateRef;

		private float healthBarLength;

		public PlayStateL2 (StateManager managerRef)
		{
			manager = managerRef;
			//wonStateRef = new WonState(manager);
			if (Application.loadedLevelName != "level2") {
				Application.LoadLevel ("level2");
				GameData.currentLevel = 1;
			}

			playerControllerRef = GameObject.Find ("PlayerShip").GetComponent<PlayerController>();
			player = GameObject.FindGameObjectWithTag ("Player");
			enemySpawnSystemRef = GameObject.Find ("GameManager").GetComponent<EnemySpawnSystem>();
			playerControllerRef.canShoot = true;
			player.GetComponent<Renderer>().enabled = true;
			lJet = player.GetComponentInChildren<ParticleSystem>();
			lJet.Play(true);
			healthBarLength = Screen.width / 4;
			Cursor.visible = false;
		}
				
		public void StateUpdate()
		{
			enemySpawnSystemRef.timer -= Time.deltaTime;
			if (enemySpawnSystemRef.timer <= 0) {
				enemySpawnSystemRef.SpawnEnemy();
				enemySpawnSystemRef.timer = enemySpawnSystemRef.timerMax;
			}

			if(manager.gameDataRef.playerLives <= 0)
				manager.SwitchState(new LostState(manager));

			if (GameData.enemiesSpawned == 121 && Application.loadedLevelName == "level2") {
				manager.SwitchState (new WonState (manager));

			}
//			if(manager.gameDataRef.score >= 100)
//				manager.SwitchState(new WonState(manager));

			if (Input.GetAxis ("Mouse X") != 0) {
				playerControllerRef.isMovingRef.horizontal = true;
				playerControllerRef.MoveHorizontal ();
			}

			if (Input.GetAxis ("Mouse Y") != 0) {
				playerControllerRef.isMovingRef.vertical = true;
				playerControllerRef.MoveVertical ();
			}

			if (Input.GetKeyUp (KeyCode.Escape)) {
				manager.gameDataRef.playerLives = 0;
			}

			if (Input.GetKey(KeyCode.Mouse0)){
				playerControllerRef.isShooting = true;
			}else playerControllerRef.isShooting = false;

	//		if (Input.GetButton ("Fire2")) 
			//	{
	//			playerControllerRef.isSpecialShooting = true;
	//		}else playerControllerRef.isSpecialShooting = false;
		
			healthBarLength = (Screen.width / 4) * (manager.gameDataRef.playerCurrentHealth / manager.gameDataRef.playerMaxHealth);

			if (Input.GetKeyUp (KeyCode.P) && Time.timeScale == 1) {
				Time.timeScale = 0;
			} else if (Input.GetKeyUp (KeyCode.P) && Time.timeScale == 0) 
					Time.timeScale = 1;
		}

		public void ShowGUI()
		{
			GUI.Box(new Rect(10,10,100,25), string.Format("Score: "+ manager.gameDataRef.score));

			GUI.Box(new Rect(Screen.width - 110,10,100,25), string.Format("Lives left: "+ manager.gameDataRef.playerLives));

			GUI.Box(new Rect(Screen.width - healthBarLength - 10, Screen.height - 30, healthBarLength, 20),
			        manager.gameDataRef.playerCurrentHealth + "/" + manager.gameDataRef.playerMaxHealth);
		}
	}
}