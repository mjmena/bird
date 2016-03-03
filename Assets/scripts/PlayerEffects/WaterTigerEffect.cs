using UnityEngine;

public class WaterTigerEffect : MonoBehaviour
{
    private float radius = 2;
    
    void Start()
    {
        transform.localScale = transform.localScale * radius;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "ally")
        {
            Damager damager = collider.GetComponent<Damager>();
            if (damager != null)
            {
                GameObject.FindGameObjectWithTag("player").GetComponent<Damageable>().Heal(damager.damage);
                collider.GetComponent<Timed>().SetLifetime(0);
            }
            
        }
    }
}
