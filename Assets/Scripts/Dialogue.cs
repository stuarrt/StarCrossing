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
	
	void OnGUI() {
		//GUI.Label (new Rect (Screen.width / 2.75f, 20, 200, 50), "Testing Dialogue Collision: " + cantalk, testgui);
		//GUI.Label (new Rect (Screen.width / 2.75f, 70, 200, 50), "Testing Is Talking: " + talking, testgui);
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
				GUI.Label(new Rect(15 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), textfile, diaStyle);
				if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Next")) {
					talking = false;
				}
			}
		}
	}

}
