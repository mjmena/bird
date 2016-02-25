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
    public GameObject wind_tiger;
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
    public GameObject fire_tiger;
    public GameObject fire_turtle;
    public FireTurtleEffect fire_turtle_effect;

    void Start()
    {
        movable = GetComponent<Movable>();
        health = GetComponent<Damageable>();
    }

    void Update()
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
        Debug.Log("Using " + current_element + " + " + current_style);
        if (current_element == Element.Wind && current_style == Style.Hawk)
        {
            GetComponent<Animator>().SetBool("is_dashing", true);
            movable.AddForce(transform.up * movable.speed * 5, ForceMode2D.Impulse, .2f);
        }
        else if (current_element == Element.Wind && current_style == Style.Tiger)
        {
            GameObject clone = Instantiate(wind_tiger, transform.position + transform.up, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            clone.name = "wind_tiger_attack";
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
            movable.AddForce(-transform.up * movable.speed * 2.5f, ForceMode2D.Impulse, .2f);
            GetComponent<Animator>().SetBool("is_dashing", true);
        }
        else if (current_element == Element.Earth && current_style == Style.Bear)
        {
            movable.AddForce(Vector3.zero, ForceMode2D.Force, 1f);
            GetComponent<Animator>().SetBool("is_walking", false);
        }
        else if (current_element == Element.Earth && current_style == Style.Tiger)
        {
            movable.AddTorque(-3.151f, ForceMode2D.Impulse, .125f);
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
            clone.GetComponent<WaterTigerEffect>().SetFollowing(transform);
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
        string scene = SceneManager.GetActiveScene().name;
        //SceneManager.UnloadScene(scene);
        SceneManager.LoadScene(scene);
    }
}
