using UnityEngine;
using System.Collections;

public class CameraHeight : MonoBehaviour {


	public float cameraHeight;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x,  cameraHeight, transform.position.z);
	}
}
