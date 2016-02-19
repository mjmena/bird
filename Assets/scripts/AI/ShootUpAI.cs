using UnityEngine;
using System.Collections;

public class ShootUpAI : MonoBehaviour {
	private int shoot_cooldown;
	public float speed = 1; 
	public GameObject projectile;

	void Start () {
		shoot_cooldown = 30;
	}
	
	void Update () {
		if(shoot_cooldown == 0) {

			Vector3 direction = transform.up;
			Vector3 bullet_position = transform.position + direction;
			Vector3 bullet_velocity = direction * speed;

			GameObject go = Instantiate(projectile, bullet_position, transform.rotation) as GameObject;
			go.name = "bullet";
			go.GetComponent<Rigidbody2D> ().velocity = bullet_velocity;
			shoot_cooldown = 60;
		} else {
			shoot_cooldown--;
		}    
	}
}
