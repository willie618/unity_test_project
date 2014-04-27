using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour {

	bool control = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject camera = GameObject.Find ("Main Camera");
		Vector3 c_forward = camera.transform.forward;
		c_forward.y = 0;

		if (control) {
			if (Input.GetAxis ("MoveH") != 0 || Input.GetAxis ("MoveV") != 0)
				transform.rotation = Quaternion.LookRotation (c_forward);
		}
	}
}
