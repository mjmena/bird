using UnityEngine;


public class EarthBoulderEffect : MonoBehaviour {
    public Movable source; 
    public Rigidbody2D body; 
    public float radius;
    private float direction = 1;
    private float rotation = 360 * 4; 
    private float max_radius = 8f; 
    private float min_radius = 2f;
    private float radius_delta = 1f;
    private bool is_tethered = true; 

    void Start(){
        radius = min_radius;
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(is_tethered){
            Vector3 desired_position = source.GetNextPosition() + (transform.position - source.GetNextPosition()).normalized * radius;
            transform.position = desired_position;
            transform.RotateAround(source.transform.position, Vector3.forward, direction * rotation/radius  * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        direction = -direction;
    }
        
    public void IncreaseRadius(){
        radius += radius_delta;
        if(radius >= max_radius){
            radius = max_radius;
        }
    }

    public void DecreaseRadius() {
        radius -= radius_delta;
        if(radius <= min_radius){
            radius = min_radius; 
        }
    }

    public void Untether(){
        is_tethered = false;
        body.velocity = -direction * transform.right * 20;
        GetComponent<ActivatedTimed>().Activate();
    }

    public bool IsTethered(){
        return is_tethered;
    }
}
