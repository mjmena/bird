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
		if(collision.gameObject.name == "rude_dude") {
            health = health - 5;
            if(health < 5)
            {
                health = 1; 
            }
		}
    }
}