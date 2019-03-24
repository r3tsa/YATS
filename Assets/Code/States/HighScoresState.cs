using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class HighScoresState : IStateBase
	{
		private StateManager manager;
		
		private GameObject player;
		
		public HighScoresState (StateManager managerRef)
		{
			manager = managerRef;
			if(Application.loadedLevelName != "MainMenu")
				Application.LoadLevel("MainMenu");
			player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Renderer>().enabled = false;

			HighScores.LoadHighScores ();
			Cursor.visible = true;
		}
		
		public void StateUpdate()
		{
			
		}
		
		public void ShowGUI()
		{	
			GUI.BeginGroup (new Rect (Screen.width / 2 -50, Screen.height / 2, Screen.width / 2, Screen.height / 2));
			foreach(var score in HighScores.highScores)
			{
				GUILayout.Label(string.Format((HighScores.highScores.IndexOf(score)+1) + " " + score.name + " " + score.score));
			}
			GUI.EndGroup();
			if (GUI.Button(new Rect(Screen.width/2, Screen.height - 60, 100, 30), "Back to menu"))
			{
				manager.SwitchState (new MenuState (manager));
			}
			if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height - 60, 100, 30), "Reset scores"))
			{
				HighScores.highScores.Clear();
				HighScores.SaveScores();
			}
		}
	}
}