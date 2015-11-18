using UnityEngine;
using System.Collections;

public class InventoryIcon : MonoBehaviour {

	public Inventory.InventoryObjects inventoryType;

	// Use this for initialization
	void Awake () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
