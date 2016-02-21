using UnityEngine;
using System.Collections;

public class CombatController : MonoBehaviour
{
    private Rigidbody2D body;
    private MovementController movement_controller;
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
    public GameObject water_bear;
    public GameObject water_turtle;
    public GameObject fire_hawk;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        movement_controller = GetComponent<MovementController>();
        health = GetComponent<Damageable>();
    }

    void Update()
    {
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
            body.velocity = transform.up * movement_controller.speed * 5;
            movement_controller.LockState(.2f);

        }
        else if (current_element == Element.Wind && current_style == Style.Tiger)
        {
            GameObject clone = Instantiate(wind_tiger, transform.position + transform.up, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            clone.name = "wind_tiger_attack";
            DamageInstantaneousEffect wind_tiger_attack = clone.GetComponent<DamageInstantaneousEffect>();
            wind_tiger_attack.SetDamage(1);
        }
        else if (current_element == Element.Wind && current_style == Style.Turtle)
        {
            GameObject clone = Instantiate(wind_turtle, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            clone.name = "wind_turtle_zone";
            clone.tag = gameObject.tag;
            PulseEffect wind_turtle_zone = clone.GetComponent<PulseEffect>();
            wind_turtle_zone.SetLifetime(.5f);
            wind_turtle_zone.radius = .5f;
            wind_turtle_zone.velocity = 40f;
            wind_turtle_zone.acceleration = -10f;
            wind_turtle_zone.origin = transform;
        }
        else if (current_element == Element.Wind && current_style == Style.Bear)
        {
            GameObject clone = Instantiate(wind_bear, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            clone.name = "wind_bear_zone";
            clone.tag = gameObject.tag;
            VortexPulseEffect wind_bear_zone = clone.GetComponent<VortexPulseEffect>();
            wind_bear_zone.SetLifetime(5f);
            wind_bear_zone.radius = 3f;
            wind_bear_zone.velocity = .5f;
            wind_bear_zone.acceleration = 0f;
            wind_bear_zone.SetVortexStrength(1.2f);
            wind_bear_zone.origin = wind_bear_zone.transform;
        }
        else if (current_element == Element.Earth && current_style == Style.Hawk)
        {
            GameObject clone = Instantiate(earth_hawk, transform.position, transform.rotation) as GameObject;
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            clone.name = "earth_hawk";
            clone.tag = gameObject.tag;

            clone.GetComponent<Rigidbody2D>().velocity = transform.up * 2;

            body.velocity = -transform.up * movement_controller.speed * 3;
            movement_controller.LockState(.2f);
            GetComponent<Animator>().SetBool("is_dashing", true);
        }
        else if (current_element == Element.Earth && current_style == Style.Bear)
        {
            body.velocity = Vector3.zero;

            movement_controller.LockState(1f);
            health.LockState(1f);
            GetComponent<Animator>().SetBool("is_walking", false);
        }
        else if (current_element == Element.Water && current_style == Style.Bear)
        {
            Instantiate(water_bear, transform.position, transform.rotation);
        }
        else if (current_element == Element.Water && current_style == Style.Turtle)
        {
            GameObject go = Instantiate(water_turtle, transform.position, transform.rotation) as GameObject;
            go.name = "water_turtle_zone";
            go.tag = gameObject.tag;
            DamagePulseEffect water_turtle_zone = go.GetComponent<DamagePulseEffect>();
            water_turtle_zone.SetDamage(25f);
            water_turtle_zone.SetLifetime(4.5f);
            water_turtle_zone.radius = 2f;
            water_turtle_zone.velocity = 2f;
            water_turtle_zone.acceleration = -1f;
            water_turtle_zone.origin = transform;
        }
        else if (current_element == Element.Fire && current_style == Style.Hawk)
        {
            castFireHawk(transform.up, transform.rotation);
            castFireHawk(transform.up + transform.right, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 45));
            castFireHawk(transform.up - transform.right, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 45));
        }
    }

    void castFireHawk(Vector3 direction, Quaternion rotation)
    {
        float fire_hawk_projectile_speed = 5;
        Vector3 bullet_position = transform.position + direction;
        Vector3 bullet_velocity = direction * fire_hawk_projectile_speed;

        GameObject go = Instantiate(fire_hawk, bullet_position, rotation) as GameObject;
        go.name = "fire_hawk_projectile";
        go.tag = gameObject.tag;

        go.GetComponent<Rigidbody2D>().velocity = bullet_velocity;
        DamageProjectileEffect fire_hawk_projectile = go.GetComponent<DamageProjectileEffect>();
        fire_hawk_projectile.damage = 10;
        fire_hawk_projectile.SetLifetime(1);
    }
}
