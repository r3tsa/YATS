using UnityEngine;
using System.Collections;

public class FPSmeter : MonoBehaviour {
	
	public int frameCount = 0;
	public float deltatime = 0.0f;
	public float fps = 0.0f;
	public float updateRate = 4.0f; 

	// Update is called once per frame
	void Update () {
		frameCount++;
		deltatime += Time.deltaTime;
		if (deltatime > 1.0f/updateRate)
		{
			fps = frameCount / deltatime ;
			frameCount = 0;
			deltatime -= 1.0f/updateRate;
		}
	}
	void OnGUI(){
		if(GameData.showFPS)
			GUI.Box(new Rect(10, Screen.height - 30,65,20), string.Format("" + fps));
	}
}