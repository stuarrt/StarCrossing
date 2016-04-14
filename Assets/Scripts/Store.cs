using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

	//This is used for the style of the dialogue
	public GUIStyle diaStyle;

	public Texture npcPic;
	
	public Texture dialUI;
	
	//Name of the npc
	public GUIStyle nameStyle;
	
	//Determines if the Player can talk to the NPC
	protected bool cantalk;
	
	//Determines if the Player is currently talking to an NPC
	protected bool talking;
	
	//Determines if the player is making a choice
	protected bool choose;
	
	//Determines if the player should say goodbye to the NPC
	protected bool goodbye;

	//Determines the name of the NPC the player is talking to
	protected string npcname;
	
	protected string myname;

	protected int page;

	// Use this for initialization
	void Start () {
		myname = "Shop Owner";
	}
	
	// Update is called once per frame
	void Update () {
	
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

	public void choiceBox (int i, int p, int c) {
		float x = Screen.width - 750;
		float y = Screen.height - 250;
		if (page == p) {
			choose = true;
			if (c > 0) {
				if (GUI.Button(new Rect(x, y, 300, 50), "Shop - [1]") || Input.GetKeyDown(KeyCode.Alpha0)) {
					//selection[0] = r[i];
					page += 1;
					choose = false;
					goodbye = true;
				}
			}
			if (c > 1) {
				if (GUI.Button(new Rect(x, y + 75, 300, 50), "Leave - [2]") || Input.GetKeyDown(KeyCode.Alpha2)) {
					//selection[0] = r[i+1];
					page += 2;
					choose = false;
					goodbye = true;
				}
			}
			if (c > 2) {
				if (GUI.Button(new Rect(x, y + 150, 300, 50), "Other")) {
					//selection[0] = r[i+2];
					page += 3;
					choose = false;
					goodbye = true;
				}
			}
		}
	}

	void OnGUI() {
		//If the player is talking, display the conversation
		if (cantalk) {
			GUI.Box (new Rect ((Screen.width / 2) - 65, (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - 65, (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - 65, (Screen.height / 2) - 50, 100, 30), "");
			GUI.Label (new Rect ((Screen.width / 2) - 50, (Screen.height / 2) - 50, 200, 50), "Talk [E]");
			if (Input.GetKeyDown(KeyCode.E)) {
				talking = true;
				cantalk = false;
				Debug.Log ("Activating Dialog Handler");
			}
		}
		//If the player is talking, display dialogue GUI
		if (talking) {
			Time.timeScale = 0;
			GUI.Box(new Rect(10, Screen.height / 2 - 90, Screen.width + 50, Screen.height / 2 + 50), dialUI, diaStyle);
			GUI.Box(new Rect(30, Screen.height / 2 - 50, Screen.width - 20, Screen.height / 2 - 10), npcPic, diaStyle);
			GUI.Box(new Rect(10, Screen.height / 2, Screen.width / 4, Screen.height / 2 - 10), "", diaStyle);
			GUI.Box(new Rect(10 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 4)), Screen.height / 2 - 10), "", diaStyle);
			if (true) {
				GUI.Label (new Rect(65, (Screen.height / 2) - 75, 300, 40), "Shop Owner", nameStyle);
				//Goes to the next page of dialogue
				if (page < 2) {
					GUI.Label(new Rect(15 + (Screen.width / 5), (Screen.height / 2), Screen.width - (20 + (Screen.width / 4)), Screen.height / 2 - 60), "How can I help you?", diaStyle);
					choiceBox (0, 1, 2);
					if (!choose && !goodbye) {
						//Next button
						if (GUI.Button (new Rect (Screen.width - 130, Screen.height - 90, 55, 40), "[R]") || Input.GetKeyDown(KeyCode.R)) {
							page += 1;
						}
					}
				}
				//If on the last page, close dialogue when clicking goodbye
				if (page == 2 || goodbye) {
					GUI.Label(new Rect(15 + (Screen.width / 5), (Screen.height / 2), Screen.width - (20 + (Screen.width / 4)), Screen.height / 2 - 60), "Bye", diaStyle);
					//Goodbye button
					if (GUI.Button (new Rect (Screen.width - 130, Screen.height - 90, 55, 40), "[R]") || Input.GetKeyDown(KeyCode.R)) {
						talking = false;
						Time.timeScale = 1;
						cantalk = true;
						page = 0;
						goodbye = false;
					}
				}
			}
		}
	}
}
