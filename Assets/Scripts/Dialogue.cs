using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public abstract class Dialogue : MonoBehaviour {

	public GUIStyle testgui;

	public GUIStyle diaStyle;

	protected bool cantalk;
	
	protected bool talking;

	protected string npcname;

	protected static string textfile;

	protected static string responsefile;

	protected string[] lines;

	protected string[] responses = new string[1]{""};

	protected string[] selection = new string[1]{"Send a text"};

	protected bool[] showmenu = new bool[1];

	protected int page;
	
	void Update() {
		if (talking) {
			Time.timeScale = 0;
		}
		if (!talking) {
			Time.timeScale = 1;
		}
	}

	void OnTriggerEnter(Collider npc) {
		if (npc.gameObject.tag == "Player" && !talking) {
			cantalk = true;
		}
	}
	
	void OnTriggerExit(Collider npc) {
		if (npc.gameObject.tag == "Player") {
			cantalk = false;
		}
	}

	//Creates a drop-down menu for the soil type if it is toggled on
	void dropMenu(float x, float y, int i, float sizeX) {
		//Determines whether to open the drop-down part of the menu
		if (GUI.Button (new Rect (x, y, sizeX, 30), selection [i])) {
			if (!showmenu [i]) {
				showmenu [i] = true;
			} else {
				showmenu [i] = false;
			}
		}
		if (showmenu [i]) {
			if (page == 1) {
				if (GUI.Button (new Rect (x, y - 30, sizeX, 30), responses[i+2])) {
					selection [i] = responses[i+2];
					showmenu [i] = false;
				}
				if (GUI.Button(new Rect(x, y - 60, sizeX, 30), responses[i+1])) {
					selection[i] = responses[i+1];
					showmenu[i] = false;
				}
				if (GUI.Button(new Rect(x, y - 90, sizeX, 30), responses[i])) {
					selection[i] = responses[i];
					showmenu[i] = false;
				}
			}
		}
	}
	
	void OnGUI() {
		//GUI.Label (new Rect (Screen.width / 2.75f, 20, 200, 50), "Lines Length: " + (lines.Length - 1), testgui);
		//GUI.Label (new Rect (Screen.width / 2.75f, 70, 200, 50), "Page Length: " + page, testgui);
		if (cantalk) {
			if (GUI.Button (new Rect (Screen.width - 70, Screen.height - 60, 50, 50), "Talk")) {
				talking = true;
				cantalk = false;
			}
		}
		if (talking) {
			GUI.Box(new Rect(10, Screen.height / 2, Screen.width - 20, Screen.height / 2 - 10), "");
			GUI.Box(new Rect(10, Screen.height / 2, Screen.width / 5, Screen.height / 2 - 10), "");
			GUI.Box(new Rect(10 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 10), "");
			if (gameObject.tag == npcname) {
				dropMenu(Screen.width - 320, Screen.height - 60, 0, 100);
				if (page < (lines.Length - 1)) {
					GUI.Label(new Rect(15 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), lines[page], diaStyle);
					if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Next")) {
						page += 1;
					}
				}
				if (page == (lines.Length - 1)) {
					GUI.Label(new Rect(15 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), lines[page], diaStyle);
					if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Goodbye")) {
						talking = false;
						cantalk = true;
						page = 0;
					}
				}
			}
		}
	}

}
