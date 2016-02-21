using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour
{

    public GameObject target;
    public Image bar;
    public Text text;
    
    void Update() {
        float current_health = target.GetComponent<Damageable>().current_health;
        float max_health = target.GetComponent<Damageable>().max_health;
        text.text = "" + (int)Mathf.Ceil(current_health) + "/" + max_health;
        bar.rectTransform.localScale = new Vector3(current_health / max_health, bar.rectTransform.localScale.y, bar.rectTransform.localScale.z);
    }
}