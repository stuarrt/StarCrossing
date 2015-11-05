using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public abstract class Dialogue : MonoBehaviour {

	//This is used for testing, can be commmented out
	public GUIStyle testgui;

	//This is used for the style of the dialogue
	public GUIStyle diaStyle;

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
	//Defaulted to 0
	protected int page;

	protected int dialoguecount;

	//Max x,y text movement when dialog is shaking
	//z value denotes speed of text shaking
	public Vector3 shakeVal;

	//Max x,y text movement when dialog is violently shaking
	//z value denotes speed of text shaking
	public Vector3 angryVal;

	//Values that the text is shifted by
	public float textX;
	public float textY;

	public enum DialogType
	{
		Normal, 
		Shaking,
		Angry,
	}

	public virtual void Awake(){
		if (shakeVal == new Vector3(0, 0, 0)){
			shakeVal = new Vector3(2,1, 15);
		}
		if (angryVal == new Vector3(0, 0, 0)){
			angryVal = new Vector3(3, 2, 25);
		}
	}

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
	public void dropMenu(int i, float sizeX, int p) {
		float x = Screen.width - 320;
		float y = Screen.height - 60;
		//Determines whether to open the drop-down part of the menu
		//***NOTE: Should probably modify how each NPC selects responses
		if (page == p) {
			choose = true;
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

	//TODO: Edit this function to determine whether the line being displayed needs to be shaken a certain way and act accordingly
	public void moveText(string[] l){
		//For now, it just shakes the text if there is text
		if (l[page] != null){
			textX = Mathf.PingPong(Time.realtimeSinceStartup * shakeVal.z, shakeVal.x);
			textY = Mathf.PingPong(Time.realtimeSinceStartup * shakeVal.z, shakeVal.y);
		}
	}

	//Generic outline of the conversation (select which conversation to display)
	public void conversation(string[] l) {
		//Determine the values to shift text by if any
		moveText(l);

		//If the player is talking, display dialogue GUI
		if (talking) {
			GUI.Box(new Rect(10, Screen.height / 2, Screen.width - 20, Screen.height / 2 - 10), "");
			GUI.Box(new Rect(10, Screen.height / 2, Screen.width / 5, Screen.height / 2 - 10), "");
			GUI.Box(new Rect(10 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 10), "");
			if (gameObject.tag == npcname) {
					//Goes to the next page of dialogue
					if (page < (l.Length - 1)) {
						GUI.Label(new Rect(15 + (Screen.width / 5) + textX, (Screen.height / 2) + textY, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), l[page], diaStyle);
						if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Next")) {
							page += 1;
						}
					}
					//If on the last page, close dialogue when clicking goodbye
					if (page == (l.Length - 1)) {
					GUI.Label(new Rect(15 + (Screen.width / 5) + textX, (Screen.height / 2) + textY, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), l[page], diaStyle);
						if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Goodbye")) {
							talking = false;
							cantalk = true;
							page = 0;
							dialoguecount += 1;
						}
					}
			}
		}
	}

	public void makeChoice(string[] l, List<int> choices, string choice1, string choice2, string choice3) {
		//Determine the values to shift text by if any
		moveText(l);

		//If the player is talking, display dialogue GUI
		if (talking) {
			GUI.Box (new Rect (10, Screen.height / 2, Screen.width - 20, Screen.height / 2 - 10), "");
			GUI.Box (new Rect (10, Screen.height / 2, Screen.width / 5, Screen.height / 2 - 10), "");
			GUI.Box (new Rect (10 + (Screen.width / 5), Screen.height / 2, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 10), "");
			if (gameObject.tag == npcname) {
				if (!choices.Contains(page)) {
					//Goes to the next page of dialogue
					if (page < (l.Length - 1) && !goodbye) {
						GUI.Label(new Rect(15 + (Screen.width / 5) + textX, (Screen.height / 2) + textY, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), l[page], diaStyle);
						if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Next")) {
							page += 1;
						}
					}
					//If on the last page, close dialogue when clicking goodbye
					if (page == (l.Length - 1) || goodbye) {
						GUI.Label(new Rect(15 + (Screen.width / 5) + textX, (Screen.height / 2) + textY, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), l[page], diaStyle);
						if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Goodbye")) {
							talking = false;
							cantalk = true;
							page = 0;
							dialoguecount += 1;
							goodbye = false;
						}
					}
				}
				if (choices.Contains (page)) {
					//Goes to the next page of dialogue
					if (page < (l.Length - 1) && !goodbye) {
						GUI.Label (new Rect (15 + (Screen.width / 5) + textX, (Screen.height / 2) + textY, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), l [page], diaStyle);
						if (selection [0] != "Select Response") {
							if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Next")) {
								if (selection [0] == choice1) {
									page += 1;
									goodbye = true;
								}
								if (selection [0] == choice2) {
									page += 2;
									goodbye = true;
								}
								if (selection [0] == choice3) {
									page += 3;
									goodbye = true;
								}
							}
						}
					}
					//If on the last page, close dialogue when clicking goodbye
					if (page == (l.Length - 1) || goodbye) {
						GUI.Label (new Rect (15 + (Screen.width / 5) + textX, (Screen.height / 2) + textY, Screen.width - (20 + (Screen.width / 5)), Screen.height / 2 - 60), l [page], diaStyle);
						if (selection [0] != "Select Response") {
							if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "Goodbye")) {
								talking = false;
								cantalk = true;
								page = 0;
								dialoguecount += 1;
								goodbye = false;
							}
						}
					}
				}
			}
		}
	}

	public void addQuest(int i) {
		QuestList.quests [i].display = true;
	}

	public virtual void OnGUI() {
		//If the player is talking, display the conversation
		if (cantalk) {
			if (GUI.Button (new Rect (Screen.width - 70, Screen.height - 60, 50, 50), "Talk")) {
				talking = true;
				cantalk = false;
			}
		}
		//GUI.Label (new Rect (Screen.width / 2, 25, 200, 50), "Current Selection: " + selection[0] + " Goodbye: " + goodbye, testgui);
	}

}
