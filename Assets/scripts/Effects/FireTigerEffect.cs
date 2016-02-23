using UnityEngine;
using System.Collections;

public class FireTigerEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 1;
    private float radius = 3;
    private float damage = 50;
    public Transform source;

    void Start()
    {
        birth = Time.time;
        name = "fire_tiger";
    }

    void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //transform.rotation = source.rotation;
        //transform.position = source.position + (source.position - transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Damageable>() != null)
        {
            collider.GetComponent<Damageable>().TakeDamage(damage);
        }
    }
    
}
