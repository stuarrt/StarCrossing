﻿using UnityEngine;
using System.Collections;

public class HT6 : MonoBehaviour {

	//private float life = 3f;
	private int life;
	
	void Start() {
		life = PlayerPrefs.GetInt ("Fire6");
	}

	void Update() {
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire6", 0);
			DestroyObject (this.gameObject);
		}
	}
	
	void OnCollisionEnter() {
		life -= 1;
		PlayerPrefs.SetInt ("Fire6", life);
		/*
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire6", 0);
			DestroyObject (this.gameObject);
		}
		*/
	}
}