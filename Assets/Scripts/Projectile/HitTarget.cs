using UnityEngine;
using System.Collections;

public class HitTarget : MonoBehaviour {

	private float life = 3f;

	void OnCollisionEnter() {
		life -= 1;
		if (life <= 0) {
			DestroyObject (this.gameObject);
		}
	}
}
