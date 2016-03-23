using UnityEngine;

public class Damager : MonoBehaviour {
    public float damage; 
    public bool destroyable = false; 
    public bool dot = false;

    void OnCollisionEnter2D(Collision2D collision){
        Damageable health = collision.collider.GetComponent<Damageable>();
        if(health != null){
            health.TakeDamage(damage);
        }

        if(destroyable){
            Destroy(gameObject);    
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(!dot){
            Damageable health = collider.GetComponent<Damageable>();
            if(health != null){
                health.TakeDamage(damage);
            }
            if(destroyable){
                Destroy(gameObject);    
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        if(dot){
            Damageable health = collider.GetComponent<Damageable>();
            if(health != null){
                health.TakeDamage(damage * Time.fixedDeltaTime);
            }
        }

    }
}
