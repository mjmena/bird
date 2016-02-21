using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour
{

    public GameObject target;
    public GameObject container;
    public Image bar;
    public Text text;

    void Update()
    {
        if(target == null || target.GetComponent<Damageable>().health < 0 )
        {
            Destroy(container);
        }
        else
        {
            
            float current_health = target.GetComponent<Damageable>().health;
            float max_health = target.GetComponent<Damageable>().max_health;
            text.text = "" + (int)Mathf.Ceil(current_health) + "/" + max_health;
            bar.rectTransform.localScale = new Vector3(current_health / max_health, bar.rectTransform.localScale.y, bar.rectTransform.localScale.z);

            container.transform.position = target.transform.position + new Vector3(0, 1, 0);
        }
    }
}