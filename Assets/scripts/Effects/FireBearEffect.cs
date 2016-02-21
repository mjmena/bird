using UnityEngine;
using System.Collections;

public class FireBearEffect : MonoBehaviour
{
    private float birth;
    private float lifetime = 5;

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
}
