using UnityEngine;
using System.Collections;

public class FishingArea : MonoBehaviour {

	public Transform player;
	bool fishing;
	bool canfish;
	float fishtime;
	public GameObject fishItem;

	// Use this for initialization
	void Start () {
		player = PlayerController.MyTransform;
		canfish = false;
		fishtime = 0f;
		fishItem.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (fishing) {
			fishtime += Time.deltaTime;
		}
		if (fishtime > 2) {
			fishing = false;
			fishtime = 0;
			FishObject ();
		}
	}

	void OnTriggerEnter(Collider npc) {
		if (npc.gameObject.tag == "Player" && !fishing && Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.FishingRod]) {
			canfish = true;
		}
	}

	//Used for determining if the player is out of range of talking to the NPC
	void OnTriggerExit(Collider npc) {
		if (npc.gameObject.tag == "Player") {
			canfish = false;
		}
	}

	public virtual void OnGUI() {
		//If the player is talking, display the conversation
		if (canfish) {
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Label (new Rect ((Screen.width / 2) - (Screen.width * (50f / 1366f)), (Screen.height / 2) - 50, 200, 50), "Fish [R]");
			if (Input.GetKeyDown(KeyCode.R)) {
				canfish = false;
				fishing = true;
				player.SendMessage ("UseItem", Inventory.InventoryObjects.FishingRod, SendMessageOptions.RequireReceiver);
			}
		}
	}

	void FishObject(){
		fishItem.SetActive(true);
		fishItem.transform.parent = null;
		Destroy (gameObject);
	}
}
