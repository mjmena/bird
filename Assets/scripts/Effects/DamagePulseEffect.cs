using UnityEngine;
using System.Collections;

public class DamagePulseEffect : PulseEffect {
    private float damage;

    void OnTriggerEnter2d(Collider2D collider)
    {
        OnTriggerStay2D(collider);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (gameObject.tag != collider.tag)
        {
            collider.GetComponent<Damageable>().TakeDamage(damage * Time.deltaTime);
        }
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
