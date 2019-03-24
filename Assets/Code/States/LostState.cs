using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class LostState : IStateBase
	{
		private StateManager manager;

		private GameObject player;
		private ParticleSystem lJet;

		public LostState (StateManager managerRef)
		{
			manager = managerRef;
			if(Application.loadedLevelName != "MainMenu")
				Application.LoadLevel("MainMenu");
			player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Renderer>().enabled = false;
			lJet = player.GetComponentInChildren<ParticleSystem>();
			lJet.Stop();
			Cursor.visible = true;
			GameData.enemiesSpawned = 0;
			GameData.enemiesDestroyed = 0;
			GameData.weaponLevel = 1;
		}
		
		public void StateUpdate()
		{
		
		}

		public void ShowGUI()
		{
			GameData.playerName = GUI.TextField(new Rect (Screen.width/2 - 75, Screen.height/2 - 30, 150, 30), GameData.playerName);
			
			if(GUI.Button(new Rect(Screen.width/2 - 135, Screen.height/2, 270, 30), "Back to menu"))
			{
				HighScores.AddHighScore(GameData.playerName, manager.gameDataRef.score);
				HighScores.SaveScores();
				manager.Restart();
			}
		}
	}
}