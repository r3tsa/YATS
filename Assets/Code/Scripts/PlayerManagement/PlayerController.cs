using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	public Rigidbody projectilePrefab;
	public Transform shootSpawnPos;
	public AudioClip shotSound;

//	private GameData gameDataRef;
	
	private float horizontal = 0.0f;
	private float vertical = 0.0f;

	public struct isMoving{
		public bool vertical;
		public bool horizontal;
	};
	public isMoving isMovingRef;

	public bool canShoot = false;
	public bool isShooting = false;
	private float nextFireTime = 0.0f;
	private float fireDelayTime = 0.175f;

//	public bool isSpecialShooting = false;
//	private float nextSpecialTime = 0.0f;
//	private float specialDelayTime = 0.125f;

	void Start ()
	{
//		gameDataRef = GameObject.Find("GameManager").GetComponent<GameData>();
//		nextSpecialTime = specialDelayTime;
	}

	void LateUpdate()
	{
		transform.position = StaticMethods.InsideFrustumCheck (transform.position, GetComponent<Renderer>());
	}

	void Update()
	{
		if (GameData.enemiesDestroyed == 20)
			GameData.weaponLevel = 2;
		if (GameData.enemiesDestroyed == 40)
			GameData.weaponLevel = 3;
		if (GameData.enemiesDestroyed == 60)
			GameData.weaponLevel = 4;

		if (GameData.enemiesDestroyed == 80)
			GameData.weaponLevel = 5;
		if (GameData.enemiesDestroyed == 100)
			GameData.weaponLevel = 6;
		if (GameData.enemiesDestroyed == 120)
			GameData.weaponLevel = 7;
	}

	void FixedUpdate()
	{
		if (isMovingRef.horizontal == true)
		{
			transform.Translate(horizontal, 0, 0, Space.World);
			isMovingRef.horizontal = false;
		}

		if (isMovingRef.vertical == true)
		{
			transform.Translate(0, 0, vertical, Space.World);
			isMovingRef.vertical = false;
		}

		if (isShooting == true && nextFireTime >= fireDelayTime && canShoot == true){
			SpecialShoot(90, GameData.weaponLevel);
			//BasicShoot ();
			isShooting = false;
			nextFireTime = 0;
		}nextFireTime += Time.deltaTime;

		//if (isSpecialShooting == true && nextSpecialTime >= specialDelayTime) {
			//SpecialShoot(90, 1);
			//shootSpawnPos.rotation = Quaternion.identity;
			//isSpecialShooting = false;
			//nextSpecialTime = 0;
		//}nextSpecialTime += Time.deltaTime;
	}

	//public void BasicShoot()
	//{
		//Rigidbody projectileInstance;
	//	Quaternion rotation = Quaternion.Euler (0, 90, 0);
	//	shootSpawnPos.eulerAngles = new Vector3 (0, 90, 0);
		//projectileInstance = Instantiate(projectilePrefab, shootSpawnPos.position, shootSpawnPos.rotation) as Rigidbody;
		//projectileInstance.tag = "PlayerProjectile";
		//projectileInstance.rigidbody.AddForce (shootSpawnPos.forward * 1500);
		//Debug.Log (shootSpawnPos.rotation.eulerAngles);
		//projectileInstance.transform.Translate(0, .5f, 2.1f);
		//projectileInstance.velocity = transform.TransformDirection(Vector3.forward * 50);
	//}

	public void SpecialShoot(int angle, int numberOfShots)
	{
			float degree = angle / numberOfShots;
			for (float i = -angle/2f+degree/2f; i < angle/2f; i += degree) {
				Quaternion rotation = Quaternion.AngleAxis (i, Vector3.up);
				//Vector3 shotPosition = rotation * shootSpawnPos.position;
				shootSpawnPos.rotation = rotation;
				Rigidbody projectileInstance = Instantiate (projectilePrefab, shootSpawnPos.position, rotation) as Rigidbody;
				projectileInstance.tag = "PlayerProjectile";
				projectileInstance.GetComponent<Rigidbody>().AddForce (shootSpawnPos.forward * 1500);
			}
			shootSpawnPos.rotation = Quaternion.identity;
		GetComponent<AudioSource>().PlayOneShot (shotSound, 0.25f);

		//	for(int i = leftAngle+stepAngle/2; i<rightAngle+stepAngle/2; i+=stepAngle){
	//		shootSpawnPos.rotation = Quaternion.Euler(0, i, 0);
	//		BasicShoot ();
			//yield return null;
	}
	//	for(int i = 0; i<rightAngle+stepAngle/2; i+=stepAngle){
	//		shootSpawnPos.rotation = Quaternion.Euler(0, i, 0);
	//		BasicShoot ();
	//		yield return null;
		//}
//		shootSpawnPos.rotation = Quaternion.Euler(0, 0, 0);
		
	public void MoveHorizontal()
	{
		horizontal = Input.GetAxis ("Mouse X") * Time.deltaTime;
	}
	public void MoveVertical()
	{
		vertical = Input.GetAxis ("Mouse Y") * Time.deltaTime;
	}
}