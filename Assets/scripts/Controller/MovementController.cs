using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

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
                float direction = Mathf.Atan2(input.y, input.x);
                body.MoveRotation(direction * Mathf.Rad2Deg - 90);
                animator.SetBool("is_walking", true);
            }
            else {
                animator.SetBool("is_walking", false);
            }
        }
    }
    public void DisablePlayerInput(float duration)
    {
        input_disabled_until = Time.time + duration;
    }
}