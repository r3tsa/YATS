using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	public Rigidbody projectilePrefab;
	public Transform shootSpawnPos;

	private bool canFire = false;
	private float nextFireTime = 0.0f;
	private float fireDelayTime = 0.75f;
	public AudioClip shotSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (StaticMethods.Boundary.zMax <= this.transform.position.z)
			canFire = true;
		if (Time.time >= nextFireTime && canFire == true) 
		{
			nextFireTime = Time.time + fireDelayTime;
			Shoot ();
		}
		if (StaticMethods.Boundary.zMin >= this.transform.position.z)
			Destroy (this.gameObject);
	}

	public void Shoot()
	{
		Rigidbody projectileInstance;
		projectileInstance = Instantiate (projectilePrefab, shootSpawnPos.position, shootSpawnPos.rotation) as Rigidbody;
		projectileInstance.tag = "EnemyProjectile";
		GetComponent<AudioSource>().PlayOneShot (shotSound);
	}
}
