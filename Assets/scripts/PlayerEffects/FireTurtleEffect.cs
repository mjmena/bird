using UnityEngine;

public class FireTurtleEffect : MonoBehaviour
{
    private float birth;
    private float delay = 2f;
    private float lifetime = .1f;

    private float radius = .5f;
    private float velocity = 50f;
    private float damage = 20;

    void Start()
    {
        birth = Time.time;
    }

    void Update()
    {

        if (birth + delay + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
        else if (birth + delay <= Time.time)
        {
            transform.localScale += new Vector3(radius, radius, radius) * velocity * Time.deltaTime;
        }
        else
        {
            velocity += velocity * Time.deltaTime;
            damage += damage * Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }
    }

    public void Explode()
    {
        birth = Time.time;
        delay = 0; 
    }
}
