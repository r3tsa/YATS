using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Random.Range(0f,1.0f) * 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
