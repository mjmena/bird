using UnityEngine;
using System.Collections;

public class WindTigerEffect : MonoBehaviour{
    private float damage = 30;
    private bool has_collided = false; 


    void Update()
    {
        if (has_collided)
        {
            Destroy(gameObject);
        }

        has_collided = true; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }
    }
}
