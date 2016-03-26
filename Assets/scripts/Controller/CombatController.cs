using UnityEngine;
using Spell;
using System;

public class CombatController : MonoBehaviour {
    private SpellController current_controller;

    void Start() {
        set_element(Element.Wind);
    }

    void Update() {
        Style current_style = Style.None; 
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            current_style = Style.Hawk;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            current_style = Style.Bear; 
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            current_style = Style.Tiger;         
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            current_style = Style.Turtle;         
        }

        current_controller.cast(current_style);

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            set_element(Element.Wind);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            set_element(Element.Earth);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            set_element(Element.Fire);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            set_element(Element.Water);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            set_element(Element.Water);
        }
    }

    private void set_element(Element element){
        if(current_controller != null){
            current_controller.disable();
        }

        current_controller = GetComponent(element.ToString() + "Controller") as SpellController;
        current_controller.enable();
    }
        
    public int GetCurrentElement() {
        return (int)current_controller.get_element();
    }
}
