using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    private Movable movable;
    private Animator animator;

    void Start()
    {
        movable = GetComponent<Movable>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!movable.IsLocked())
        {
            animator.SetBool("is_dashing", false);

            movable.direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                movable.is_strafing = true;
            }
            else
            {
                movable.is_strafing = false;
            }

            if (movable.direction == Vector3.zero)
            {
                animator.SetBool("is_walking", false);
            }
            else
            {
                animator.SetBool("is_walking", true);

            }
        }
    }
}