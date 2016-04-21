using UnityEngine;
using System.Collections;

public class BugMarker : MonoBehaviour {

	Transform player;
	public GameObject bugItem;
	public bool cancatch;
	public bool catching;
	public float catchtime;

	// Use this for initialization
	void Start () {
		player = PlayerController.MyTransform;
		cancatch = false;
		bugItem.SetActive(false);
		catchtime = 0f;
	}

	// Update is called once per frame
	void Update () {
		if (catching) {
			catchtime += Time.deltaTime;
		}
		if (catchtime > 2) {
			catching = false;
			catchtime = 0;
			CatchBug ();
		}
	}

	void OnTriggerEnter(Collider npc) {
		if (npc.gameObject.tag == "Player" && !catching && Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Net]) {
			cancatch = true;
		}
	}

	//Used for determining if the player is out of range of talking to the NPC
	void OnTriggerExit(Collider npc) {
		if (npc.gameObject.tag == "Player") {
			cancatch = false;
		}
	}
	public virtual void OnGUI() {
		//If the player is talking, display the conversation
		if (cancatch) {
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Box (new Rect ((Screen.width / 2) - (Screen.width * (65f / 1366f)), (Screen.height / 2) - 50, 100, 30), "");
			GUI.Label (new Rect ((Screen.width / 2) - (Screen.width * (50f / 1366f)), (Screen.height / 2) - 50, 200, 50), "Bug [R]");
			if (Input.GetKeyDown(KeyCode.R)) {
				cancatch = false;
				catching = true;
				player.SendMessage ("UseItem", Inventory.InventoryObjects.Net, SendMessageOptions.RequireReceiver);

			}
		}
	}

	void CatchBug(){
		bugItem.SetActive(true);
		bugItem.transform.parent = null;
		Destroy (gameObject);
	}
}
