using UnityEngine;
using System.Collections;

public class HT3 : MonoBehaviour {

	//private float life = 3f;
	private int life;
	
	void Start() {
		life = PlayerPrefs.GetInt ("Fire3");
	}

	void Update() {
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire3", 0);
			DestroyObject (this.gameObject);
		}
	}

	void OnCollisionEnter() {
		life -= 1;
		PlayerPrefs.SetInt ("Fire3", life);
		/*
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire3", 0);
			DestroyObject (this.gameObject);
		}
		*/
	}
}
