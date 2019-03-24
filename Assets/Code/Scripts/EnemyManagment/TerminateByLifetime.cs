using UnityEngine;
using System.Collections;

public class TerminateByLifetime : MonoBehaviour {

	public float lifeTime = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z < StaticMethods.Boundary.zMin)
			Destroy (this.gameObject, lifeTime);
	}
}
