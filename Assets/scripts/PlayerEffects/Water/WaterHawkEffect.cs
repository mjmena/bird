using UnityEngine;
using System.Collections;
using System.IO;

public class WaterHawkEffect : MonoBehaviour
{
    public GameObject orbiter; 
    public float speed = 15;
    public float lifetime = 2;

    void Start()
    {
        Destroy(gameObject, lifetime);
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
    }


    void FixedUpdate()
    {
        transform.position += transform.up * Time.fixedDeltaTime * speed; 
    }
}
