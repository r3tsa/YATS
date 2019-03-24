using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class MenuState : IStateBase
	{
		private StateManager manager;

		private GameObject player;
		
		public MenuState (StateManager managerRef)
		{
			manager = managerRef;
			if(Application.loadedLevelName != "MainMenu")
				Application.LoadLevel("MainMenu");
			player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Renderer>().enabled = false;
			Cursor.visible = true;
		}
		
		public void StateUpdate()
		{
			if (Input.GetKeyDown (KeyCode.J))
				GameData.currentLevel = 0;
			if (Input.GetKeyDown (KeyCode.K))
				GameData.currentLevel = 1;
		}

		public void ShowGUI()
		{	
			GUI.Label (new Rect (Screen.width / 2 - 88, Screen.height / 2 - 170, 176, 30), "Yet Another Top-down Shooter");
			if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 140, 100, 30), "Start game"))
			{
				manager.SwitchState (new DifficultyState (manager));
			}
			if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 110, 100, 30), "Settings"))
			{
				manager.SwitchState (new SettingsState (manager));
			}
			if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 80, 100, 30), "High Score"))
			{
				manager.SwitchState(new HighScoresState(manager));
			}			
			if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 50, 100, 30), "Quit"))
			{
				Application.Quit();
			}
		}
	}
}