using UnityEngine;
using System.Collections;

public class FireHawkEffect : MonoBehaviour {
    private float birth;
    private float lifetime = 2;
    public float damage = 20;
    public float speed = 30;

    protected void Start()
    {
        birth = Time.time;
    }

    protected void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Damageable>() != null)
        {
            collider.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
