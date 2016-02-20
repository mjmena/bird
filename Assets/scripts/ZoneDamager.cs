using UnityEngine;
using System.Collections;

public class ZoneDamager : Damager {
    public float radius;
    public float expansion_rate;
    
    new void Start ()
    {
        base.Start();
        transform.localScale = transform.localScale * radius;
	}

	new void Update ()
    {
        base.Update();
        transform.localScale = transform.localScale + transform.localScale * radius * expansion_rate * Time.deltaTime;
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        if(gameObject.tag != collider.tag)
        {
            collider.GetComponent<Damageable>().TakeDamage(damage * Time.deltaTime);
        }
    }
}
