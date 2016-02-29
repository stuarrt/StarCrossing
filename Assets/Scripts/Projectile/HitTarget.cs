using UnityEngine;
using System.Collections;

public class HitTarget : MonoBehaviour {

	void OnCollisionEnter() {
		DestroyObject (this.gameObject);
	}
}
