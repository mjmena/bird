using UnityEngine;
using System.Collections;

public class WaterHawkOrbiterEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 10;
    private float damage = 10;

    void Start()
    {
        birth = Time.time;
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
