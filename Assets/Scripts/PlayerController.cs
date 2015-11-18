using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static Transform MyTransform { get; private set; }
	public static Animator MyAnimator { get; private set; }

	public RuntimeAnimatorController ForwardWalkAnim, BackWalkAnim, IdleAnim;

	public float speed; 

	void Awake(){
		MyTransform = transform;
		MyAnimator = this.GetComponent<Animator>();

		if (speed == 0){
			speed = 0.02f;
		}

	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale > 0) {
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				MyAnimator.runtimeAnimatorController = ForwardWalkAnim;
				transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);

				if (transform.localScale.x > 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
			}
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				MyAnimator.runtimeAnimatorController = ForwardWalkAnim;
				transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);

				if (transform.localScale.x < 0){
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
			}
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				MyAnimator.runtimeAnimatorController = BackWalkAnim;
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
			}
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				MyAnimator.runtimeAnimatorController = ForwardWalkAnim;
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - speed);
			}
			//Jumping mechanic
			//Currently player can hold down and will fly (as if having a jet pack
			if (Input.GetKey (KeyCode.Space)) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + 0.08f, transform.position.z);
			}
			if (Input.GetKeyDown (KeyCode.I)) {
				Debug.Log("Inventory Button Pressed");
				Inventory.Instance.ToggleInventory();
			}
			else if (!Input.anyKey){
				MyAnimator.runtimeAnimatorController = IdleAnim;
			}
		}

		if (this.transform.position.y < -15){
			this.transform.position = new Vector3(0f, 1.2f, 0f);
		}

	}

}
