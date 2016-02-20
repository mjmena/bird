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
			if (collision.gameObject.name == "enemy_projectile") {
				health = health - collision.gameObject.GetComponent<Damager>().damage;
			}
		} else if (gameObject.name == "rude_dude") {
			if (collision.gameObject.name == "player_projectile")
            {
                health = health - collision.gameObject.GetComponent<Damager>().damage;
            }
        } else if (gameObject.name == "player_projectile" || gameObject.name == "enemy_projectile") {
			health = health - 1;
		}

		if (health <= 0) {
			Destroy (gameObject);
		}
    }
}