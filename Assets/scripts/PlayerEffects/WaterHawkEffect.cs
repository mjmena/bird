using UnityEngine;
using System.Collections;

public class WaterHawkEffect : MonoBehaviour
{
    public GameObject orbiter; 
    public float speed = 15;
     
    void Start()
    {
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
    }


    void FixedUpdate()
    {
        transform.position += transform.up*Time.fixedDeltaTime*speed; 
    }
}
