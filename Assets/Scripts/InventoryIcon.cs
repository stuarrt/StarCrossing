using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryIcon : MonoBehaviour{

	public Inventory.InventoryObjects inventoryType;
	protected Image ImgSource;

	// Use this for initialization
	void Awake () {
		gameObject.SetActive(false);
		ImgSource = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
