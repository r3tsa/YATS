using UnityEngine;
using System.Collections;

public class VolumeManagment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AudioListener.volume = GameData.sVolume;
	}
}
