using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class InventoryItem : MonoBehaviour {

	//The type or identity of the object
	public Inventory.InventoryObjects inventoryType;

	//Static list of all inventory objects
	public static List<InventoryItem> AllItems = new List<InventoryItem>();

	public Transform MyTransform { get; private set; }
	public Collider MyCollider { get; private set; }

	public int noticeDistance;

	//TODO Remove this and replace it with a real working system
	public bool canClick = false;

	public bool canPickUp;

	// Use this for initialization
	void Awake () {
		AllItems.Add(this);

		MyTransform = transform;
		MyCollider = GetComponent<Collider>();

		canPickUp = false;

		if (noticeDistance == 0){
			noticeDistance = 10;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//Check if player is close
		if (Vector3.Distance(PlayerController.MyTransform.position, MyTransform.position) < noticeDistance){
			//TODO Something
			canClick = true;
		}
		else {
			canClick = false;
		}

		if (canPickUp) {
			if (Input.GetKeyDown(KeyCode.E)) {
				Inventory.Instance.CurrentInventory.Remove(inventoryType);
				Inventory.Instance.CurrentInventory.Add (inventoryType, true);
				Inventory.Instance.PrintInventory();
				Destroy(gameObject);
			}
		}
	
	}

	void OnEnable(){
		if (Vector3.Distance (PlayerController.MyTransform.position, MyTransform.position) < noticeDistance) {
			canPickUp = true;
		} else {
			canPickUp = false;
		}
	}
	//Used for determining if the player is in range for talking to the NPC
	void OnTriggerEnter(Collider npc) {
		if (npc.gameObject.tag == "Player") {
			canPickUp = true;
		}
	}
	
	//Used for determining if the player is out of range of talking to the NPC
	void OnTriggerExit(Collider npc) {
		if (npc.gameObject.tag == "Player") {
			canPickUp = false;
		}
	}
	/*
	public void OnMouseDown(){
		if (canClick){
			Inventory.Instance.CurrentInventory.Remove(inventoryType);
			Inventory.Instance.CurrentInventory.Add (inventoryType, true);

			Inventory.Instance.PrintInventory();

			Destroy(gameObject);
		}
		else {
			return;
		}
	}
	*/

	void OnGUI() {
		if (canPickUp) {
			GUI.Box (new Rect ((Screen.width / 2) - 65, (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - 65, (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - 65, (Screen.height / 2) - 50, 100, 30), "");
			GUI.Label (new Rect ((Screen.width / 2) - 50, (Screen.height / 2) - 50, 200, 50), "Pick Up [E]");
		}
	}
}
