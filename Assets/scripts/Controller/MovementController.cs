using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
	private Rigidbody2D body;
	private Animator anim;

	public float speed;

	private float lock_start = 0;
	private float lock_duration = 0;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (lock_start + lock_duration <= Time.time) {
			anim.SetBool("is_dashing", false);
			updateMovement ();
        }

        if (Mathf.Abs(body.velocity.x) > 0 || Mathf.Abs(body.velocity.y) > 0)
        {
            float direction = Mathf.Atan2(body.velocity.y, body.velocity.x);
            body.transform.rotation = Quaternion.Euler(0, 0, direction * 180 / Mathf.PI - 90);
            anim.SetBool("is_walking", true);
        }
        else {
			anim.SetBool("is_walking", false);
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
    }

	public void LockState(float duration) {
		lock_start = Time.time;
		lock_duration = duration;
	}
}