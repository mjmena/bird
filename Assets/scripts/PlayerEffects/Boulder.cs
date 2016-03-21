using UnityEngine;
using System.IO;

public class Boulder : MonoBehaviour {
    public Movable source; 
    public float radius;

    private float rotation = 360 * 4; 
    private float max_radius = 8f; 
    private float min_radius = 2f;
    private float radius_delta = 1f;


    void Start(){
        radius = min_radius;
    }

    void FixedUpdate()
    {
        Vector3 desired_position = source.GetNextPosition() + (transform.position - source.GetNextPosition()).normalized * radius;
        transform.position = desired_position;
        transform.RotateAround(source.transform.position, Vector3.forward, rotation/radius  * Time.fixedDeltaTime);
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
}
