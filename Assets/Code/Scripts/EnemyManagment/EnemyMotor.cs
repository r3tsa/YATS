﻿using UnityEngine;
using System.Collections;

public class EnemyMotor : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(
			transform.position.x, 
			transform.position.y,
			Mathf.Lerp(transform.position.z, transform.position.z - moveSpeed, Time.deltaTime));
	}
}