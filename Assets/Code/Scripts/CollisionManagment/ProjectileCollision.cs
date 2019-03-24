using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour {

	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.tag == "Enemy" && this.tag == "EnemyProjectile")
			Destroy (this.gameObject);
		if (hit.gameObject.tag == "Enemy" && this.tag == "PlayerProjectile")
		{
			hit.gameObject.SendMessage ("DealDamage", WeaponDamage.playerValues ["basicWeapon"], SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
		if (hit.gameObject.tag == "Player" && this.tag == "EnemyProjectile")
		{
			hit.gameObject.SendMessage ("DealDamage", WeaponDamage.enemyValues ["basicWeapon"], SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
		if (hit.gameObject.tag == "PlayerProjectile" && this.tag == "EnemyProjectile")
		{
			Destroy(hit.gameObject);
			Destroy(this.gameObject);
		}
	}
}
