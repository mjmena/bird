using UnityEngine;
using System.Collections;

public class WindBearEffect : MonoBehaviour {
    private float birth;
    private float lifetime = 5f;
    private float radius = 3f;
    private float velocity = .5f;
    private float acceleration = 0f;
    private float vortex_strength = 1.2f;

    void Start()
    {
        birth = Time.time;
        name = "wind_bear";
        transform.localScale = transform.localScale * radius;
    }

    void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }

        Vector3 unit_vector = transform.localScale;
        unit_vector.Normalize();

        velocity += acceleration * Time.deltaTime;
        transform.localScale = transform.localScale + new Vector3(radius, radius, radius) * velocity * Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "enemy")
        {
            Vector3 toward_center_vector = transform.position - collider.transform.position;
            Vector3 toward_center_vector_strength = (toward_center_vector / toward_center_vector.magnitude) * vortex_strength;

            collider.GetComponent<Rigidbody2D>().velocity += new Vector2(toward_center_vector_strength.x, toward_center_vector_strength.y);
        }
    }
}
