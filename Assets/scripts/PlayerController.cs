using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D body;

	public float speed;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			body.velocity = new Vector2(body.velocity.x, speed);
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			body.velocity = new Vector2(-speed, body.velocity.y);
		}
        
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			body.velocity = new Vector2(body.velocity.x, -speed);
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			body.velocity = new Vector2(speed, body.velocity.y);
		}

		if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
			body.velocity = new Vector2(0, body.velocity.y);
		}

		if (!(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
			body.velocity = new Vector2(body.velocity.x, 0);
		}
	}
}
