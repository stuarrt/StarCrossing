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

		gameObject.SetActive(false);
	}

	public void ToggleInventory(){
		InventoryIcon[] allIcons = GetComponentsInChildren<InventoryIcon>();
		if (gameObject.activeSelf){ //Inventory is active
			Debug.Log ("Inventory Active. Deactivating");
			Time.timeScale = 1;
			gameObject.SetActive(false);
			ParseInventoryIcons(false);
		}
		else {//Inventory is decactivated. Activate it
			Debug.Log ("Calling Parse Inventory Icons");
			gameObject.SetActive(true);
			ParseInventoryIcons(true);
		}

	}

	public void ParseInventoryIcons(bool state){
		InventoryIcon[] allIcons = GetComponentsInChildren<InventoryIcon>(true);

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

	public void NormalizeLocalScale(){
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	//Debug method to print Inventory contents 
	public void PrintInventory(){
		foreach (KeyValuePair<InventoryObjects, bool> x in CurrentInventory)
			Debug.Log(x.Key.ToString() + ":" + x.Value.ToString());
	}
}
