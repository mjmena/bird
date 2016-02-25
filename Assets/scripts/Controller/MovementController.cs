using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private bool is_moving;
    public float speed;
    private float input_disabled_until = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        body.WakeUp();    
        if (input_disabled_until <= Time.time)
        {
            body.velocity = Vector2.zero;
            body.angularVelocity = 0;
            animator.SetBool("is_dashing", false);

            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            body.MovePosition(body.position + input.normalized * speed * Time.deltaTime);

            if (input != Vector2.zero)
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    float direction = Mathf.Atan2(input.y, input.x);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, direction * Mathf.Rad2Deg - 90), 10);
                }
                animator.SetBool("is_walking", true);
                is_moving = true; 
            }
            else {
                animator.SetBool("is_walking", false);
                is_moving = false;
            }
        }
        else if(body.velocity != Vector2.zero)
        {
            is_moving = true; 
        }
        else
        {
            is_moving = false; 
        }
    }

    public void DisablePlayerInput(float duration)
    {
        input_disabled_until = Time.time + duration;
    }

    public bool IsMoving()
    {
        return is_moving;
    }

    public Vector2 GetVelocity()
    {
        if (IsMoving() && body.velocity == Vector2.zero)
        {
            return transform.up * speed * Time.deltaTime;
        }else
        {
            return body.velocity * Time.deltaTime;
        }

        
    }
}