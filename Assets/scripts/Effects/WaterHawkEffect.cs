using UnityEngine;
using System.Collections;

public class WaterHawkEffect : MonoBehaviour
{
    public GameObject orbiter; 
    private float birth;
    private float lifetime = 10;
    private float damage = 10;
    private float speed = 15;
    public Vector3 direction; 
     
    void Start()
    {
        birth = Time.time;
        spawnOrbiter(transform.position + transform.up);
        spawnOrbiter(transform.position + transform.right);
        spawnOrbiter(transform.position - transform.right);
        spawnOrbiter(transform.position - transform.up);
    }

    void spawnOrbiter(Vector3 position)
    {
        GameObject clone = Instantiate(orbiter, position, transform.rotation) as GameObject;
        clone.transform.parent = transform;
    }


    void Update()
    {

        transform.position += direction*Time.deltaTime*speed; 
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180 * Time.deltaTime);
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
