using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.08f);
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.position = new Vector3(transform.position.x - 0.08f, transform.position.y, transform.position.z);
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.08f);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			transform.position = new Vector3(transform.position.x + 0.08f, transform.position.y, transform.position.z);
		}
		if (Input.GetKey (KeyCode.Space)) {
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.08f, transform.position.z);
		}
	}
}
