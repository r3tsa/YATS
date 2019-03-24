using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class SettingsState : IStateBase
	{
		private StateManager manager;
		
		private GameObject player;
		
		public SettingsState (StateManager managerRef)
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
			
		}
		
		public void ShowGUI()
		{	
			GameData.showFPS = GUI.Toggle (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 30), GameData.showFPS, "FPS meter");
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 80, 100, 30), "Sounds volume");
			GameData.sVolume = GUI.HorizontalSlider (new Rect(Screen.width/2 - 50, Screen.height/2 - 60, 100, 10), GameData.sVolume, 0f, 1f);
			if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 40, 100, 30), "Back to menu"))
			{
				manager.SwitchState(new MenuState(manager));
			}
		}
	}
}