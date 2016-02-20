using UnityEngine;
using System.Collections;

public class CombatController : MonoBehaviour {
	private Rigidbody2D body;
	private MovementController movement_controller;
    private Damageable health;

	private enum Element {None, Wind, Earth, Water, Fire};
	private enum Style {None, Hawk, Bear, Tiger, Turtle};

	private Element current_element = Element.Wind;
	private Style current_style = Style.Hawk;

	private Element next_element = Element.None;

    public GameObject water_turtle;
    public GameObject fire_hawk;
    
	private float fire_hawk_projectile_speed = 40;
	private const int wind_hawk_dash_countdown = 300;
    
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		movement_controller = GetComponent<MovementController> ();
        health = GetComponent<Damageable> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (next_element == Element.None) {
				next_element = Element.Wind;
			} else {
				current_element = next_element;
				current_style = Style.Hawk;
				next_element = Element.None;
			}
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if (next_element == Element.None) {
				next_element = Element.Earth;
			} else {
				current_element = next_element;
				current_style = Style.Bear;
				next_element = Element.None;
			}
		} else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (next_element == Element.None) {
				next_element = Element.Water;
			} else {
				current_element = next_element;
				current_style = Style.Tiger;
				next_element = Element.None;
			}
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (next_element == Element.None) {
				next_element = Element.Fire;
			} else {
				current_element = next_element;
				current_style = Style.Turtle;
				next_element = Element.None;
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Using move: " + current_element.ToString () + ", " + current_style.ToString ());

			if (current_element == Element.Wind && current_style == Style.Hawk) {
				body.velocity = transform.up * movement_controller.speed * 5;
				movement_controller.LockState(.2f);

			} else if (current_element == Element.Earth && current_style == Style.Bear) {
                body.velocity = Vector3.zero;

                movement_controller.LockState (1f);
                health.LockState(1f);
                  
            } else if (current_element == Element.Water && current_style == Style.Turtle){
                GameObject go = Instantiate(water_turtle, transform.position, transform.rotation) as GameObject;
                go.name = "water_turtle_zone";
                go.tag = gameObject.tag;
                ZoneDamager water_turtle_zone = go.GetComponent<ZoneDamager>();
                water_turtle_zone.damage = 25;
                water_turtle_zone.lifetime = 1f;
                water_turtle_zone.radius = 1f;
                water_turtle_zone.expansion_rate = 1f;
            }
            else if (current_element == Element.Fire && current_style == Style.Hawk) {
				Vector3 direction = transform.up;
				Vector3 bullet_position = transform.position + direction;
				Vector3 bullet_velocity = direction * fire_hawk_projectile_speed;

				GameObject go = Instantiate(fire_hawk, bullet_position, transform.rotation) as GameObject;
				go.name = "fire_hawk_projectile";
                go.tag = gameObject.tag;

                go.GetComponent<Rigidbody2D>().velocity = bullet_velocity;
                Damager fire_hawk_projectile = go.GetComponent<Damager>();
                fire_hawk_projectile.damage = 10;
                fire_hawk_projectile.lifetime = 1;
            }
		}
	}
}
