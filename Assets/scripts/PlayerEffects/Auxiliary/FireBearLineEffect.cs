using UnityEngine;

public class FireBearLineEffect : MonoBehaviour {

    private bool isConnected = false;
    public Vector2 endPoint;
    public float scaling_rate = 10f;
    void FixedUpdate()
    {
        if (!isConnected)
        {
            transform.localScale += new Vector3(0, scaling_rate * Time.fixedDeltaTime, 0);
            transform.position += transform.up * scaling_rate * .5f * Time.fixedDeltaTime;
        }

        if (GetComponent<BoxCollider2D>().OverlapPoint(endPoint)){
            isConnected = true; 
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<Damageable>() != null)
        {
            collider.GetComponent<Damageable>().TakeDamage(GetComponent<Damager>().damage * Time.deltaTime);
        }
    }    
}
