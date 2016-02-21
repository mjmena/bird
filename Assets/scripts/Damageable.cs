using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {
	public float max_health = 100f;
    public float current_health;

    private float lock_start = 0;
    private float lock_duration = 0;

    void Start () {
        current_health = max_health;
	}

    void Update()
    {
        if(current_health <= 0)
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
            current_health -= damage;
        }
    }

    public void Damage(float damage)
    {
        if (lock_start + lock_duration <= Time.time)
        {
            current_health -= damage;
        }
    }

    public void Heal(float heal)
    {
        current_health += heal;
        if(current_health > max_health)
        {
            current_health = max_health;
        }
    }
}