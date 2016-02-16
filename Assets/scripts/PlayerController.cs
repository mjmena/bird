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
		if (Input.GetKeyDown (KeyCode.W)) {
			body.velocity = new Vector2(body.velocity.x, speed);
		} else if (Input.GetKeyUp(KeyCode.W)) {
			body.velocity = new Vector2 (body.velocity.x, 0);
		}

        if (Input.GetKeyDown(KeyCode.A)) {
			body.velocity = new Vector2(-speed, body.velocity.y);
		} else if (Input.GetKeyUp(KeyCode.A)) {
			body.velocity = new Vector2(0, body.velocity.y);
		}
        
        if (Input.GetKeyDown(KeyCode.S)) {
			body.velocity = new Vector2(body.velocity.x, -speed);
		} else if (Input.GetKeyUp(KeyCode.S)) {
			body.velocity = new Vector2(body.velocity.x, 0);
		}

        if (Input.GetKeyDown(KeyCode.D)) {
			body.velocity = new Vector2(speed, body.velocity.y);
		} else if (Input.GetKeyUp(KeyCode.D)) {
			body.velocity = new Vector2(0, body.velocity.y);
		}
    }
}
