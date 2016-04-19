using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("Last Scene: " + PlayerPrefs.GetString ("LastScene") + " Current Scene: " + PlayerPrefs.GetString ("CurrentScene"));
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "FishDoor") {
			PlayerPrefs.SetString ("LastScene", "Main");
			PlayerPrefs.SetString ("CurrentScene", "FishHut");
			Application.LoadLevel ("fishHut");
		}
		if (c.gameObject.tag == "FishMat") {
			PlayerPrefs.SetString ("LastScene", "FishHut");
			PlayerPrefs.SetString ("CurrentScene", "Main");
			Application.LoadLevel ("testScene - Backup");
		}
		if (c.gameObject.tag == "StoreDoor") {
			PlayerPrefs.SetString ("LastScene", "Main");
			PlayerPrefs.SetString ("CurrentScene", "Store");
			Application.LoadLevel ("insideStore");
		}
		if (c.gameObject.tag == "StoreMat") {
			PlayerPrefs.SetString ("LastScene", "Store");
			PlayerPrefs.SetString ("CurrentScene", "Main");
			Application.LoadLevel ("testScene - Backup");
		}
		if (c.gameObject.tag == "JungleDoor") {
			PlayerPrefs.SetString ("LastScene", "Main");
			PlayerPrefs.SetString ("CurrentScene", "Jungle");
			Application.LoadLevel ("jungle");
		}
		if (c.gameObject.tag == "JungleMat") {
			PlayerPrefs.SetString ("LastScene", "Jungle");
			PlayerPrefs.SetString ("CurrentScene", "Main");
			Application.LoadLevel ("testScene - Backup");
		}
		if (c.gameObject.tag == "CaveDoor") {
			PlayerPrefs.SetString ("LastScene", "Main");
			PlayerPrefs.SetString ("CurrentScene", "Cave");
			Application.LoadLevel ("cave");
		}
		if (c.gameObject.tag == "CaveMat") {
			PlayerPrefs.SetString ("LastScene", "Cave");
			PlayerPrefs.SetString ("CurrentScene", "Main");
			Application.LoadLevel ("testScene - Backup");
		}
		if (c.gameObject.tag == "ObserveDoor") {
			PlayerPrefs.SetString ("LastScene", "Main");
		//	PlayerPrefs.SetString ("CurrentScene", "Observatory1");
			Application.LoadLevel ("observatoryFL1");
		}
		if (c.gameObject.tag == "ObserveUpto2") {
			PlayerPrefs.SetString ("LastScene", "Observatory1");
		//	PlayerPrefs.SetString ("CurrentScene", "Observatory2");
			Application.LoadLevel ("observatoryFL2");
		}
		if (c.gameObject.tag == "ObserveUpto3") {
			PlayerPrefs.SetString ("LastScene", "Observatory2");
		//	PlayerPrefs.SetString ("CurrentScene", "Observatory3");
			Application.LoadLevel ("observatoryFL3");
		}
		if (c.gameObject.tag == "ObserveDownto1") {
			PlayerPrefs.SetString ("LastScene", "Observatory2");
			//PlayerPrefs.SetString ("CurrentScene", "Observatory1");
			Application.LoadLevel ("observatoryFL1");
		}
		if (c.gameObject.tag == "ObserveDownto2") {
			PlayerPrefs.SetString ("LastScene", "Observatory3");
			//PlayerPrefs.SetString ("CurrentScene", "Observatory1");
			Application.LoadLevel ("observatoryFL2");
		}
		if (c.gameObject.tag == "ObserveMat") {
			PlayerPrefs.SetString ("LastScene", "Observatory1");
			PlayerPrefs.SetString ("CurrentScene", "Main");
			Application.LoadLevel ("testScene - Backup");
		}
	}
}
