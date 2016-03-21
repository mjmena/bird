using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine.Networking.Types;

public class CombatController : MonoBehaviour {
    private Element current_element = Element.Wind;

    public GameObject boulder_effect; 
    public Boulder boulder = null; 

    void Update() {

        if(current_element != Element.Earth && boulder != null){
            Destroy(boulder.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            castElementStyleCombo(current_element, Style.Hawk); 
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            castElementStyleCombo(current_element, Style.Bear); 
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
        
        }



        if (Input.GetKeyDown(KeyCode.U)) {
            current_element = Element.Wind;
        } else if (Input.GetKeyDown(KeyCode.I)) {
            current_element = Element.Earth;
            GameObject go = Instantiate(boulder_effect, transform.position + transform.up, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
            boulder = go.GetComponent<Boulder>();
            boulder.source = GetComponent<Movable>();
        } else if (Input.GetKeyDown(KeyCode.O)) {
            current_element = Element.Water;
        } else if (Input.GetKeyDown(KeyCode.P)) {
            current_element = Element.Fire;
        }
   }


    private void castElementStyleCombo(Element element, Style style) {
        if(element == Element.Earth){
            castEarthStyleCombo(style);
        }
    }

    private void castEarthStyleCombo(Style style){
        if(style == Style.Hawk){
            boulder.IncreaseRadius();
        } else if(style == Style.Bear){
            boulder.DecreaseRadius();
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
