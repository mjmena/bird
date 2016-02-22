using UnityEngine;
using System.Collections;

public class WindTurtleEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = .5f;
    private float radius = .5f;
    private float velocity = 40f;
    private float acceleration = -10f;
    private Transform following;

    void Start()
    {
        birth = Time.time;
        name = "wind_turtle";
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

    public void SetFollowing(Transform following)
    {
        this.following = following;
    }
}
