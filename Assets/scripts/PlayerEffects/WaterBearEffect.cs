using UnityEngine;
using System.Collections;

public class WaterBearEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 3;

    private float radius = 4;
    private float heal = 50;

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

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null && collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<Damageable>().Heal(heal * Time.deltaTime / lifetime);
        }
    }
}
