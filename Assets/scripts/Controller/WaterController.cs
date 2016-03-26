using UnityEngine;
using Spell;

public class WaterController : MonoBehaviour, SpellController {
    public GameObject water_hawk_effect; 

    public void cast(Style style){
        if(style == Style.Hawk){
            Instantiate(water_hawk_effect, transform.position + transform.up + transform.up, transform.rotation);
        }
    }

    public void enable(){}

    public void disable(){}

    public Element get_element(){
        return Element.Water;
    }
}
