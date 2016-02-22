using UnityEngine;
using System.Collections;

public class WaterHawkOrbiterEffect : MonoBehaviour
{
    private float birth;
    public float lifetime;
    public float damage;
    public float speed;
    public Vector3 center;
    public Vector3 direction;

    void Start()
    {
        birth = Time.time;
    }

    void Update()
    {
        center += direction * Time.deltaTime * speed;
        transform.position += direction * Time.deltaTime * speed;
        transform.RotateAround(center, Vector3.forward, 360 * Time.deltaTime);

        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }
        lifetime = 0;
    }
}
