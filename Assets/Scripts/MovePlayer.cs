﻿using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("LastScene") == "Store") {
			gameObject.transform.position = new Vector3 (19.18f, 1.372f, -18.41f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "Observatory") {
			gameObject.transform.position = new Vector3 (34.28f, 2.85f, -30.9f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "Observatory2") {
			gameObject.transform.position = new Vector3 (20.2f, 2.85f, -13.24f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "Cave") {
			gameObject.transform.position = new Vector3 (-36.4f, 1.372f, -8.374f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}