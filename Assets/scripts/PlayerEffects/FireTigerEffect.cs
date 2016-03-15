using UnityEngine;

public class FireTigerEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 5f;
    private float damage = 10;

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
        if (collider.GetComponent<Damageable>() != null)
        {
            collider.GetComponent<Damageable>().TakeDamage(damage);
        }
    }
}
