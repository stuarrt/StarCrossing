using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	
	public static Inventory Instance { get; private set; }

	//All possible inventory object types 
	public enum InventoryObjects
	{
		Fossil, 
		Shovel,
	}
	
//	public Texture2D FossilTex, ShovelTex

	//Dictionary of all inventory objects in inventory or not
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

	//Debug method to print Inventory contents 
	public void PrintInventory(){
		foreach (KeyValuePair<InventoryObjects, bool> x in CurrentInventory)
			Debug.Log(x.Key.ToString() + ":" + x.Value.ToString());
	}
}
