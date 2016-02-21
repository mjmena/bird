using UnityEngine;
using System.Collections;

public class DamageProjectileEffect : Effect {
    public float damage;
    private Rigidbody2D body;

    new void Start () {
        base.Start();
        body = GetComponent<Rigidbody2D>();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }

        SetLifetime(0);
    }
}
