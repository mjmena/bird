using UnityEngine;
using System.Collections;
using System.Threading;

public class WindTigerEffect : MonoBehaviour {
    public Movable source;
    private Timed delay;

    void Start(){
        delay = new Timed(2000);    
    }

    void FixedUpdate()
    {
        if(delay.IsElapsed())
        {
            transform.position = (Vector3) Vector2.MoveTowards(transform.position, source.transform.position + source.transform.up, 50*Time.fixedDeltaTime);

            if (transform.position == source.transform.position + source.transform.up)
            {
                Destroy(gameObject);
            }
      }
    }
}
