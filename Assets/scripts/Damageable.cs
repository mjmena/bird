using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {
	public float max_health = 100f;
    public float health;

    private float lock_start = 0;
    private float lock_duration = 0;

    void Start () {
        health = max_health;
	}

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LockState(float duration)
    {
        lock_start = Time.time;
        lock_duration = duration;
    }

    public void TakeDamage(float damage)
    {
        if (lock_start + lock_duration <= Time.time)
        {
            health -= damage;
        }
    }
}