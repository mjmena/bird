using UnityEngine;
using System.Collections;

public class Combatant : MonoBehaviour {
	public int health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "rude_dude") {
            health = health - 5;
            Debug.Log("Ouch " + health);
			
		}
	}
}