using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine.Networking.Types;

public class CombatController : MonoBehaviour {
    private Element current_element = Element.Wind;

    public GameObject wind_tiger_effect;
    private void castWindStyleCombo(Style style){
        if(style == Style.Tiger){
            GameObject clone = Instantiate(wind_tiger_effect, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<WindTigerEffect>().source = GetComponent<Movable>();
        }
    }

    public GameObject boulder_effect; 
    private EarthBoulderEffect boulder = null; 
    private void castEarthStyleCombo(Style style){
        if(style == Style.Hawk){
            boulder.IncreaseRadius();
        } else if(style == Style.Bear){
            boulder.DecreaseRadius();
        } else if(style == Style.Tiger){
            boulder.Untether();
        }
    }

    public GameObject water_hawk_effect; 
    private void castWaterStyleCombo(Style style){
        if(style == Style.Hawk){
            Instantiate(water_hawk_effect, transform.position + transform.up + transform.up, transform.rotation);
        } else if(style == Style.Bear){
        }
    }
        
    void Update() {
        if(boulder != null){
            if(current_element != Element.Earth){
                Destroy(boulder.gameObject);
            }else{
                if(!boulder.IsTethered()){
                    GameObject go = Instantiate(boulder_effect, transform.position + transform.up, transform.rotation) as GameObject;
                    boulder = go.GetComponent<EarthBoulderEffect>();
                    boulder.source = GetComponent<Movable>();
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            castElementStyleCombo(current_element, Style.Hawk); 
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            castElementStyleCombo(current_element, Style.Bear); 
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            castElementStyleCombo(current_element, Style.Tiger);         
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            castElementStyleCombo(current_element, Style.Turtle);         
        }



        if (Input.GetKeyDown(KeyCode.U)) {
            current_element = Element.Wind;
        } else if (Input.GetKeyDown(KeyCode.I)) {
            current_element = Element.Earth;
            GameObject go = Instantiate(boulder_effect, transform.position + transform.up, transform.rotation) as GameObject;
            boulder = go.GetComponent<EarthBoulderEffect>();
            boulder.source = GetComponent<Movable>();
        } else if (Input.GetKeyDown(KeyCode.O)) {
            current_element = Element.Water;
        } else if (Input.GetKeyDown(KeyCode.P)) {
            current_element = Element.Fire;
        }
   }


    private void castElementStyleCombo(Element element, Style style) {
        if(element == Element.Wind){
            castWindStyleCombo(style);
        }else if(element == Element.Earth){
            castEarthStyleCombo(style);
        }else if(element == Element.Water){
            castWaterStyleCombo(style);
        }
    }

    public int GetCurrentElement(){
        return (int) current_element;
    }

    private enum Element {
        None,
        Wind,
        Earth,
        Water,
        Fire}

    ;

    private enum Style {
        None,
        Hawk,
        Bear,
        Tiger,
        Turtle}

    ;
}
