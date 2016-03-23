using UnityEngine;

public class ActivatedTimed : MonoBehaviour {
    private float birth;
    public float lifetime;
    private bool is_activated;

    public void Activate(){
        is_activated = true; 
        birth = Time.time;
    }

    void Update()
    {
        if (is_activated && birth + lifetime <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    public float GetBirth()
    {
        return birth;
    }
}
