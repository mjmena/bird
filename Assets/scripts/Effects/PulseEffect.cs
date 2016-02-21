using UnityEngine;
using System.Collections;

public class PulseEffect : Effect {
    public float radius;
    public float velocity;
    public float acceleration;
    public Transform origin;

    protected new void Start () {
        base.Start();
        transform.localScale = transform.localScale * radius;
    }
	
	protected new void Update () {
        base.Update();
        transform.position = origin.position;

        Vector3 unit_vector = transform.localScale;
        unit_vector.Normalize();

        velocity += acceleration * Time.deltaTime;
        transform.localScale = transform.localScale + new Vector3(radius,radius,radius) * velocity * Time.deltaTime;
    }
}
