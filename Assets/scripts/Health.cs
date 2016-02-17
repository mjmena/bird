using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{

    public GameObject target;
    public Image bar;
    public Text text;
    
    void Update()
    {
        float current_health = target.GetComponent<Damageable>().health;
        float max_health = target.GetComponent<Damageable>().max_health;
        text.text = "" + current_health + "/" + max_health;
        bar.rectTransform.localScale = new Vector3(current_health / max_health, bar.rectTransform.localScale.y, bar.rectTransform.localScale.z);
    }

}