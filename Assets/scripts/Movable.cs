using UnityEngine;
using System.Collections;
using UnityEditor;

public class Movable : MonoBehaviour {
	public Rigidbody2D body;
	public Vector3 direction;

	public float default_move_speed;
	public float default_rotation_speed;
	public bool is_strafing;

	private float current_move_speed;
	private float current_rotation_speed;

	private float is_kinematic_until;
	private bool is_entering_kinematic;

    void Start () {
        body = GetComponent<Rigidbody2D>();
		current_move_speed = default_move_speed;
	}
	
	void FixedUpdate () {
        body.WakeUp();
		body.angularVelocity = 0;
		body.velocity = Vector2.zero;
		if (IsKinematic ()) {
			if (is_entering_kinematic) {
				is_entering_kinematic = false;
				current_move_speed = default_move_speed;
				current_rotation_speed = 0;
				transform.rotation = Quaternion.Euler(0,0, Mathf.Round(transform.rotation.eulerAngles.z / 45) * 45); 
			}

			transform.position += (direction * current_move_speed * Time.fixedDeltaTime);
			if (IsMoving () && !is_strafing) {
                transform.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90);
            }
		} else {
			transform.position += transform.up * current_move_speed * Time.fixedDeltaTime;
			transform.Rotate (new Vector3 (0, 0, current_rotation_speed * Time.fixedDeltaTime));
		}
    }

    /// <summary>
    /// Gets the next position of the Movable
    /// </summary>
    /// <returns>The next position of the Movable</returns>
    public Vector3 GetNextPosition(){
        if(IsMoving()){
            return transform.position + direction * current_move_speed * Time.fixedDeltaTime; 
        } else {
            return transform.position;
        } 
    }

    /// <summary>
    /// Determines whether this instance is moving.
    /// </summary>
    /// <returns><c>true</c> if this instance is moving; otherwise, <c>false</c>.</returns>
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

    /// <summary>
    /// Determines whether this instance is kinematic (not affected by physics) 
    /// </summary>
    /// <returns><c>true</c> if this instance is kinematic; otherwise, <c>false</c>.</returns>
    public bool IsKinematic()
    {
        return is_kinematic_until <= Time.time;
	}

    /// <summary>
    /// Modifies the default speed of the Movable by a factor for a duration 
    /// </summary>
    /// <param name="speedFactor">Modify Movable's speed by this factor</param>
    /// <param name="duration">Modify Movable's speed for the time in seconds/param>
	public void SetSpeed(float speedFactor, float duration)
	{
		this.current_move_speed = default_move_speed * speedFactor;
		setKinematicUntil(duration);
	}

	public void SetRotation(float degrees, float duration) {
		current_rotation_speed = degrees / duration;
		setKinematicUntil(duration);
	}

	private void setKinematicUntil(float duration) {
		is_entering_kinematic = true; 
		is_kinematic_until = Time.time + duration;
	}

    public float GetSpeed(){
        return current_move_speed;
    }
}