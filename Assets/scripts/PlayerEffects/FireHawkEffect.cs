using UnityEngine;
using System.Collections;

public class FireHawkEffect : MonoBehaviour {
    private float speed = 15;

    private void Start() {
        Destroy(gameObject, 2f);
    }

    public void SetDirection(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
