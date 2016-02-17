using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
	private Rigidbody2D body;
    private int pick_new_direction;

	public float speed = 20; 
	void Start() {
		body = GetComponent<Rigidbody2D>();
        pick_new_direction = 0;
	}
	
	void Update() {
        if(pick_new_direction == 0)
        {
            body.velocity = chooseDirection();
            pick_new_direction = 30;
        }
        else
        {
            pick_new_direction--;
        }        
    }

    Vector2 chooseDirection()
    {
        int direction = Random.Range(1, 10);
        Vector2 velocity = new Vector2();

        if (direction == 1)
        {
            velocity.x = -Mathf.Sqrt(speed);
            velocity.y = -Mathf.Sqrt(speed);
        }
        else if (direction == 2)
        {
            velocity.x = 0;
            velocity.y = -speed;
        }
        else if (direction == 3)
        {
            velocity.x = Mathf.Sqrt(speed);
            velocity.y = -Mathf.Sqrt(speed);
        }
        else if (direction == 4)
        {
            velocity.x = -speed;
            velocity.y = 0;
        }
        else if (direction == 5)
        {
            velocity.x = 0;
            velocity.y = 0;
        }
        else if (direction == 6)
        {
            velocity.x = speed;
            velocity.y = 0;
        }
        else if (direction == 7)
        {
            velocity.x = -Mathf.Sqrt(speed);
            velocity.y = Mathf.Sqrt(speed);
        }
        else if (direction == 8)
        {
            velocity.x = 0;
            velocity.y = speed;
        }
        else if (direction == 9)
        {
            velocity.x = Mathf.Sqrt(speed);
            velocity.y = Mathf.Sqrt(speed);
        }
        return velocity;
    }
}
