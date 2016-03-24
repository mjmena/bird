using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
    public GameObject fire_hawk_effect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CastHawk() {
        float spread = 20f;
        int shots = 10;
        float time = .2f;
        for (int i = 0; i < shots; i++) {
            float desired_rotation = (90 + transform.rotation.eulerAngles.z + (spread/2 - (spread / shots)*i));
            float x = Mathf.Cos(Mathf.Deg2Rad * desired_rotation);
            float y = Mathf.Sin(Mathf.Deg2Rad * desired_rotation);
            Vector3 unit_vector = new Vector3(x, y, 0);
            unit_vector.Normalize();
            StartCoroutine(spawnFireHawk(unit_vector, Quaternion.Euler(0, 0, -90 + desired_rotation), (time / shots) * i));
        }
    }


    private IEnumerator spawnFireHawk(Vector3 direction, Quaternion rotation, float delay) {
        yield return new WaitForSeconds(delay);
        Debug.Log(rotation.eulerAngles.z);

        GameObject go = Instantiate(fire_hawk_effect, transform.position + direction, rotation) as GameObject;
        go.tag = "ally";
        go.GetComponent<FireHawkEffect>().SetDirection(direction);
    }


}
