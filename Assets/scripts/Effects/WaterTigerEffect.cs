using UnityEngine;
using System.Collections;

public class WaterTigerEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 1;
    private float radius = 3;
    private Transform following;

    void Start()
    {
        birth = Time.time;
        name = "water_tiger";
        transform.localScale = transform.localScale * radius;
    }

    void Update()
    {
        transform.position = following.position;
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "ally")
        {
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = -collider.gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }

    public void SetFollowing(Transform following)
    {
        this.following = following;
    }
}
