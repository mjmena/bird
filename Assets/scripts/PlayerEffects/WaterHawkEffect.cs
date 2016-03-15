using UnityEngine;
using System.Collections;

public class WaterHawkEffect : MonoBehaviour
{
    public GameObject orbiter; 
    private float birth;
    private float lifetime = 2;
    private float damage = 30;
    private float speed = 15;
     
    void Start()
    {
        birth = Time.time;
        spawnOrbiter(transform.position + transform.right);
		spawnOrbiter(transform.position + 2*transform.right);
		spawnOrbiter(transform.position - transform.right);
		spawnOrbiter(transform.position - 2*transform.right);
    }

    void spawnOrbiter(Vector3 position)
    {
        GameObject clone = Instantiate(orbiter, position, transform.rotation) as GameObject;
        WaterHawkOrbiterEffect orbiter_effect = clone.GetComponent<WaterHawkOrbiterEffect>();
        orbiter_effect.center = transform.position;
        orbiter_effect.direction = transform.up;
        orbiter_effect.speed = speed;
        orbiter_effect.lifetime = lifetime;
        orbiter_effect.damage = damage;
    }


    void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
        transform.position += transform.up*Time.deltaTime*speed; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
        }
        lifetime = 0;
    }
}
