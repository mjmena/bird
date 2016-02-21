using UnityEngine;
using System.Collections;

public class WaterTigerEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 1;
    private float radius = 3;

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

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = -collision.gameObject.GetComponent<Rigidbody2D>().velocity;
    }
}
