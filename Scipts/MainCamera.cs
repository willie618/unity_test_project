using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	float angle = 0f;
	float eye_height = 30f;
	float eye_distance = 80f;
	float max_lookdown = -25f;
	float max_lookup = 20f;

	// Use this for initialization
	void Start () {
		//Camera Spawn
		transform.position = new Vector3 (0f, eye_height, -eye_distance);	
	}
	
	// Update is called once per frame
	void Update () {
		//Player
		GameObject player = GameObject.Find ("Player");
		Vector3 ref_height = new Vector3 (0f, eye_height, 0f);

		//Camera Look
		angle = Mathf.Max (max_lookdown, Mathf.Min (angle + Input.GetAxis ("ViewV"), max_lookup));
		if(Input.GetAxis ("ViewV") > 0f && angle > 0f && angle < max_lookup)
			transform.Translate (0f, 0f, Input.GetAxis ("ViewV")/2f);
		else if (Input.GetAxis ("ViewV") < 0f && angle > 0f)
			transform.Translate (0f, 0f, Input.GetAxis ("ViewV")/2f);

		transform.RotateAround (player.transform.position, Vector3.up, Input.GetAxis ("ViewH"));
//		transform.Rotate(Vector3.left * Input.GetAxis ("ViewV"));
		if(angle != max_lookdown && angle != max_lookup) 
			transform.RotateAround (player.transform.position + ref_height, -transform.right, Input.GetAxis ("ViewV"));
	}
}
