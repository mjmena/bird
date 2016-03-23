using UnityEngine;
using System.Collections;

public class WindTigerEffect : MonoBehaviour {
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
}
