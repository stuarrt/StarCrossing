using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	
	public static Inventory Instance { get; private set; }

	//All possible inventory object types 
	//ALL INVENTORY TYPES SHOULD BE ADDED TO DICTIONARY BELOW
	public enum InventoryObjects
	{
		Fossil, 
		Shovel,
	}


	//Dictionary of all inventory objects in inventory or not
	//SHOULD CONTAIN A KEY FOR EACH INVENTORY OBJECT ENUMERATION
	public Dictionary<InventoryObjects, bool> CurrentInventory = new Dictionary<InventoryObjects, bool>()
	{
		{ InventoryObjects.Fossil, false },
		{ InventoryObjects.Shovel, false },
	};

	// Use this for initialization
	void Awake () {
		if (Instance != null)
		{
			Debug.LogError("More than one Inventory in scene!");
			return;
		}
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ToggleInventory(){
			InventoryIcon[] allIcons = GetComponentsInChildren<InventoryIcon>();
			if (allIcons.Length <= 0){ //Inventory is deactivated
				Time.timeScale = 0;
				Debug.Log ("Calling Parse Inventory Icons");
				ParseInventoryIcons(true);
			}
			else {//Inventory is active 
				Debug.Log ("Inventory Active. Deactivating");
				Time.timeScale = 1;
				ParseInventoryIcons(false);
			}

	}

	public void ParseInventoryIcons(bool state){
		InventoryIcon[] allIcons = GetComponentsInChildren<InventoryIcon>(true);

		//TODO Remove this. It's a sanity check. 
		if (allIcons.Length <= 0){
			Debug.Log ("Not Getting all Icons");
		}

		foreach (InventoryIcon icon in allIcons){
			if (!state){ //If we are deactivating the icons
				icon.gameObject.SetActive(state);
			}
			else {
				if (CurrentInventory[icon.inventoryType]){
					icon.gameObject.SetActive(state);
				}
			}
		}
	}

	//Debug method to print Inventory contents 
	public void PrintInventory(){
		foreach (KeyValuePair<InventoryObjects, bool> x in CurrentInventory)
			Debug.Log(x.Key.ToString() + ":" + x.Value.ToString());
	}
}
