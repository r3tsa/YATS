using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	private GameData gameDataRef;

	public ParticleSystem explosionParticle;
	public AudioClip explosionSound;
	public float health = 100.0f;

	private string tmp;

	// Use this for initialization
	void Start () {
		gameDataRef = GameObject.Find("GameManager").GetComponent<GameData>();
		tmp = this.name.Remove (6);
		if (tmp == "Enemy2")
			health *= 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) 
		{
			//Debug.Log(this.name.Remove(6));

			gameDataRef.AddScore(Score.values[tmp]);

			Destroy (this.gameObject);
			Instantiate(explosionParticle, this.transform.position, this.transform.rotation);
			AudioSource.PlayClipAtPoint(explosionSound, this.transform.position);
			GameData.enemiesDestroyed += 1;

		}
	}
	public void DealDamage(float value)
	{
		health -= value;
	}
}
