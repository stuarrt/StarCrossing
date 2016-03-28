using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print (PlayerPrefs.GetString ("LastScene"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "StoreDoor") {
			//PlayerPrefs.SetString ("LastScene", "Store");
			Application.LoadLevel ("insideStore");
		}
		if (c.gameObject.tag == "StoreMat") {
			PlayerPrefs.SetString ("LastScene", "Store");
			Application.LoadLevel ("testScene");
		}
		if (c.gameObject.tag == "ObserveDoor") {
			//PlayerPrefs.SetString ("LastScene", "Observatory");
			Application.LoadLevel ("observatoryFL1");
		}
		if (c.gameObject.tag == "ObserveUpto2") {
			//PlayerPrefs.SetString ("LastScene", "Observatory1");
			Application.LoadLevel ("observatoryFL2");
		}
		if (c.gameObject.tag == "ObserveDownto1") {
			PlayerPrefs.SetString ("LastScene", "Observatory2");
			Application.LoadLevel ("observatoryFL1");
		}
		if (c.gameObject.tag == "ObserveMat") {
			PlayerPrefs.SetString ("LastScene", "Observatory");
			Application.LoadLevel ("testScene");
		}
	}
}
