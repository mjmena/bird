using UnityEngine;
using System.Collections;

public class EleformWheel : MonoBehaviour {
	public GameObject player;

	void Update () {
		Debug.Log (player.GetComponent<CombatController> ().GetNextElement ());
		GetComponent<Animator> ().SetInteger ("element_number", player.GetComponent<CombatController> ().GetNextElement ());
	}
}
