using UnityEngine;

public class RudeDudeProjectile : MonoBehaviour {
    public float speed;

    void Start(){
        Destroy(gameObject, 2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damageable>() != null)
        {
            collision.gameObject.GetComponent<Damageable>().TakeDamage(GetComponent<Damager>().damage);
        }
        Destroy(gameObject);
    }

    public void SetDirection(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
