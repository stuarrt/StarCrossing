using UnityEngine;
using System.Collections;

public class Grapple2 : MonoBehaviour {

	SpringJoint joint;
	Vector3 targetPos;
	RaycastHit2D hit;
	public float distance = 10f;

	// Use this for initialization
	void Start () {
		joint = GetComponent<SpringJoint> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = -10;
			hit = Physics2D.Raycast(transform.position, targetPos-transform.position, distance);

			if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody>() != null) {

			}
		}
	}
}
