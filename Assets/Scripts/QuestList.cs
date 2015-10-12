using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class QuestList : MonoBehaviour {
	
	public static List<Quest> quests = new List<Quest>();

	void Start() {
		quests.Add(new Quest("Obtained Fossil", false));
	}

	// Update is called once per frame
	void Update () {
		if (Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Fossil]) {
			quests[0].completed = true;
		}
	}

}
