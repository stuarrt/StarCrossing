using UnityEngine;
using System.Collections;

public class HT12 : MonoBehaviour {

	//private float life = 3f;
	private int life;
	
	void Start() {
		life = PlayerPrefs.GetInt ("Fire12");
	}

	void Update() {
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire12", 0);
			DestroyObject (this.gameObject);
		}
	}
	
	void OnCollisionEnter() {
		life -= 1;
		PlayerPrefs.SetInt ("Fire12", life);
		/*
		if (life <= 0) {
			PlayerPrefs.SetInt ("Fire12", 0);
			DestroyObject (this.gameObject);
		}
		*/
	}
}
