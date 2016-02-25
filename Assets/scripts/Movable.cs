using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    public float speed;
    public float rotational_speed;
    public Vector3 direction;
    private bool is_moving;
    private bool is_strafing;
    private bool is_kinetic;


    private Rigidbody2D body;


    void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        body.WakeUp();
        if (!is_kinetic)
        {
            body.velocity = Vector2.zero;
            body.angularVelocity = 0;

            transform.Translate(direction * speed * Time.deltaTime);
            if (is_moving && !is_strafing)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg - 90), rotational_speed);
            }
        }
    }

    public bool IsMoving()
    {
        return is_moving;
    }

    public bool IsStrafing()
    {
        return IsStrafing();
    }

    public bool IsKinetic()
    {
        return is_kinetic;
    }

    public void SetIsKinetic(bool is_kinetic)
    {
        this.is_kinetic = is_kinetic; 
    }
}
