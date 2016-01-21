using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static Transform MyTransform { get; private set; }
	public static Animator MyAnimator { get; private set; }

	public RuntimeAnimatorController ForwardWalkAnim, BackWalkAnim, IdleAnim;

	protected Rigidbody charRigidbody;

	public float speed;
	public bool jumping;
	public float jumpHeight;
	public float maxJumpHeight;

	private bool pause;

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

		left = right = forward = back = jumping = false;

	}

	// Update is called once per frame
	void Update () {

		left = right = forward = back = false;

		if (Time.timeScale != 0) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				pause = !pause;
			}
		}
		if (pause) {
			Time.timeScale = 0;
		}
		if (Time.timeScale > 0) {
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				left = true;
			}
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				right = true;
			}
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				forward = true;
			}
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				back = true;
			}
			//Jumping mechanic
			//Currently player can hold down and will fly (as if having a jet pack
			if (Input.GetKey (KeyCode.Space)) {
				//TODO: Change this to be a check for the JetPack Object once we add it
				if (false){
					maxJumpHeight = transform.position.y + jumpHeight;
					jumping = true;
				}
				else if (Mathf.Abs(charRigidbody.velocity.y) < 0.01){
					maxJumpHeight = transform.position.y + jumpHeight;
					jumping = true;
				}
			}
			else {
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
					Application.LoadLevel (Application.loadedLevelName);
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
				MyAnimator.runtimeAnimatorController = BackWalkAnim;
			}
			else {
				MyAnimator.runtimeAnimatorController = ForwardWalkAnim;
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
			MyAnimator.runtimeAnimatorController = IdleAnim;
		}

		newTransform.Normalize();
		transform.position = transform.position + (newTransform * speed);
	}

	void Jump(){
		if (jumping){
			if (transform.position.y >= maxJumpHeight){
				//If the Current Inventory contains the Rocket Boots
				if (Inventory.Instance.CurrentInventory[Inventory.InventoryObjects.RocketBoots]){
					//TODO: Put the animation for rocket boots trigger here
					charRigidbody.velocity = new Vector3(charRigidbody.velocity.x, 0, charRigidbody.velocity.z);
				}
				else {
					jumping = false;
				}
			}
			else {
				//Set the y velocity to 0 to stop gravity from messing with the jumping 
				charRigidbody.velocity = new Vector3(charRigidbody.velocity.x, 0, charRigidbody.velocity.z);
				transform.position = new Vector3 (transform.position.x, transform.position.y + 0.08f, transform.position.z);
			}
		}
	}

}
