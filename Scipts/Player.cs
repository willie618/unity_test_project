using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	bool control = true;

	float height = 0f;
	float walk_speed = 1.0f;
	float jump_speed = 2f;
	float fall_speed = 0f;
	float jump_length = 60f;

	void Fall () {
		height = transform.position.y;
		if (height > 0f)
			fall_speed += 0.01f;
		else
			fall_speed = 0f;
		float drop = Mathf.Min (fall_speed, height);
		if (height > 0f)
			transform.Translate(Vector3.down * drop);
		else
			jump_length = 60f;
	}

	void Jump () {
		transform.Translate(Vector3.up * Input.GetAxis("Jump") * jump_speed);
		fall_speed = 0f;
		jump_length -= 1f;
	}

	// Use this for initialization
	void Start () {
		//Player Spawn
		transform.position = new Vector3 (0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			control = !control;
		}

		if (control) {
			//Camera
			GameObject camera = GameObject.Find ("Main Camera");
			Vector3 c_forward = camera.transform.forward;
			Vector3 c_right = camera.transform.right;
			c_forward.y = 0;
			c_right.y = 0;

			//Player Move
			transform.Translate(Vector3.Normalize (c_forward) * Input.GetAxis ("MoveV") * walk_speed);
			transform.Translate(Vector3.Normalize (c_right) * Input.GetAxis ("MoveH") * walk_speed);

			//Player Jump
			if (Input.GetAxis("Jump") != 0f && jump_length > 0f)
				Jump ();
			else
				Fall ();
		}
		else {
			Fall ();
		}
	}
}
