using UnityEngine;
using System.Collections;

public class WaterTurtleEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 4f;
    private float damage = 25f;
    private float radius = 2f;
    private float velocity = 2f;
    private float acceleration = -1f;
    private Transform following;
    
    void Start()
    {
        birth = Time.time;
        transform.localScale = transform.localScale * radius;
    }

    void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }

        transform.position = following.position;

        Vector3 unit_vector = transform.localScale;
        unit_vector.Normalize();

        velocity += acceleration * Time.deltaTime;
        transform.localScale = transform.localScale + new Vector3(radius, radius, radius) * velocity * Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<Damageable>() != null)
        {
            collider.GetComponent<Damageable>().TakeDamage(damage * Time.deltaTime);
        }
    }

    public void SetFollowing(Transform following)
    {
        this.following = following;
    }
}
