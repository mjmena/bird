using UnityEngine;
using System.Collections;

public class Combatant : MonoBehaviour {
	public int health;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "player") {
            Debug.Log("Ouch");
			health-=5;
		}
	}
}