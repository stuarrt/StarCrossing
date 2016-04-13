﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private float force = 50f;

	public float life;

	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		life = 3.5f;
	}

	void Update() {
		rb.AddForce(transform.forward * force);
		life -= 0.1f;
		if (life <= 0) {
			DestroyObject(this.gameObject);
		}
	}

}