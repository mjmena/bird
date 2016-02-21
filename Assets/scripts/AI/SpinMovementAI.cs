using UnityEngine;
using System.Collections;

public class SpinMovementAI : MonoBehaviour
{
    public float rotation;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotation * Time.deltaTime );
    }
}
