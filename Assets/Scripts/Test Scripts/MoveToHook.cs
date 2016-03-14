using UnityEngine;
using System.Collections;

public class MoveToHook : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("GrapplePoint") != null) {
			DestroyObject(GameObject.FindGameObjectWithTag("GrapplePoint"));
		}
	}
}
