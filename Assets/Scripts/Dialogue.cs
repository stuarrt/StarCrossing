using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public abstract class Dialogue : MonoBehaviour {

	//This is used for testing, can be commmented out
	//public GUIStyle testgui;

	//This is used for the style of the dialogue
	public GUIStyle diaStyle;

	//Determines if the Player can talk to the NPC
	protected bool cantalk;

	//Determines if the Player is currently talking to an NPC
	protected bool talking;

	//Determines the name of the NPC the player is talking to
	protected string npcname;

	//Text file associated with the NPC
	protected static string textfile;

	//Response file associated with the NPC (what the player can choose to say back)
	protected static string responsefile;

	//Used for parsing through textfile
	protected string[] lines;

	//Used for parsing through responsefile
	protected string[] responses = new string[1]{""};

	//Used for the list of responses a player can choose from (creates drop-down menu)
	protected string[] selection = new string[1]{"Select Response"};

	//Determines whether to show the drop-down menu for player responses
	protected bool[] showmenu = new bool[1];

	//Determines the page number for dialogue
	//Each page is represented by a line in the text file (.txt)
	protected int page;

	public virtual void Update() {
		//If the player is talking
		//pause all movement
		if (talking) {
			Time.timeScale = 0;
		}
		if (!talking) {
			Time.timeScale = 1;
		}
	}

	//Used for determining if the player is in range for talking to the NPC
	void OnTriggerEnter(Collider npc) {
		if (npc.gameObject.tag == "Player" && !talking) {
			cantalk = true;
		}
	}

	//Used for determining if the player is out of range of talking to the NPC
	void OnTriggerExit(Collider npc) {
		if (npc.gameObject.tag == "Player") {
			cantalk = false;
		}
	}

	//Creates a drop-down menu for the player responses if it is toggled on
	void dropMenu(float x, float y, int i, float sizeX) {
		//Determines whether to open the drop-down part of the menu
		if (page == 1) {
		if (GUI.Button (new Rect (x, y, sizeX, 30), selection [i])) {
			if (!showmenu [i]) {
				showmenu [i] = true;
			} else {
				showmenu [i] = false;
			}
		}
		if (showmenu [i]) {
				//Bottom Response
				if (GUI.Button (new Rect (x, y - 30, sizeX, 30), responses[i+2])) {
					selection [i] = responses[i+2];
					showmenu [i] = false;
				}
				//Middle Response
				if (GUI.Button(new Rect(x, y - 60, sizeX, 30), responses[i+1])) {
					selection[i] = responses[i+1];
					showmenu[i] = false;
				}
				//Top Response
				if (GUI.Button(new Rect(x, y - 90, sizeX, 30), responses[i])) {
					selection[i] = responses[i];
					showmenu[i] = false;
				}
			}
		}
	}

	public void conversation(string[] l) {
		if (talking) {
			GUI.Box(new Rect(10, Screen.height / 2, Screen.width - 20, Screen.height / 2 - 10), "");
			GUI.Box(new Rect(10, Screen.height / 2, Screen.width / 5, Screen.height / 2 - 10), "");
			GUI.Box(new Rect(10 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 10), "");
			if (gameObject.tag == npcname) {
				dropMenu(Screen.width - 320, Screen.height - 60, 0, 150);
				if (page < (l.Length - 1)) {
					GUI.Label(new Rect(15 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), l[page], diaStyle);
					if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Next")) {
						page += 1;
					}
				}
				if (page == (l.Length - 1)) {
					GUI.Label(new Rect(15 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), l[page], diaStyle);
					if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Goodbye")) {
						talking = false;
						cantalk = true;
						page = 0;
					}
				}
			}
		}
	}

	public virtual void OnGUI() {
		if (cantalk) {
			if (GUI.Button (new Rect (Screen.width - 70, Screen.height - 60, 50, 50), "Talk")) {
				talking = true;
				cantalk = false;
			}
		}
	}

}
