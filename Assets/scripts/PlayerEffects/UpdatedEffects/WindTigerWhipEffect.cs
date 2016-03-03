using UnityEngine;
using System.Collections;

public class WindTigerWhipEffect : MonoBehaviour {
    public float delay = 2f;
    public Movable source;
    private bool hasArrived = false; 

    void FixedUpdate()
    {
        if(GetComponent<Timed>().GetBirth() + delay < Time.fixedTime)
        {
            transform.position = (Vector3) Vector2.MoveTowards(transform.position, source.transform.position + source.transform.up, 50*Time.fixedDeltaTime);

            if (transform.position == source.transform.position + source.transform.up && !hasArrived)
            {
                GetComponent<Timed>().SetLifetime(.1f);
                delay = 0f;
                hasArrived = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Damageable>() != null)
        {
            collider.GetComponent<Damageable>().TakeDamage(GetComponent<Damager>().damage);
        }
    }
}
