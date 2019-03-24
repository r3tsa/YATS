using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class DifficultyState : IStateBase
	{
		private StateManager manager;
		
		private GameObject player;
		
		public DifficultyState (StateManager managerRef)
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

		private int toolbarInt = 2;
		private string[] toolbarStrings = {"Very Easy", "Easy", "Medium", "Hard", "Very Hard"};

		public void ShowGUI()
		{	
			toolbarInt = GUI.Toolbar (new Rect (Screen.width/2 - 225, Screen.height/2 - 30, 450, 30), toolbarInt, toolbarStrings);

			if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2, 100, 30), "Back to menu"))
			{
				manager.SwitchState(new MenuState(manager));
			}
			if (GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 30), "Play"))
			{
				Difficulty.SetDifficulty(toolbarStrings[toolbarInt]);
				if(GameData.currentLevel == 0)
					manager.SwitchState(new PlayState(manager));
				if(GameData.currentLevel == 1)
					manager.SwitchState(new PlayStateL2(manager));
			}

		}
	}
}