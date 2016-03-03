using UnityEngine;
using System.Collections;

public class SpinMovementAI : MonoBehaviour
{
    public float rotation;

    void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotation * Time.fixedDeltaTime);
    }
}
