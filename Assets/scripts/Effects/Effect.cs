using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour
{
    private float lifetime;
    private float birth;

    protected void Start()
    {
        birth = Time.time;
    }

    protected void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    public float GetBirth()
    {
        return birth;
    }

    public float GetLifetime()
    {
        return lifetime;
    }

    public void SetLifetime(float lifetime)
    {
        this.lifetime = lifetime;
    }
}
