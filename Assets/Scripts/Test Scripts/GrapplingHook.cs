using UnityEngine;
using System.Collections;

public class GrapplingHook : MonoBehaviour {

	private Vector3 grapplehitpoint;

	private float distance;

	private float smooth;

	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
		smooth = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.G)) {
			GrappleToPoint();
		}
	}

	void FireGrapple() {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.forward, out hit, 100)) {
			grapplehitpoint = hit.point;
		}
	}

	void GrappleToPoint() {
		transform.position = Vector3.Lerp (transform.position, grapplehitpoint, Time.deltaTime * smooth);
	}
}
