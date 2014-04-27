using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	bool main_menu = false;
	bool[] sub_menus = {false, false, false, false};

	bool[] buttons;
	bool[] button_press = {false, false, false, false};
	int button_select = 0;
	const int button_num = 4;
	string[] button_names = {"Inventory", "Equipment", "Skills", "Options"};

	bool pressed = false;

	// Use this for initialization
	void Start () {
		buttons = new bool[button_num];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			main_menu = !main_menu;
			button_select = 0;
		}

		if (main_menu && Input.GetAxis ("MenuV") < 0f && !pressed) {
			button_select += 1;
			if (button_select > button_num-1)
				button_select = 0;
			pressed = true;
		}
		else if (main_menu && Input.GetAxis ("MenuV") > 0f && !pressed) {
			button_select -= 1;
			if (button_select < 0)
				button_select = button_num-1;
			pressed = true;
		}
		else if (main_menu && Input.GetAxis ("MenuV") == 0f) {
			pressed = false;
		}
	}

	void OnGUI () {

		if (main_menu) {
			GUI.Box (new Rect (10, 10, 100, 200), "Main Menu");

			// Generate buttons, store into buttons array
			for (int i = 0; i < button_num; i++) {
				GUI.SetNextControlName(button_names[i]);
				buttons[i] = GUI.Button(new Rect(20, 50 + (30 * i), 80, 20), button_names[i]);
			}

			GUI.FocusControl(button_names[button_select]);

			if (Input.GetButtonDown ("MenuSelect")) {
				button_press[button_select] = !button_press[button_select];
			}

			for (int i = 0; i < button_num; ++i) {
				if(buttons[i] || button_press[i])
					sub_menus[i] = !sub_menus[i];
			}

			if(sub_menus[0])
				GUI.Box (new Rect (10, 220, 100, 200), button_names[0]);
			if(sub_menus[1])
				GUI.Box (new Rect (120, 220, 100, 200), button_names[1]);
			if(sub_menus[2])
				GUI.Box (new Rect (10, 430, 100, 200), button_names[2]);
			if(sub_menus[3])
				GUI.Box (new Rect (120, 430, 100, 200), button_names[3]);
		}
	}
}
