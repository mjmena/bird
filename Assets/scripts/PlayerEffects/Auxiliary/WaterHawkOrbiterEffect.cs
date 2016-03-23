using UnityEngine;
using System.Collections;

public class WaterHawkOrbiterEffect : MonoBehaviour
{
    public float speed;
    public Vector3 center;
    public Vector3 direction;

    void Update()
    {
        center += direction * Time.deltaTime * speed;
        transform.position += direction * Time.deltaTime * speed;
        transform.RotateAround(center, Vector3.forward, 360 * Time.deltaTime);
    }
}
