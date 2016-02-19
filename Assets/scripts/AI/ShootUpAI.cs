using UnityEngine;
using System.Collections;

public class ShootUpAI : MonoBehaviour {
    public GameObject projectile;
    public float speed;
    private const int SHOOT_COOLDOWN = 10;

    void Start () {
        speed = 5;
	}
	
	void Update () {
		if(Time.frameCount % SHOOT_COOLDOWN == 0) {
			Vector3 direction = transform.up;
			Vector3 bullet_position = transform.position + direction;
			Vector3 bullet_velocity = direction * speed;

			GameObject go = Instantiate(projectile, bullet_position, transform.rotation) as GameObject;
			go.name = "projectile";
			go.GetComponent<Rigidbody2D> ().velocity = bullet_velocity;
		}
	}
}
