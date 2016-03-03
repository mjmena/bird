using UnityEngine;

public class CardinalShooterAI : MonoBehaviour
{
    public GameObject projectile;
    private float epsilon = .72f;

    void Update()
    {
        if (Mathf.Approximately(transform.rotation.eulerAngles.z % 90, 0))
        {
            spawnProjectile(transform.up);
            spawnProjectile(-transform.up);
            spawnProjectile(-transform.right);
            spawnProjectile(transform.right);
        }
    }

    void spawnProjectile(Vector3 direction)
    {    
        GameObject go = Instantiate(projectile, transform.position + direction, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI - 90)) as GameObject;
        go.tag = gameObject.tag;
        go.GetComponent<RudeDudeProjectile>().SetDirection(direction);
    }
}
