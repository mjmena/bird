using UnityEngine;
using Spell;

public class WindController : MonoBehaviour, SpellController {
    public GameObject wind_tiger_effect; 

    public void cast(Style style){
        if(style == Style.Tiger){
            GameObject clone = Instantiate(wind_tiger_effect, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<WindTigerEffect>().source = GetComponent<Movable>();
        }
    }

    public void enable(){}

    public void disable(){}

    public Element get_element(){
        return Element.Wind;
    }
}
