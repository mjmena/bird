using UnityEngine;
using System.Collections;

public class DelayedEffect : Effect {
    public GameObject effect;
    
	new void Start () {
        base.Start();
        GetComponent<Collider2D>().enabled = false;
	}

    new void Update()
    {
        if(GetBirth() + GetLifetime() <= Time.time)
        {
            Instantiate(effect, transform.position, transform.rotation);
        }
        base.Update();

    }    
}
