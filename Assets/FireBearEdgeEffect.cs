using UnityEngine;
using System.Collections;

public class FireBearEdgeEffect : MonoBehaviour {

    void Update()
    {
        transform.localScale = new Vector2(1, .05f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
