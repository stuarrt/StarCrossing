using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class QuestList : MonoBehaviour {

	//Holds the quests that the player can complete/has completed
	public static List<Quest> quests = new List<Quest>();

	void Start() {
		//Quests are added here
		//***NOTE: Comment to put the quest number at the end
		quests.Add(new Quest("Obtained Fossil", false)); //0
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

}
