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
        updateMovement();
		
        if (Input.GetKey(KeyCode.Space) && time_since_last_ability + ability_cooldown <= Time.time)
        {
            Vector3 direction = transform.up;
            Vector3 bullet_position = transform.position + direction;
            Vector3 bullet_velocity = direction * speed;

            GameObject go = Instantiate(projectile, bullet_position, transform.rotation) as GameObject;
            go.name = "player_projectile";
            go.GetComponent<Rigidbody2D>().velocity = bullet_velocity;

            time_since_last_ability = Time.time;
        }
    }

	void updateMovement() {
        float x = 0;
        float y = 0; 
		if (Input.GetKey(KeyCode.W)) {
            y =+ 1;
		}

		if (Input.GetKey(KeyCode.A)) {
            x = -1;
		}

		if (Input.GetKey(KeyCode.S)) {
			y =- 1;
		}

		if (Input.GetKey(KeyCode.D)) {
			x =+ 1;
		}

        Vector2 unit_vector = new Vector2(x, y);
        unit_vector.Normalize();
       
        body.velocity = unit_vector * speed;
        if (Mathf.Abs(body.velocity.x) > 0 || Mathf.Abs(body.velocity.y) > 0)
        {
            float direction = Mathf.Atan2(body.velocity.y, body.velocity.x);
            body.transform.rotation = Quaternion.Euler(0, 0, direction * 180 / Mathf.PI - 90);
            anim.SetBool("is_moving", true);

        }
        else
        {
            anim.SetBool("is_moving", false);
        }
    }
}