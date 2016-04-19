using System;
using System.Collections.Generic;
using UnityEngine;

public class JAR : MonoBehaviour {

	bool canbug;
	bool jarfull;
	public NPC wallace;
	List<Inventory.InventoryObjects> acceptableItems;

	// Use this for initialization
	void Start () {
		canbug = false;
		acceptableItems = new List<Inventory.InventoryObjects> ();
		acceptableItems.Add (Inventory.InventoryObjects.Bug01);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider npc) {
		if (npc.gameObject.tag == "Player" && !jarfull) {
			foreach (Inventory.InventoryObjects i in acceptableItems) {
				if (Inventory.Instance.CurrentInventory [i]) {
					canbug = true;
				}
			}
		}
	}

	//Used for determining if the player is out of range of talking to the NPC
	void OnTriggerExit(Collider npc) {
		if (npc.gameObject.tag == "Player") {
			canbug = false;
		}
	}

	public virtual void OnGUI() {
		//If the player is talking, display the conversation
		if (canbug) {
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Label (new Rect ((Screen.width / 2) - (Screen.width * (50f / 1366f)), (Screen.height / 2) - 50, 200, 50), "Give Bug [R]");
			if (Input.GetKeyDown(KeyCode.R)) {
				canbug = false;
				jarfull = true;
				wallace.charDisabled = false;
			}
		}
	}
}
