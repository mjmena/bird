using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    public float speed;
    public float rotational_speed;
    public Vector3 direction;
    public bool is_strafing;
    private float is_kinematic_until;


    public Rigidbody2D body;


    void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        body.WakeUp();
        if (IsKinematic())
        {
            body.velocity = Vector2.zero;
            body.angularVelocity = 0;

            transform.position += (direction * speed * Time.deltaTime);
            if (IsMoving() && !is_strafing)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg-90), rotational_speed * Time.deltaTime);
            }
        }
    }

    public bool IsMoving()
    {
        if (IsKinematic())
        {
            return direction != Vector3.zero;
        }
        else
        {
            return body.velocity != Vector2.zero;
        }
    }

    public bool IsKinematic()
    {
        return is_kinematic_until <= Time.time;
    }

    public void AddForce(Vector3 force, ForceMode2D force_mode, float duration)
    {
        body.AddForce(force, force_mode);
        is_kinematic_until = Time.time + duration;
    }

    public void AddTorque(float torque, ForceMode2D force_mode, float duration)
    {
        body.AddTorque(torque, force_mode);
        is_kinematic_until = Time.time + duration;
    }
}
