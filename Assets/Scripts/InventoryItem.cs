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

	// Use this for initialization
	void Awake () {
		AllItems.Add(this);

		MyTransform = transform;
		MyCollider = GetComponent<Collider>();

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
	
	}

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
}
