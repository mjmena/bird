using UnityEngine;


public class EarthBoulderEffect : MonoBehaviour {
    public Movable source; 
    public Rigidbody2D body; 
    private float direction = 1;
    private float rotation = 360 * 4; 
    private static float max_radius = 8f; 
    private static float min_radius = 2f;
    public float current_radius = max_radius;
    private float radius_delta = 1f;
    private bool is_tethered = true; 

    void Start(){
        current_radius = min_radius;
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(is_tethered){
            Vector3 desired_position = source.GetNextPosition() + (transform.position - source.GetNextPosition()).normalized * current_radius;
            transform.position = desired_position;
            transform.RotateAround(source.transform.position, Vector3.forward, direction * rotation/current_radius  * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        direction = -direction;
    }
        
    public void IncreaseRadius(){
        current_radius += radius_delta;
        if(current_radius >= max_radius){
            current_radius = max_radius;
        }
    }

    public void DecreaseRadius() {
        current_radius -= radius_delta;
        if(current_radius <= min_radius){
            current_radius = min_radius; 
        }
    }

    public void Untether(){
        is_tethered = false;
        body.velocity = -direction * transform.right * 20;
        Destroy(gameObject, 4);
    }

    public bool IsTethered(){
        return is_tethered;
    }
}
