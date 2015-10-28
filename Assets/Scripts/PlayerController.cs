using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static Transform MyTransform { get; private set; }

	public float speed; 

	void Awake(){
		MyTransform = transform;

		if (speed == 0){
			speed = 0.02f;
		}

	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale > 0) {
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
			}
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
			}
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
			}
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
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
		}

	}

}
