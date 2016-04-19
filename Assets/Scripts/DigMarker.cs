using UnityEngine;
using System.Collections;

public class DigMarker : MonoBehaviour {

	PlayerController player;
	public GameObject diggableItem;
	public bool candig;
	public bool digging;
	public float digtime;

	// Use this for initialization
	void Start () {
		player = PlayerController.Instance;
		candig = false;
		diggableItem.SetActive(false);
		digtime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (digging) {
			digtime += Time.deltaTime;
		}
		if (digtime > 2) {
			digging = false;
			digtime = 0;
			DigObject ();
		}
	}

	void OnTriggerEnter(Collider npc) {
		if (npc.gameObject.tag == "Player" && !digging && Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Shovel]) {
			candig = true;
		}
	}

	//Used for determining if the player is out of range of talking to the NPC
	void OnTriggerExit(Collider npc) {
		if (npc.gameObject.tag == "Player") {
			candig = false;
		}
	}
	public virtual void OnGUI() {
		//If the player is talking, display the conversation
		if (candig) {
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Label (new Rect ((Screen.width / 2) - (Screen.width * (50f / 1366f)), (Screen.height / 2) - 50, 200, 50), "Dig [R]");
			if (Input.GetKeyDown(KeyCode.R)) {
				candig = false;
				digging = true;
				player.SendMessage ("UseItem", Inventory.InventoryObjects.Shovel, SendMessageOptions.RequireReceiver);
			}
		}
	}

	void DigObject(){
		diggableItem.SetActive(true);
		diggableItem.transform.parent = null;
		Destroy (gameObject);
	}
}
