using UnityEngine;
using System.Collections;

public class VortexPulseEffect : PulseEffect {
    private float vortex_strength;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "enemy")
        {
            Vector3 toward_center_vector = transform.position - collider.transform.position;
            Vector3 toward_center_vector_strength = (toward_center_vector / toward_center_vector.magnitude) * vortex_strength;

            collider.GetComponent<Rigidbody2D>().velocity += new Vector2(toward_center_vector_strength.x, toward_center_vector_strength.y);
        }
    }

    public void SetVortexStrength(float vortex_strength)
    {
        this.vortex_strength = vortex_strength/10;
    }
}
