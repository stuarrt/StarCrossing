using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public abstract class Dialogue : MonoBehaviour {

	public bool cantalk;

	public bool talking;

	public GUIStyle testgui;

	public GUIStyle diaStyle;

	private static string npcname;
	
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
	
	}

}
