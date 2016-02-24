using UnityEngine;
using System.Collections;

public class CardinalShooterAI : MonoBehaviour
{
    public GameObject projectile;
    public float projectile_speed;
    public float shoot_cooldown;
    private float last_shot = 0; 

    void Update()
    {
        if (last_shot + shoot_cooldown < Time.time)
        {
            spawnProjectile(transform.up);
            spawnProjectile(-transform.up);
            spawnProjectile(-transform.right);
            spawnProjectile(transform.right);
            
            last_shot = Time.time;
        }
    }

    void spawnProjectile(Vector3 direction)
    {    
        GameObject go = Instantiate(projectile, transform.position + direction, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI - 90)) as GameObject;
        
        go.name = "enemy_projectile";
        go.tag = gameObject.tag;
        go.GetComponent<FireHawkEffect>().SetDirection(direction);
    }
}
