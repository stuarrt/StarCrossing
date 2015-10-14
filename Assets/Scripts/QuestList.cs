using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class QuestList : MonoBehaviour {

	public GUIStyle qlist;

	private bool notebook;

	//Holds the quests that the player can complete/has completed
	public static List<Quest> quests = new List<Quest>();

	void Start() {
		//Quests are added here
		//***NOTE: Comment to put the quest number at the end
		quests.Add(new Quest("Obtain Fossil", false, false)); //0
	}

	// Update is called once per frame
	void Update () {
		//These are the quest conditions
		//If a quest is completed, this updates to let the game know
		//That the player has completed the quest
		if (Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Fossil]) {
			quests[0].completed = true;
		}
	}

	void OnGUI() {
		//Interface for Quest list
		//Opens the quest list
		if (!notebook) {
			if (GUI.Button (new Rect (10, Screen.height / 2, 100, 100), "Notebook")) {
				notebook = true;
			}
		}
		//Display of the quest list
		if (notebook) {
			GUI.Box (new Rect (10, Screen.height / 2, 100, 100), "");
			if (quests[0].display) {
				GUI.Label (new Rect (15, (Screen.height / 2) + 5, 100, 100), quests [0].name + " - " + quests [0].completed, qlist);
			}
			if (GUI.Button (new Rect (10, (Screen.height / 2) + 100, 100, 20), "Close")) {
				notebook = false;
			}
		}
	}

}
