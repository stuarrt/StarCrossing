using UnityEngine;
using System.Collections;

public class NewGrapple : MonoBehaviour {

	public Rigidbody grapplePrefab;
	SpringJoint joint;
	bool grappling;

	// Use this for initialization
	void Start () {
		joint = GetComponent<SpringJoint> ();
		grappling = false;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject grapplepoint = GameObject.FindGameObjectWithTag ("GrapplePoint");
		float a = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		float b = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
		float c = transform.position.z;
		if (Input.GetKeyDown (KeyCode.G)) {
			grappling = !grappling;
			Camera.main.orthographic = !Camera.main.orthographic;
			if (grapplepoint != null) {
				//grapplepoint.SetActive(grappling);
				joint.breakForce = 0;
			}
		}
		if (Input.GetMouseButtonDown (0) && grappling) {
			joint.breakForce = Mathf.Infinity;
			if (grapplepoint != null) {
				DestroyObject(grapplepoint);
			}
			Instantiate(grapplePrefab, new Vector3(a, b, c + 10), Quaternion.identity);
			//new Vector3(grapplepoint.transform.position.x, grapplepoint.transform.position.y, grapplepoint.transform.position.z)
			joint.connectedAnchor = new Vector3((5 * a) - 20, (5 * b) - 20, c + 10);
			//Debug.Log("World Space: " + transform.TransformPoint(new Vector3(a, b, c + 10)));
			//Debug.Log("Connected Anchor: " + joint.connectedAnchor);
		}
	}
}
