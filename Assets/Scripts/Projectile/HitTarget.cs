﻿using UnityEngine;
using System.Collections;

public class HitTarget : MonoBehaviour {

	//private float life = 3f;
	private int life;

	void Start() {
		life = PlayerPrefs.GetInt ("Fire0");
	}

	void Update() {
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire0", 0);
			DestroyObject (this.gameObject);
		}
	}

	void OnCollisionEnter() {
		life -= 1;
		PlayerPrefs.SetInt ("Fire0", life);
		/*
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire0", 0);
			DestroyObject (this.gameObject);
		}
		*/
	}
}
