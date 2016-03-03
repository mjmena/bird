using UnityEngine;
using System.Collections;

public class Timed : MonoBehaviour {
    private float birth;
    public float lifetime;
    
    void Start()
    {
        birth = Time.time;
    }

    void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    public void SetLifetime(float lifetime)
    {
        birth = Time.time;
        this.lifetime = lifetime;
    }

    public float GetBirth()
    {
        return birth;
    }
}
