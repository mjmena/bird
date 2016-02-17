using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D body;
	private Animator anim;

	public float speed;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
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

		if (Mathf.Abs(body.velocity.x) > 0 || Mathf.Abs(body.velocity.y) > 0) {
			float animDirection = Mathf.Atan(body.velocity.y / body.velocity.x);

			bool flipHoizontally = false;
			if (body.velocity.x < 0) {
				flipHoizontally = true;
			}

			body.transform.eulerAngles = new Vector3 (flipHoizontally.GetHashCode()*180, flipHoizontally.GetHashCode()*180, animDirection*180/Mathf.PI);
		}

		anim.SetFloat ("speed", Mathf.Abs (Mathf.Pow (body.velocity.x, 2) + Mathf.Pow (body.velocity.y, 2)));
	}
}