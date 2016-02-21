using UnityEngine;
using System.Collections;

public class DamagePulseEffect : PulseEffect {
    public float damage;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (gameObject.tag != collider.tag)
        {
            collider.GetComponent<Damageable>().TakeDamage(damage * Time.deltaTime);
        }
    }
}
