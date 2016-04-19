using UnityEngine;
using System.Collections;

public class HT8 : MonoBehaviour {

	//private float life = 3f;
	private int life;
	
	void Start() {
		life = PlayerPrefs.GetInt ("Fire8");
	}

	void Update() {
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire8", 0);
			DestroyObject (this.gameObject);
		}
	}
	
	void OnCollisionEnter() {
		life -= 1;
		PlayerPrefs.SetInt ("Fire8", life);
		/*
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire8", 0);
			DestroyObject (this.gameObject);
		}
		*/
	}
}
