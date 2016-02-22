using UnityEngine;
using System.Collections;

public class FireBearEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 5;
    private float damage = 40;

    void Start()
    {
        birth = Time.time;
    }

    void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Damageable>() != null)
        {
            collider.GetComponent<Damageable>().TakeDamage(damage);
            lifetime = 0;
        }
    }
}
