using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    public float speed;
    public float rotational_speed;
    public Vector3 direction;
    public bool is_strafing;
    private float is_kinematic_until;
	private bool is_entering_kinematic;
	private float rotational_velocity;

    public Rigidbody2D body;


    void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        body.WakeUp();
		if (IsKinematic ()) {
			if (is_entering_kinematic) {
				is_entering_kinematic = false;
				transform.rotation = Quaternion.Euler(0,0, Mathf.Round(transform.rotation.eulerAngles.z / 45) * 45); 
			}
			body.velocity = Vector2.zero;
			body.angularVelocity = 0;

			transform.position += (direction * speed * Time.deltaTime);
			if (IsMoving () && !is_strafing) {
				transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (0, 0, Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90), rotational_speed * Time.deltaTime);
			}
		} else {
			transform.Rotate (new Vector3 (0, 0, rotational_velocity * Time.fixedDeltaTime));
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
		setKinematicUntil(duration);
    }

	/* Set rotation to the object */
	public void SetRotation(float degrees, float duration) {
		rotational_velocity = degrees / duration;
		setKinematicUntil(duration);
	}

	private void setKinematicUntil(float duration) {
		is_entering_kinematic = true; 
		is_kinematic_until = Time.time + duration;
	}
}