using UnityEngine;
using System.Collections;

public class RespawnPlayer : MonoBehaviour {

	public GameObject respawn;

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "RespawnZone") {
			gameObject.transform.position = respawn.transform.position;
		}
	}
}
