using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class WonState : IStateBase
	{
		private StateManager manager;

		private GameData gameDataRef;
		
		private GameObject player;
		private ParticleSystem lJet;

		public WonState (StateManager managerRef)
		{
			manager = managerRef;
			gameDataRef = GameObject.Find("GameManager").GetComponent<GameData>();
			if(Application.loadedLevelName != "MainMenu")
				Application.LoadLevel("MainMenu");
			player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Renderer>().enabled = false;
			lJet = player.GetComponentInChildren<ParticleSystem>();
			lJet.Stop();
			Cursor.visible = true;
			if (GameData.currentLevel == 0) {
				if(GameData.enemiesDestroyed == GameData.enemiesSpawned - 1)
					gameDataRef.playerLives += 1;
			}
		}
				
		public void StateUpdate()
		{
		}

		public void ShowGUI()
		{
		if (GameData.currentLevel == 0) {
			if(GameData.enemiesDestroyed == GameData.enemiesSpawned - 1)
				gameDataRef.playerLives += 1;
			GUI.Label(new Rect(Screen.width/2 - 70, Screen.height/2, 200, 30), "Level 1 completed");
				if (GUI.Button (new Rect (Screen.width/2 -135, Screen.height/2 + 40, 270, 30), "Click Here to proceed to level 2")) {
					manager.SwitchState(new PlayStateL2(manager));
				}
			}else if (GameData.currentLevel == 1) {
			GUI.Label(new Rect(Screen.width/2 - 150, Screen.height/2, 300, 30), "Congratulations! You've beat the game");
			GameData.playerName = GUI.TextField(new Rect (Screen.width/2 - 75, Screen.height/2 + 30, 150, 30), GameData.playerName);
				if (GUI.Button (new Rect (Screen.width/2 - 135, Screen.height/2 + 70, 270, 30), "Click Here to Restart Game")) {
					HighScores.AddHighScore(GameData.playerName, manager.gameDataRef.score);
					HighScores.SaveScores();
					manager.Restart ();
				}
		}
		}
	}
}