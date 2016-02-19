using UnityEngine;
using System.Collections;

public class RandomMovementAI : MonoBehaviour {
	public float speed = 20; 
	private Rigidbody2D body;
	private int CHANGE_DIRECTION_COOLDOWN = 30;

	void Start() {
		body = GetComponent<Rigidbody2D>();
	}
	
	void Update() {
        if(Time.frameCount % CHANGE_DIRECTION_COOLDOWN == 0) {
			Vector3 unit_vec = generateDirection();
			body.velocity = unit_vec * speed;

			if (Mathf.Abs(body.velocity.x) > 0 || Mathf.Abs(body.velocity.y) > 0) {
				float direction = Mathf.Atan2(body.velocity.y, body.velocity.x);
				body.transform.rotation = Quaternion.Euler (0, 0, direction * 180/Mathf.PI);
			}
        }
    }

	Vector3 generateDirection() {
		int random_dir = Random.Range(1, 10);

		float x = random_dir % 3 - 1;
		float y = Mathf.Floor((random_dir - 1) / 3) - 1;

		Vector3 unit_vec = new Vector3 (x, y, 0);
		unit_vec.Normalize();
		return unit_vec;
    }
}
