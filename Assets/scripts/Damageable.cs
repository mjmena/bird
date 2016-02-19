using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {
	public int max_health = 100;
    public int health;  
	// Use this for initialization
	void Start () {
        health = max_health;
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (gameObject.name == "player") {
			if (collision.gameObject.name == "rude_dude") {
				health = health - 5;
			} else if (collision.gameObject.name == "bullet") {
				health = health - 5;
			}
		} else if (gameObject.name == "rude_dude") {
			if (collision.gameObject.name == "player") {
				health = health - 1;
			}
		} else if (gameObject.name == "bullet") {
			health = health - 1;
		}

		if (health <= 0) {
			Destroy (gameObject);
		}
    }
}