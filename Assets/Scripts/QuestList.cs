using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class QuestList : MonoBehaviour {

	public GUIStyle qlist;

	private bool notebook;

	private int page;

	//Holds the quests that the player can complete/has completed
	public static List<Quest> quests = new List<Quest>();

	void Start() {
		//Quests are added here
		//***NOTE: Comment to put the quest number at the end
		page = 0;
		quests.Add(new Quest("Obtain Mayor Rock", false, false)); //0
	}

	// Update is called once per frame
	void Update () {
		//These are the quest conditions
		//If a quest is completed, this updates to let the game know
		//That the player has completed the quest
		if (Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Fossil]) {
			quests[0].completed = true;
		}
		if (notebook) {
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				page = 0;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2)) {
				page = 1;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3)) {
				page = 2;
			}
			if (Input.GetKeyDown(KeyCode.Alpha4)) {
				page = 3;
			}
			if (Input.GetKeyDown(KeyCode.Alpha5)) {
				page = 4;
			}
			if (Input.GetKeyDown(KeyCode.Alpha6)) {
				page = 5;
			}
			if (Input.GetKeyDown(KeyCode.Alpha7)) {
				page = 6;
			}
			if (Input.GetKeyDown(KeyCode.Alpha8)) {
				page = 7;
			}
			if (Input.GetKeyDown(KeyCode.Alpha9)) {
				page = 8;
			}
			if (Input.GetKeyDown(KeyCode.Alpha0)) {
				page = 9;
			}
			if (Input.GetKeyDown(KeyCode.Minus)) {
				page = 10;
			}
		}
	}

	void OnGUI() {
		//Interface for Quest list
		//Opens the quest list
		GUI.Box (new Rect (10, (Screen.height / 4) - 100, 200, 100), "");
		GUI.Box (new Rect (10, (Screen.height / 4) - 100, 200, 100), "");
		GUI.Box (new Rect (10, (Screen.height / 4) - 100, 200, 100), "");
		if (!notebook) {
			if (GUI.Button (new Rect (10, (Screen.height / 4) - 100, 200, 100), "Notebook") || Input.GetKeyDown(KeyCode.Q)) {
				notebook = true;
			}
		}
		//Display of the quest list
		if (notebook) {
			GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			if (page <= 9) {
				if (GUI.Button (new Rect(190, (Screen.height / 4) - 20, 20, 20), ">")) {
					page += 1;
				}
			}
			if (page >= 1) {
				if (GUI.Button (new Rect(10, (Screen.height / 4) - 20, 20, 20), "<")) {
					page -= 1;
				}
			}
			if (page == 0) {
				if (quests[0].display) {
					GUI.Label (new Rect (15, (Screen.height / 4) - 95, 200, 100), quests [0].name + " - " + quests [0].completed, qlist);
				}
			}
			if (GUI.Button (new Rect (10, (Screen.height / 4), 200, 20), "Close") || Input.GetKeyDown(KeyCode.R)) {
				notebook = false;
			}
		}
	}

}
