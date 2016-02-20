using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour {
    public int damage = 1;
    public int lifetime = 5;
    private float birth = 0;

    void Start()
    {
        birth = Time.time;
    }
    void Update()
    {
        if (birth + lifetime <= Time.time)
        {
            Debug.Log(birth + lifetime);
            Debug.Log(Time.time);
            Destroy(gameObject);
        }
    }
}
