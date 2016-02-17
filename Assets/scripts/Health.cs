using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{

    public GameObject target;
    public Image bar;
     
    void Start()
    {
        
    }

    void Update()
    {
        float current_health = target.GetComponent<Combatant>().health;
        Debug.Log("Current Health " + current_health/100);
        bar.rectTransform.localScale = new Vector3(current_health / 100, bar.rectTransform.localScale.y, bar.rectTransform.localScale.z);
    }

}