using UnityEngine;

public class FireBearEffect : MonoBehaviour
{
    public GameObject damage_zone;

    public void ExplodeTowards(Vector2 direction, Vector2 center)
    {
        GameObject clone = Instantiate(damage_zone) as GameObject;
        clone.transform.position = transform.position;
        clone.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        clone.GetComponent<FireBearLineEffect>().endPoint = center;
        Destroy(gameObject);
    }
}
