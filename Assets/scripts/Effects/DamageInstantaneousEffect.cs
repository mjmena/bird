using UnityEngine;
using System.Collections;

public class DamageInstantaneousEffect : Effect{
    public float damage;

    new void Start()
    {
        base.Start();
        SetLifetime(float.MaxValue);
    }

    new void Update()
    {
        base.Update();
        SetLifetime(0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }
    }

    public void SetDamage(float damage)
    {
        this.damage = damage; 
    }
}
