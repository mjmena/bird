using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    public float speed;
    public Vector3 direction; 
    public Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start () {
	    
	}
	
	void FixedUpdate () {
        //body.velocity = speed * direction * Time.deltaTime;
	}
}
