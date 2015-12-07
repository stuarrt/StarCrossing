using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static Transform MyTransform { get; private set; }
	public static Animator MyAnimator { get; private set; }

	public RuntimeAnimatorController ForwardWalkAnim, BackWalkAnim, IdleAnim;

	public float speed;

	private bool pause;

	private bool left, right, forward, back;

	void Awake(){
		MyTransform = transform;
		MyAnimator = this.GetComponent<Animator>();

		if (speed == 0){
			speed = 0.02f;
		}

		left = right = forward = back = false;

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
//				MyAnimator.runtimeAnimatorController = ForwardWalkAnim;
//				transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
//
//				if (transform.localScale.x > 0){
//					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//				}
			}
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				right = true;
//				MyAnimator.runtimeAnimatorController = ForwardWalkAnim;
//				transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
//
//				if (transform.localScale.x < 0){
//					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//				}
			}
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				forward = true;
//				MyAnimator.runtimeAnimatorController = BackWalkAnim;
//				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
			}
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				back = true;
//				MyAnimator.runtimeAnimatorController = ForwardWalkAnim;
//				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - speed);
			}
			//Jumping mechanic
			//Currently player can hold down and will fly (as if having a jet pack
			//TODO: Make this flying thing dependent on having the jet pack
			if (Input.GetKey (KeyCode.Space)) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + 0.08f, transform.position.z);
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
		Vector3 newTransform = new Vector3(left ? -1 : 0, 0, back ? -1 : 0);

		if (right){
			newTransform = new Vector3(newTransform.x + 1, 0, newTransform.z);
		}
		if (forward){
			newTransform = new Vector3(newTransform.x, 0, newTransform.z + 1);
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
				if (left && !right && transform.localScale.x < 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
				else if (right && !left && transform.localScale.x > 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
			}
			else {
				if (left && !right && transform.localScale.x > 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
				else if (right && !left && transform.localScale.x < 0){
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

}
