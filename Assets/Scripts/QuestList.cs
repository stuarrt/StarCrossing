using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class QuestList : MonoBehaviour {

	public GUIStyle qlist;

	public GUIStyle qboxStyle;

	public GUIStyle qboxBStyle;

	public GUIStyle noteStyle;

	public GUIStyle buttonStyle;

	private bool notebook;

	private int page;

	//Holds the quests that the player can complete/has completed
	public static List<Quest> quests = new List<Quest>();

	void Start() {
		//Quests are added here
		//***NOTE: Comment to put the quest number at the end
		page = 0;
		quests.Add(new Quest("Talk to Ruby", false, false)); //0
		quests.Add(new Quest("Check on the Town", false, false)); //1
	}

	// Update is called once per frame
	void Update () {
		//These are the quest conditions
		//If a quest is completed, this updates to let the game know
		//That the player has completed the quest
		if (Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Fossil]) {
			//quests[0].completed = true;
		}
		if (Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Shovel]) {
			//quests[1].completed = true;
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			notebook = !notebook;
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
		//Temp inventory
	//	GUI.Box (new Rect (Screen.width - 150, (Screen.height / 4) - 100, 100, 50), "");
	//	GUI.Box (new Rect (Screen.width - 150, (Screen.height / 4)- 100, 100, 50), "");
	//	GUI.Box (new Rect (Screen.width - 150, (Screen.height / 4) - 100, 100, 50), "");
	//	GUI.Label (new Rect (Screen.width - 135, (Screen.height / 4) - 85, 100, 50), "Inventory [I]");
		//Interface for Quest list
		//Opens the quest list
		//GUI.Box (new Rect (10, (Screen.height / 4) - 100, 400, 200), notebookBack, qlist);
	//	GUI.Box (new Rect (10, (Screen.height / 4) - 100, 200, 100), "");
	//	GUI.Box (new Rect (10, (Screen.height / 4) - 100, 200, 100), "");
		if (!notebook) {
		//	GUI.Box (new Rect (10, (Screen.height / 4) - 100, 100, 50), "", noteStyle);
			if (GUI.Button (new Rect (10, (Screen.height / 4) - 100, 100, 50), "", noteStyle)) {
				notebook = !notebook;
			}
		}
		//Display of the quest list
		if (notebook) {
			GUI.Box (new Rect (10, (Screen.height / 4) - 100, 300, 150), "", noteStyle);
			//GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			//GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			//GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			if (page <= 9) {
				if (GUI.Button (new Rect(275, (Screen.height / 4) + 20, 20, 20), ">", buttonStyle)) {
					page += 1;
				}
			}
			if (page >= 1) {
				if (GUI.Button (new Rect(25, (Screen.height / 4) + 20, 20, 20), "<", buttonStyle)) {
					page -= 1;
				}
			}
			if (page == 0) {
				if (quests[0].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxStyle);
					GUI.Label (new Rect (15, (Screen.height / 4) - 70, 270, 100), quests [0].name + " - " + quests [0].completed, qlist);
				}
				if (!quests[0].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxBStyle);
				}
				if (quests[1].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxStyle);
					GUI.Label (new Rect (15, (Screen.height / 4) - 40, 270, 100), quests [1].name + " - " + quests [1].completed, qlist);
				}
				if (!quests[1].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxBStyle);
				}
				//***Insert Quest 2 here
				GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
			}
			//***Insert other quest pages here
			if (page > 0) {
				GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxBStyle);
				GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxBStyle);
				GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
			}
			//if (GUI.Button (new Rect (10, (Screen.height / 4), 200, 20), "Close")) {
			//	notebook = !notebook;
			//}
		}
	}

}
