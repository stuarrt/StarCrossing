using UnityEngine;
using System.Collections;

public class HT9 : MonoBehaviour {

	//private float life = 3f;
	private int life;
	
	void Start() {
		life = PlayerPrefs.GetInt ("Fire9");
	}

	void Update() {
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire9", 0);
			DestroyObject (this.gameObject);
		}
	}
	
	void OnCollisionEnter() {
		life -= 1;
		PlayerPrefs.SetInt ("Fire9", life);
		/*
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire9", 0);
			DestroyObject (this.gameObject);
		}
		*/
	}
}
