using UnityEngine;
using System.Collections;

public class WindBearEffect : MonoBehaviour {
    private float birth;
    private float delay = 2f;
    private float lifetime = float.MaxValue;
    private float damage = 49f; 

    void Start()
    {
        birth = Time.time;
        GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (birth + delay + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
        else if (birth + delay <= Time.time)
        {
            lifetime = 0;
            GetComponent<Collider2D>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }
    }
}
