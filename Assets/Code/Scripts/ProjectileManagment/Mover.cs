using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	public Transform enemyShootSpawnPos;
	public Transform playerShootSpawnPos;
	private Transform player;
	private Vector3 heading;

	private PlayerController playerControllerRef;
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerShootSpawnPos = GameObject.Find ("PlayerShip").GetComponent<PlayerController>().shootSpawnPos;
		heading = (transform.position - player.position).normalized;
		if (this.tag == "PlayerProjectile")
						GetComponent<Rigidbody>().AddForce (playerShootSpawnPos.forward * speed);
				else if (this.tag == "EnemyProjectile") {
						GetComponent<Rigidbody>().AddForce (heading * -speed / 1.5f);
				}
	}
	void Update()
	{
		heading = (transform.position - player.position).normalized ;
		//Debug.DrawRay(playerShootSpawnPos.position, heading, Color.black);
	}
}
