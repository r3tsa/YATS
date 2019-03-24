using UnityEngine;
using System.Collections;

public class DeathByLifetime : MonoBehaviour {

	public float lifeTime;

	// Use this for initialization
	void Start () 
	{
		Destroy (this.gameObject, lifeTime);
	}
	

}
