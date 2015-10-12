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

	// Use this for initialization
	void Awake () {
		AllItems.Add(this);

		MyTransform = transform;
		MyCollider = GetComponent<Collider>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown(){
		Inventory.Instance.CurrentInventory.Remove(inventoryType);
		Inventory.Instance.CurrentInventory.Add (inventoryType, true);

		Inventory.Instance.PrintInventory();

		Destroy(gameObject);
	}
}
