using UnityEngine;
using System.Collections;

public class FireHawkEffect : MonoBehaviour {
    private float speed = 15;
    private Timed lifetime;

    void Start(){
        lifetime = new Timed(2000);
    }

    public void SetDirection(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public bool IsExpired(){
        return lifetime.IsElapsed();
    }
}
