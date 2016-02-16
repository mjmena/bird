using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float acceleration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.W))
        {
            body.velocity = new Vector2(body.velocity.x, acceleration);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            body.velocity = new Vector2(-acceleration, body.velocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            body.velocity = new Vector2(body.velocity.x, -acceleration);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            body.velocity = new Vector2(acceleration, body.velocity.y);
        }
    }
}
