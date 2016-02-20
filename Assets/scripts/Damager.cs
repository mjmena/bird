using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour {
    public int damage;
    public float lifetime;
    private float birth = 0;

    protected void Start() {
        birth = Time.time;
    }

    protected void Update() {
        if (birth + lifetime <= Time.time) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag != collision.gameObject.tag){
            if(collision.gameObject.GetComponent<Damageable>() != null){
                collision.gameObject.GetComponent<Damageable>().TakeDamage(damage);
            }
            lifetime = 0;
        }
    }
}
