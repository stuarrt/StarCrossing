using UnityEngine;
using System.Collections;

public class TestPlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
		}
	}
}
