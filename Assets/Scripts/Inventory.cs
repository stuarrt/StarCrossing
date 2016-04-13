using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	
	public static Inventory Instance { get; private set; }

	//All possible inventory object types 
	//ALL INVENTORY TYPES SHOULD BE ADDED TO DICTIONARY BELOW
	public enum InventoryObjects
	{
		GrappleGun,
		Hammer, 
		Shovel,
		RocketBoots, //No icon exists in UI for space reasons

		Coconut01,
		Coconut02,
		Pot01,
		Pot02,
		Pot03,
		Pot04,
		Pot05,
		Pot06,
		Pot07,
		Pot08,
		Pot09,
		Pot10,
		//Pots 11-16 left out for UI space reasons
		//Pot11,
		//Pot12,
		//Pot13,
		//Pot14,
		//Pot15,
		//Pot16,
		Tablet01,
		Tablet02,
		Tablet03,
		Tablet04,
		Tablet05,
		Tablet06,
		Tablet07,
		Tablet08,
		Tablet09,
		Tablet10,
		//Tablets 11-16 left out for UI space reasons
		//Tablet11,
		//Tablet12,
		//Tablet13,
		//Tablet14,
		//Tablet15,
		//Tablet16,
		Scrap01, 
		Scrap02, 
		Scrap03, 
		Scrap04, 
		ScrapSmall01,
		ScrapSmall02, 
		ScrapSmall03, 
		ScrapSmall04,
	}


	//Dictionary of all inventory objects in inventory or not
	//SHOULD CONTAIN A KEY FOR EACH INVENTORY OBJECT ENUMERATION
	public Dictionary<InventoryObjects, bool> CurrentInventory = new Dictionary<InventoryObjects, bool>()
	{
		{ InventoryObjects.GrappleGun, false },
		{ InventoryObjects.Hammer, false },
		{ InventoryObjects.Shovel, true },
		{ InventoryObjects.RocketBoots, false },
		{ InventoryObjects.Coconut01, false },
		{ InventoryObjects.Coconut02, false },
		{ InventoryObjects.Pot01, false },
		{ InventoryObjects.Pot02, false },
		{ InventoryObjects.Pot03, false },
		{ InventoryObjects.Pot04, false },
		{ InventoryObjects.Pot05, false },
		{ InventoryObjects.Pot06, false },
		{ InventoryObjects.Pot07, false },
		{ InventoryObjects.Pot08, false },
		{ InventoryObjects.Pot09, false },
		{ InventoryObjects.Pot10, false },
		//{ InventoryObjects.Pot11, false },
		//{ InventoryObjects.Pot12, false },
		//{ InventoryObjects.Pot13, false },
		//{ InventoryObjects.Pot14, false },
		//{ InventoryObjects.Pot15, false },
		//{ InventoryObjects.Pot16, false },
		{ InventoryObjects.Tablet01, false },
		{ InventoryObjects.Tablet02, false },
		{ InventoryObjects.Tablet03, false },
		{ InventoryObjects.Tablet04, false },
		{ InventoryObjects.Tablet05, false },
		{ InventoryObjects.Tablet06, false },
		{ InventoryObjects.Tablet07, false },
		{ InventoryObjects.Tablet08, false },
		{ InventoryObjects.Tablet09, false },
		{ InventoryObjects.Tablet10, false },
		//{ InventoryObjects.Tablet11, false },
		//{ InventoryObjects.Tablet12, false },
		//{ InventoryObjects.Tablet13, false },
		//{ InventoryObjects.Tablet14, false },
		//{ InventoryObjects.Tablet15, false },
		//{ InventoryObjects.Tablet16, false },
		{ InventoryObjects.Scrap01, false },
		{ InventoryObjects.Scrap02, false },
		{ InventoryObjects.Scrap03, false },
		{ InventoryObjects.Scrap04, false },
		{ InventoryObjects.ScrapSmall01, false },
		{ InventoryObjects.ScrapSmall02, false },
		{ InventoryObjects.ScrapSmall03, false },
		{ InventoryObjects.ScrapSmall04, false },
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

	//Debug method to print Inventory contents 
	public void PrintInventory(){
		foreach (KeyValuePair<InventoryObjects, bool> x in CurrentInventory)
			Debug.Log(x.Key.ToString() + ":" + x.Value.ToString());
	}
}
