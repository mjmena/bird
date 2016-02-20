using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject projectile;
	private Rigidbody2D body;
	private Animator anim;

    public float ability_cooldown = .5f; //seconds
    private float time_since_last_ability;
    public float speed;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        updateMovement ();
		updateAnimation ();

        if (Input.GetKey(KeyCode.Space) && time_since_last_ability + ability_cooldown <= Time.time)
        {
            Vector3 direction = transform.right;
            Vector3 bullet_position = transform.position + direction;
            Vector3 bullet_velocity = direction * speed;

            GameObject go = Instantiate(projectile, bullet_position, transform.rotation) as GameObject;
            go.name = "player_projectile";
            go.GetComponent<Rigidbody2D>().velocity = bullet_velocity;

            time_since_last_ability = Time.time;
        }
    }

	void updateMovement() {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			body.velocity = new Vector2 (body.velocity.x, speed);
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			body.velocity = new Vector2 (-speed, body.velocity.y);
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			body.velocity = new Vector2 (body.velocity.x, -speed);
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			body.velocity = new Vector2 (speed, body.velocity.y);
		}

		if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
			body.velocity = new Vector2 (0, body.velocity.y);
		}

		if (!(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
			body.velocity = new Vector2 (body.velocity.x, 0);
		}
	}

	void updateAnimation() {
		if (Mathf.Abs(body.velocity.x) > 0 || Mathf.Abs(body.velocity.y) > 0) {
			float animDirection = Mathf.Atan2(body.velocity.y, body.velocity.x);
			body.transform.rotation = Quaternion.Euler (0, 0, animDirection * 180/Mathf.PI);
		}

		anim.SetFloat ("speed", Mathf.Abs (Mathf.Pow (body.velocity.x, 2) + Mathf.Pow (body.velocity.y, 2)));
	}
}