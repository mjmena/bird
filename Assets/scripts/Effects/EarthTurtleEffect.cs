using UnityEngine;

public class EarthTurtleEffect : MonoBehaviour
{
    private float birth;
    public float lifetime;
    public float damage = 30;
    public Movable source; 
    public float rotation = 360; 

    void Start()
    {
        birth = Time.time;
    }

    void Update()
    {

        Vector3 desired_position = source.transform.position + (transform.position - source.transform.position).normalized * (Time.time % 5f + 1);
        transform.position = Vector3.MoveTowards(transform.position, desired_position, .1f);
        transform.RotateAround(source.transform.position, Vector3.forward, rotation * Time.deltaTime);

        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }
        rotation = -rotation;
    }
}
