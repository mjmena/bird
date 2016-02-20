using UnityEngine;
using System.Collections;

public class EleformWheel : MonoBehaviour {
	public GameObject player;

	void Update () {
		GetComponent<Animator> ().SetInteger ("element_number", player.GetComponent<CombatController> ().GetNextElement ());
	}
}
