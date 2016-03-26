using UnityEngine;
using System.Collections;
using Spell;

public class EarthController : MonoBehaviour, SpellController {
    public GameObject boulder_effect; 
    private EarthBoulderEffect boulder = null; 

    public void enable(){
        StartCoroutine(spawn_boulder(0));
    }

    public void cast(Style style){
        if(style == Style.Hawk){
            boulder.IncreaseRadius();
        } else if(style == Style.Bear){
            boulder.DecreaseRadius();
        } else if(style == Style.Tiger){
            if(boulder.IsTethered()){
                boulder.Untether();
                StartCoroutine(spawn_boulder(.5f));   
            }
        }
    }

    public void disable(){
        Destroy(boulder.gameObject);
    }

    public Element get_element(){
        return Element.Earth;
    }

    private IEnumerator spawn_boulder(float delay){
        yield return new WaitForSeconds(delay);
        GameObject go = Instantiate(boulder_effect, transform.position + transform.up, transform.rotation) as GameObject;
        boulder = go.GetComponent<EarthBoulderEffect>();
        boulder.source = GetComponent<Movable>(); 
    }
}
