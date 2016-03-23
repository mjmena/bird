using UnityEngine;
using System.Collections;

public class FireHawkEffect : MonoBehaviour {
    public float speed = 30;

    public void SetDirection(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
