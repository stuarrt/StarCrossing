using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Doorway : MonoBehaviour {

	Transform player;
	public string destination;

	// Use this for initialization
	void Start () {
		player = PlayerController.MyTransform;

		if (destination == ""){
			Debug.LogError("Doorway in Scene has no Destination set!");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Application.LoadLevel(destination);
	}
}
