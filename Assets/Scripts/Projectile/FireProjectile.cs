using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	private bool isFiring;

	private bool canFire;

	private float spawnDistance = 0.25f;

	private float reloadTime = 0.5f;

	private float reload; 

	public Transform projectile;
	
	// Update is called once per frame
	void Update () {
		reload += 0.1f;
		checkReload();
		if (Input.GetKeyDown (KeyCode.L)) {
			isFiring = true;
		}
		if (Input.GetKeyUp (KeyCode.L)) {
			isFiring = false;
		}
		if (isFiring && canFire) {
			canFire = false;
			fireProjectile();
		}
	}

	void fireProjectile() {
		GameObject.Instantiate(projectile, transform.position + spawnDistance * transform.forward, transform.rotation);
	}

	void checkReload() { 
		if (reload > reloadTime) {
			reload = 0;
			canFire = true;
		}
	}
}
