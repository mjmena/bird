using UnityEngine;
using System.Collections;
using Spell;
using System.Collections.Generic;
using System;

public class FireController : MonoBehaviour, SpellController {
    public GameObject fire_hawk_effect;
    public GameObject fire_ember_effect;
    private Queue<FireHawkEffect> projectiles = new Queue<FireHawkEffect>();
    private Queue<GameObject> embers = new Queue<GameObject>();
    private GameObject dashing_target = null; 
    private Movable body;

    void Start(){
        body = GetComponent<Movable>();
    }

    public void enable(){}
    public void disable(){
        while(projectiles.Count > 0){
            Destroy(projectiles.Dequeue().gameObject);
        }

        while(embers.Count > 0){
            Destroy(embers.Dequeue());
        }
    }

    public void cast(Style style){
        if(style == Style.Hawk){
            CastHawk();
        }else if(style == Style.Bear){
            Ray2D ray = new Ray2D(transform.position, transform.up);
            if(embers.Count > 0){
                float closest = float.MaxValue;
                foreach(GameObject ember in embers){
                    float angle = Math.Abs(Vector3.Angle(transform.up, ember.transform.position - transform.position));
                    if(angle < closest && angle < 15){
                        dashing_target = ember;
                        closest = angle;
                    }
//
//                    Vector3 cross = Vector3.Cross(ray.direction, ember.transform.position - (Vector3)ray.origin);
//                    if(cross.magnitude < closest && cross.z <= 0){
//                        dashing_target = ember;
//                        closest = cross.magnitude;
//                    }
                }
            }
        }
    }

    public void Update(){
        Debug.DrawRay(transform.position, transform.up, Color.black);

        foreach(GameObject ember in embers){
            Debug.DrawRay(transform.position, ember.transform.position - transform.position );
        }

        while(projectiles.Count > 0 && projectiles.Peek().IsExpired()){
            FireHawkEffect projectile = projectiles.Dequeue();

            GameObject go = Instantiate(fire_ember_effect, projectile.transform.position, projectile.transform.rotation) as GameObject;
            if(embers.Count > 20){
                GameObject ember = embers.Dequeue();
                if(ember != dashing_target){
                    Destroy(embers.Dequeue());
                }
            }
            embers.Enqueue(go);

            Destroy(projectile.gameObject);
        }

        if(dashing_target != null){
            Vector3 diff = dashing_target.transform.position - transform.position;
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90);
            body.SetSpeed(10);
            if((transform.position - dashing_target.transform.position).magnitude < 1){
                dashing_target = null;
                Destroy(dashing_target);
            }
        }
    }

    public Element get_element(){
        return Element.Fire;
    }

    private void CastHawk() {
        float spread = 30f;
        int shots = 5;
        float time = .3f;
        for (int i = 0; i < shots; i++) {
            float desired_rotation = (90 + transform.rotation.eulerAngles.z + (spread/2 - (spread / shots)*i));
            Vector3 unit_vector = new Vector3(Mathf.Cos(Mathf.Deg2Rad * desired_rotation), Mathf.Sin(Mathf.Deg2Rad * desired_rotation), 0);
            unit_vector.Normalize();
            StartCoroutine(spawnFireHawk(unit_vector, Quaternion.Euler(0, 0, -90 + desired_rotation), (time / shots) * i));
        }
    }


    private IEnumerator spawnFireHawk(Vector3 direction, Quaternion rotation, float delay) {
        yield return new WaitForSeconds(delay);
        GameObject go = Instantiate(fire_hawk_effect, transform.position + direction, rotation) as GameObject;
        go.tag = "ally";
        go.GetComponent<FireHawkEffect>().SetDirection(direction);
        projectiles.Enqueue(go.GetComponent<FireHawkEffect>());
    }

    void OnCollision(){
        
    }




}
