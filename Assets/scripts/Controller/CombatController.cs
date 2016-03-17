using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CombatController : MonoBehaviour
{
    private Rigidbody2D body;
    private Movable movable;
    private Damageable health;
    private enum Element { None, Wind, Earth, Water, Fire };
    private enum Style { None, Hawk, Bear, Tiger, Turtle };

    private Element current_element = Element.Wind;
    private Style current_style = Style.Hawk;

    private Element next_element = Element.None;
    public GameObject wind_tiger_whip;
    public GameObject wind_turtle;
    public GameObject wind_bear;
    public GameObject earth_hawk;
    public GameObject earth_turtle;
    public GameObject earth_tiger;
    public GameObject water_hawk;
    public GameObject water_bear;
    public GameObject water_turtle;
    public GameObject water_tiger;
    public GameObject fire_hawk;
    public GameObject fire_bear;
    private FireBearEffect current_fire_bear_effect;
    public GameObject fire_tiger;
    public GameObject fire_turtle;
    private FireTurtleEffect fire_turtle_effect;

    void Start()
    {
        movable = GetComponent<Movable>();
        health = GetComponent<Damageable>();
    }

	void Update() {
		if (fire_turtle_effect != null && Input.GetKeyUp(KeyCode.RightArrow)) {
			fire_turtle_effect.Explode();
			fire_turtle_effect = null;
		}

		current_style = Style.None;

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			current_style = Style.Hawk;
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			current_style = Style.Bear;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			current_style = Style.Tiger;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			current_style = Style.Turtle;
		}

		if (Input.GetKeyDown(KeyCode.U)) {
			current_element = Element.Wind;
		} else if (Input.GetKeyDown(KeyCode.I)) {
			current_element = Element.Earth;
		} else if (Input.GetKeyDown(KeyCode.O)) {
			current_element = Element.Water;
		} else if (Input.GetKeyDown(KeyCode.P)) {
			current_element = Element.Fire;
		}

		castElementStyleCombo();
	}

    void UpdateOld()
    {
        if (fire_turtle_effect != null && Input.GetKeyUp(KeyCode.RightArrow))
        {
            fire_turtle_effect.Explode();
            fire_turtle_effect = null;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (next_element == Element.None)
            {
                next_element = Element.Wind;
            }
            else {
                current_element = next_element;
                current_style = Style.Hawk;
                next_element = Element.None;
                castElementStyleCombo();

            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (next_element == Element.None)
            {
                next_element = Element.Earth;
            }
            else {
                current_element = next_element;
                current_style = Style.Bear;
                next_element = Element.None;
                castElementStyleCombo();

            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (next_element == Element.None)
            {
                next_element = Element.Water;
            }
            else {
                current_element = next_element;
                current_style = Style.Tiger;
                next_element = Element.None;
                castElementStyleCombo();

            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (next_element == Element.None)
            {
                next_element = Element.Fire;
            }
            else {
                current_element = next_element;
                current_style = Style.Turtle;
                next_element = Element.None;
                castElementStyleCombo();

            }
        }

        if (Input.GetKeyDown("`"))
        {
            Destroy(gameObject);
        }
    }

    public int GetNextElement()
    {
        return (int)next_element;
    }

    private void castElementStyleCombo()
    {
		if (current_style == Style.None) {
			return;
		}
        Debug.Log("Using " + current_element + " + " + current_style);
        if (current_element == Element.Wind && current_style == Style.Hawk)
        {
            GetComponent<Animator>().SetBool("is_dashing", true);
			movable.SetSpeed(5f, .2f);
        }
        else if (current_element == Element.Wind && current_style == Style.Tiger)
        {
            GameObject clone = Instantiate(wind_tiger_whip, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            clone.GetComponent<WindTigerWhipEffect>().source = GetComponent<Movable>();
        }
        else if (current_element == Element.Wind && current_style == Style.Turtle)
        {
            GameObject clone = Instantiate(wind_turtle, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            clone.GetComponent<WindTurtleEffect>().SetFollowing(transform);
        }
        else if (current_element == Element.Wind && current_style == Style.Bear)
        {
            GameObject clone = Instantiate(wind_bear, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if (current_element == Element.Earth && current_style == Style.Hawk)
        {
            GameObject clone = Instantiate(earth_hawk, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            clone.GetComponent<Rigidbody2D>().velocity = transform.up * 2;
			movable.SetSpeed(-2.5f, .2f);
            GetComponent<Animator>().SetBool("is_dashing", true);
        }
        else if (current_element == Element.Earth && current_style == Style.Bear)
        {
            movable.SetSpeed(0, 1f);
            GetComponent<Animator>().SetBool("is_walking", false);
        }
        else if (current_element == Element.Earth && current_style == Style.Tiger)
        {
			movable.SetRotation(-180f, .125f);
            GameObject go = Instantiate(earth_tiger, transform.position + (-transform.up - transform.right).normalized, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 135)) as GameObject;
            go.transform.parent = transform;
        }
        else if (current_element == Element.Earth && current_style == Style.Turtle)
        {
            GameObject clone = Instantiate(earth_turtle, transform.position + transform.right, transform.rotation) as GameObject;
            EarthTurtleEffect earth_turtle_effect = clone.GetComponent<EarthTurtleEffect>();
            earth_turtle_effect.source = movable;
            earth_turtle_effect.lifetime = 10;
        }
        else if (current_element == Element.Water && current_style == Style.Hawk)
        {
            Instantiate(water_hawk, transform.position + transform.up + transform.up, transform.rotation);
        }
        else if (current_element == Element.Water && current_style == Style.Bear)
        {
            Instantiate(water_bear, transform.position, transform.rotation);
        }
        else if (current_element == Element.Water && current_style == Style.Turtle)
        {
            GameObject clone = Instantiate(water_turtle, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            clone.GetComponent<WaterTurtleEffect>().SetFollowing(transform);
        }
        else if (current_element == Element.Water && current_style == Style.Tiger)
        {
            GameObject clone = Instantiate(water_tiger, transform.position, transform.rotation) as GameObject;
            clone.transform.SetParent(transform);
        }
        else if (current_element == Element.Fire && current_style == Style.Hawk)
        {
            castFireHawk(transform.up, transform.rotation);
            castFireHawk(transform.up + transform.right, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 45));
            castFireHawk(transform.up - transform.right, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 45));
        }
        else if (current_element == Element.Fire && current_style == Style.Bear)
        {
            GameObject clone = Instantiate(fire_bear, transform.position + transform.up, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            FireBearEffect fire_bear_effect = clone.GetComponent<FireBearEffect>();
            if(current_fire_bear_effect != null)
            {
                current_fire_bear_effect.ExplodeTowards((fire_bear_effect.transform.position - current_fire_bear_effect.transform.position).normalized , fire_bear_effect.transform.position + fire_bear_effect.transform.up * .5f);
                fire_bear_effect.ExplodeTowards((current_fire_bear_effect.transform.position - fire_bear_effect.transform.position).normalized, current_fire_bear_effect.transform.position - current_fire_bear_effect.transform.up * .5f);
                current_fire_bear_effect = null;
            }
            else
            {
                current_fire_bear_effect = fire_bear_effect;
            }
        }
        else if (current_element == Element.Fire && current_style == Style.Tiger)
        {
			spawnFireTiger(transform.right * 1.2f, transform.rotation);
        }
        else if (current_element == Element.Fire && current_style == Style.Turtle)
        {
            GameObject clone = Instantiate(fire_turtle, transform.position, transform.rotation) as GameObject;
            clone.transform.parent = transform;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            fire_turtle_effect = clone.GetComponent<FireTurtleEffect>();
        }
    }

    void castFireHawk(Vector3 direction, Quaternion rotation)
    {
        GameObject go = Instantiate(fire_hawk, transform.position + direction, rotation) as GameObject;
        go.tag = "ally";
        go.GetComponent<FireHawkEffect>().SetDirection(direction);
    }

    void spawnFireTiger(Vector3 direction, Quaternion rotation)
    {
        GameObject go = Instantiate(fire_tiger, transform.position + direction, rotation) as GameObject;
		go.transform.parent = transform;
    }

    void OnDestroy()
    {
        //string scene = SceneManager.GetActiveScene().name;
        //SceneManager.UnloadScene(scene);
        //SceneManager.LoadScene(scene);
    }
}
