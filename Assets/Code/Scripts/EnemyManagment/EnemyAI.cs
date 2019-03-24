using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	
	//private float currentSpeed;
	private float targetPositionZ;
	private bool isOn = false;
	private GameObject player;

//	public delegate IEnumerator MyDelegate();



	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		//MyDelegate[] delegates = new MyDelegate[2];
		//delegates[0] = new MyDelegate(Evade);
		//delegates[1] = new MyDelegate(Noise);
		//StartCoroutine(delegates[Random.Range(0, 2)]());
		//currentSpeed = rigidbody.velocity.z;
		StartCoroutine(Evade());
	}
	
	public IEnumerator Evade ()
	{
		isOn = true;
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			targetPositionZ = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetPositionZ = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	//public IEnumerator Noise ()
	//{
	//	isOn = true;
	//	yield return new WaitForSeconds (Random.Range (0, 1));
	//	while (true)
	//	{
	//		targetPositionZ = Random.Range (-dodge, dodge) + transform.position.z;
	//		yield return new WaitForSeconds (Random.Range (0, 1));
	//		targetPositionZ = 0;
	//		yield return new WaitForSeconds (Random.Range (0, 1));
	//	}
	//}
	
	void FixedUpdate ()
	{
		if (isOn == true) {
			float newPositionZ = Mathf.MoveTowards (transform.position.x, targetPositionZ, smoothing * Time.deltaTime);
			transform.position = new Vector3 (newPositionZ, 0.0f, transform.position.z);
		}
//		Vector3 heading = player.transform.position - transform.position;
//		float dist = Vector3.Dot (heading, transform.position);
		transform.LookAt (player.transform.position);
	//	transform.position = new Vector3
			
		//		Mathf.Clamp(transform.position.x, StaticMethods.Boundary.xMin, StaticMethods.Boundary.xMax), 
		//		transform.position.y, 
		//		transform.position.z
				
		//rigidbody.rotation = Quaternion.Euler (0, 0, rigidbody.velocity.x * -tilt);
	}
}
