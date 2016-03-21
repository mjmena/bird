using UnityEngine;
using System.IO;

public class Boulder : MonoBehaviour {
    public Movable source; 
    public float radius;

    private float rotation = 360; 
    private float max_radius = 8f; 
    private float min_radius = 2f;
    private float radius_delta = .5f;


    void Start(){
        radius = 5f;
    }

    void FixedUpdate()
    {
        Vector3 desired_position = source.transform.position + (transform.position - source.transform.position).normalized * radius;
        transform.position = Vector3.MoveTowards(transform.position, desired_position, .5f);
        transform.RotateAround(source.transform.position, Vector3.forward, rotation * Time.fixedDeltaTime);
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
