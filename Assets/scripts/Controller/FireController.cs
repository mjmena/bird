using UnityEngine;
using System.Collections;
using Spell;
using System.Collections.Generic;
using System.ComponentModel;

public class FireController : MonoBehaviour, SpellController {
    public GameObject fire_hawk_effect;
    public GameObject fire_ember_effect;
    private Queue<FireHawkEffect> projectiles = new Queue<FireHawkEffect>();
    private Queue<GameObject> embers = new Queue<GameObject>();

    public void enable(){}
    public void disable(){}

    public void cast(Style style){
        if(style == Style.Hawk){
            CastHawk();
        }
    }

    public void Update(){
        while(projectiles.Count > 0 && projectiles.Peek().IsExpired()){
            FireHawkEffect projectile = projectiles.Dequeue();

            GameObject go = Instantiate(fire_ember_effect, projectile.transform.position, projectile.transform.rotation) as GameObject;
            if(embers.Count >= 20){
                Destroy(embers.Dequeue());
            }
            embers.Enqueue(go);

            Destroy(projectile.gameObject);
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




}
