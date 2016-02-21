using UnityEngine;
using System.Collections;

public class ShootUpAI : MonoBehaviour {
    public GameObject projectile;
    public float speed;
    private const int SHOOT_COOLDOWN = 30;
	
	void Update () {
		if(Time.frameCount % SHOOT_COOLDOWN == 0) {
			Vector3 direction = transform.up;
			Vector3 bullet_position = transform.position + direction;
			Vector3 bullet_velocity = direction * speed;

            GameObject go = Instantiate(projectile, bullet_position, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI - 90)) as GameObject;
			go.name = "enemy_projectile";
            go.tag = gameObject.tag;
            go.GetComponent<Rigidbody2D> ().velocity = bullet_velocity;
            go.GetComponent<DamageProjectileEffect>().damage = 10;
            go.GetComponent<DamageProjectileEffect>().SetLifetime(1);
        }
	}
}
