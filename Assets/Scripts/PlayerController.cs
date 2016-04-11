using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static Transform MyTransform { get; private set; }
	public static Animator MyAnimator { get; private set; }

	public RuntimeAnimatorController PlayerAnimController, ShovelAnimController, GrappleAnimController, BootsAnimController, HammerAnimController;

	protected Rigidbody charRigidbody;

	public float speed;
	public bool jumping;
	public float jumpHeight;
	public float maxJumpHeight;
	public int rocketLimit;

	private int rocketTimer;
	private bool pause;

	private bool digging;
	
	private float digtime;

	private bool left, right, forward, back;

	void Awake(){
		MyTransform = transform;
		MyAnimator = this.GetComponent<Animator>();
		charRigidbody = GetComponent<Rigidbody>();

		if (speed == 0){
			speed = 0.02f;
		}

		if (jumpHeight == 0){
			jumpHeight = 1;
		}

		if (rocketLimit == 0) {
			rocketLimit = 3;
		}

		left = right = forward = back = jumping = false;

	}

	// Update is called once per frame
	void Update () {

		left = right = forward = back = false;

		//if (Time.timeScale != 0) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				pause = !pause;
		//	}
		}
		if (pause) {
			Time.timeScale = 0;
		}
		if (!pause) {
			Time.timeScale = 1;
		}
		/*
		if (Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Shovel]) {
			if (Input.GetKeyDown(KeyCode.R) && !digging) {
				digging = true;
			}
		}
		if (digging) {
			digtime += Time.deltaTime;
		}
		if (digtime > 2) {
			digging = false;
			digtime = 0;
		}
		*/
		if (Time.timeScale > 0) {
			if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) && !digging) {
				left = true;
			}
			if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) && !digging) {
				right = true;
			}
			if ((Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) && !digging) {
				forward = true;
			}
			if ((Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) && !digging) {
				back = true;
			}
			//Jumping mechanic
			//Currently player can hold down and will fly (as if having a jet pack
			if (Input.GetKeyDown (KeyCode.Space) && !digging) {
				if (!jumping && (charRigidbody.velocity.y > -3)) {
					maxJumpHeight = transform.position.y + jumpHeight;
					jumping = true;
				}
			} else if (Input.GetKeyUp (KeyCode.Space) && !digging) {
				charRigidbody.velocity = new Vector3(charRigidbody.velocity.x, -3, charRigidbody.velocity.z );
				jumping = false;
			}
			if (Input.GetKeyDown (KeyCode.I)) {
				Debug.Log("Inventory Button Pressed");
				Inventory.Instance.ToggleInventory();
			}
		}

		if (this.transform.position.y < -15){
			this.transform.position = new Vector3(0f, 1.2f, 0f);
		}

		MoveCharacter();
		Jump ();

	}

	void OnGUI() {
		if (Time.timeScale == 0) {
			if (pause) {
				GUI.Box (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 150, 200, 300), "");
				GUI.Box (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 150, 200, 300), "");
				GUI.Box (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 150, 200, 300), "");
				if (GUI.Button (new Rect ((Screen.width / 2) - 75, (Screen.height / 2) - 125, 150, 50), "Resume")) {
					Time.timeScale = 1;
					pause = false;
				}
				if (GUI.Button (new Rect ((Screen.width / 2) - 75, (Screen.height / 2) - 35, 150, 50), "Restart")) {
					//Application.LoadLevel (Application.loadedLevelName);
					PlayerPrefs.SetInt ("Quest0Displayed", 1);
					PlayerPrefs.SetInt ("Quest1Displayed", 0);
					PlayerPrefs.SetInt ("Quest2Displayed", 0);
					PlayerPrefs.SetInt ("Quest3Displayed", 0);
					PlayerPrefs.SetInt ("Quest4Displayed", 0);
					PlayerPrefs.SetInt ("Quest5Displayed", 0);
					PlayerPrefs.SetInt ("Quest6Displayed", 0);
					PlayerPrefs.SetInt ("Quest7Displayed", 0);
					PlayerPrefs.SetInt ("Quest8Displayed", 0);
					PlayerPrefs.SetInt ("Quest9Displayed", 0);
					PlayerPrefs.SetInt ("Quest10Displayed", 0);
					PlayerPrefs.SetInt ("Quest11Displayed", 0);
					PlayerPrefs.SetInt ("Quest12Displayed", 0);
					PlayerPrefs.SetInt ("Quest0Completed", 0);
					PlayerPrefs.SetInt ("Quest1Completed", 0);
					PlayerPrefs.SetInt ("Quest2Completed", 0);
					PlayerPrefs.SetInt ("Quest3Completed", 0);
					PlayerPrefs.SetInt ("Quest4Completed", 0);
					PlayerPrefs.SetInt ("Quest5Completed", 0);
					PlayerPrefs.SetInt ("Quest6Completed", 0);
					PlayerPrefs.SetInt ("Quest7Completed", 0);
					PlayerPrefs.SetInt ("Quest8Completed", 0);
					PlayerPrefs.SetInt ("Quest9Completed", 0);
					PlayerPrefs.SetInt ("Quest10Completed", 0);
					PlayerPrefs.SetInt ("Quest11Completed", 0);
					PlayerPrefs.SetInt ("Quest12Completed", 0);
					PlayerPrefs.SetInt ("HasShovel", 0);
					PlayerPrefs.SetString ("LastScene", "Main");
					Application.LoadLevel ("testScene - Backup");
				}
				if (GUI.Button (new Rect ((Screen.width / 2) - 75, (Screen.height / 2) + 55, 150, 50), "Quit")) {
					Application.Quit ();
				}
			}
		}
	}

	void MoveCharacter(){
		Vector3 newTransform = new Vector3(left ? 1 : 0, 0, back ? 1 : 0);

		if (right){
			newTransform = new Vector3(newTransform.x + -1, 0, newTransform.z);
		}
		if (forward){
			newTransform = new Vector3(newTransform.x, 0, newTransform.z + -1);
		}

		if (left || right || forward || back){

			//Determine forward or backwards animation
			if (!back && forward){
				//Sounds backwards but it makes sense
				//If you're moving forward (away from the camera) the character is facing backwards
				MyAnimator.Play("BackWalk");
			}
			else {
				MyAnimator.Play("ForwardWalk");
			}

			//Determine whether sprite should be flipped
			if (forward){
				if (left && !right && transform.localScale.x > 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
				else if (right && !left && transform.localScale.x < 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
			}
			else {
				if (left && !right && transform.localScale.x < 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
				else if (right && !left && transform.localScale.x > 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
			}
		}
		else {
			MyAnimator.Play("ForwardIdle");
		}

		newTransform.Normalize();
		transform.position = transform.position + (newTransform * speed);
	}

	void Jump(){
		if (jumping){
			if (transform.position.y >= maxJumpHeight){
				/*
				//If the Current Inventory contains the Rocket Boots
				if (Inventory.Instance.CurrentInventory[Inventory.InventoryObjects.RocketBoots]){
					//TODO: Put the animation for rocket boots trigger here
					rocketTimer++;
					if (rocketTimer >= rocketLimit) {
						jumping = false;
						rocketTimer = 0;
					}
					charRigidbody.velocity = new Vector3(charRigidbody.velocity.x, 0, charRigidbody.velocity.z);
				}
				else {
				*/
					jumping = false;
					charRigidbody.velocity = new Vector3(charRigidbody.velocity.x, -3, charRigidbody.velocity.z );
				//}
			}
			else {
				//Set the y velocity to 0 to stop gravity from messing with the jumping 
				charRigidbody.velocity = new Vector3(charRigidbody.velocity.x, 0, charRigidbody.velocity.z);
				transform.position = new Vector3 (transform.position.x, transform.position.y + 0.08f, transform.position.z);
			}
		}
	}

}
