using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

	//This is used for the style of the dialogue
	public GUIStyle diaStyle;

	public Texture npcPic;
	
	public Texture dialUI;

	public Texture shopWindow;

	public GUIStyle shopItems;

	public Texture emptyItem;
	
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

	protected int money;

	protected int page;

	// Use this for initialization
	void Start () {
		myname = "Shop Owner";
		money = PlayerPrefs.GetInt ("Money");
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
				if (GUI.Button(new Rect(x, y, 300, 50), "Shop - [1]") || Input.GetKeyDown(KeyCode.Alpha1)) {
					//selection[0] = r[i];
					page += 1;
					choose = false;
					//goodbye = true;
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

	void shop() {
		GUI.DrawTexture(new Rect(Screen.width * (400f / 1366f), Screen.height / 6 - (Screen.height * (90f / 728f)), Screen.width - (Screen.width * (450f / 1366f)), Screen.height / 3 + (Screen.height * (50f / 728f))), shopWindow);
		//Top Row
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (940f / 1366f)), Screen.height / 6 - (Screen.height * (70f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {

		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (830f / 1366f)), Screen.height / 6 - (Screen.height * (70f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (720f / 1366f)), Screen.height / 6 - (Screen.height * (70f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (610f / 1366f)), Screen.height / 6 - (Screen.height * (70f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (500f / 1366f)), Screen.height / 6 - (Screen.height * (70f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (390f / 1366f)), Screen.height / 6 - (Screen.height * (70f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (280f / 1366f)), Screen.height / 6 - (Screen.height * (70f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (170f / 1366f)), Screen.height / 6 - (Screen.height * (70f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		//Bottom Row
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (940f / 1366f)), Screen.height / 6 + (Screen.height * (55f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (830f / 1366f)), Screen.height / 6 + (Screen.height * (55f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (720f / 1366f)), Screen.height / 6 + (Screen.height * (55f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (610f / 1366f)), Screen.height / 6 + (Screen.height * (55f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (500f / 1366f)), Screen.height / 6 + (Screen.height * (55f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (390f / 1366f)), Screen.height / 6 + (Screen.height * (55f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (280f / 1366f)), Screen.height / 6 + (Screen.height * (55f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width * (170f / 1366f)), Screen.height / 6 + (Screen.height * (55f / 728f)), Screen.width * (100f / 1366f), Screen.height * (115f / 728f)), emptyItem, shopItems)) {
			
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
			GUI.DrawTexture(new Rect(Screen.width * (5f / 1366f), Screen.height / 2 - (Screen.height * (90f / 728f)), Screen.width - (Screen.width * (10f / 1366f)), Screen.height / 2 + (Screen.height * (50f / 728f))), dialUI);
			GUI.DrawTexture(new Rect(Screen.width * (30f / 1366f), Screen.height / 2 - (Screen.height * (50f / 728f)), Screen.width / 5 - (Screen.width * (20f / 1366f)), Screen.height / 2 - (Screen.height * (10f / 728f))), npcPic);
			GUI.Box(new Rect(Screen.width * (10f / 1366f), Screen.height / 2, Screen.width / 4, Screen.height / 2 - 10), "", diaStyle);
			GUI.Box(new Rect((Screen.width * (10f / 1366f)) + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 4)), Screen.height / 2 - 10), "", diaStyle);
			if (true) {
				GUI.Label (new Rect(Screen.width * (65f / 1366f), (Screen.height / 2) - (Screen.height * (75f / 728f)), Screen.width * (300f / 1366f), Screen.height * (40f / 728f)), "Shop Owner", nameStyle);
				//Goes to the next page of dialogue
				if (page < 2) {
					GUI.Label(new Rect((Screen.width * (15f / 1366f)) + (Screen.width / 5), (Screen.height / 2), Screen.width - (20 + (Screen.width / 4)), Screen.height / 2 - 60), "How can I help you?", diaStyle);
					choiceBox (0, 1, 2);
					if (!choose && !goodbye) {
						//Next button
						if (GUI.Button (new Rect (Screen.width - (Screen.width * (130f / 1366f)), Screen.height - 90, 55, 40), "[R]") || Input.GetKeyDown(KeyCode.R)) {
							page += 1;
						}
					}
				}
				if (page == 2) {
					shop ();
					GUI.Label(new Rect((Screen.width * (15f / 1366f)) + (Screen.width / 5), (Screen.height / 2), Screen.width - (20 + (Screen.width / 4)), Screen.height / 2 - 60), "What would you like?", diaStyle);
					choiceBox (0, 1, 2);
					if (!choose && !goodbye) {
						//Next button
						if (GUI.Button (new Rect (Screen.width / 2, Screen.height - 200, 200, 80), "Leave - [R]") || Input.GetKeyDown(KeyCode.R)) {
							page += 1;
						}
					}
				}
				//If on the last page, close dialogue when clicking goodbye
				if (page == 3 || goodbye) {
					GUI.Label(new Rect((Screen.width * (15f / 1366f)) + (Screen.width / 5), (Screen.height / 2), Screen.width - (20 + (Screen.width / 4)), Screen.height / 2 - 60), "Bye", diaStyle);
					//Goodbye button
					if (GUI.Button (new Rect (Screen.width - (Screen.width * (130f / 1366f)), Screen.height - 90, 55, 40), "[R]") || Input.GetKeyDown(KeyCode.R)) {
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
