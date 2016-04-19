using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("LastScene") == "Store") {
			gameObject.transform.position = new Vector3 (19.18f, 1.372f, -18.41f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "FishHut") {
			gameObject.transform.position = new Vector3 (11.09f, 1.372f, 5.15f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "Observatory1" && PlayerPrefs.GetString ("CurrentScene") == "Main") {
			gameObject.transform.position = new Vector3 (34.28f, 2.85f, -30.9f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "Observatory2") {
			gameObject.transform.position = new Vector3 (20.2f, 2.85f, -13.24f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "Observatory3") {
			gameObject.transform.position = new Vector3 (16.32f, 4.22f, -15.51f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "Cave") {
			//gameObject.transform.position = new Vector3 (-36.4f, 1.372f, -8.374f);
			gameObject.transform.position = new Vector3 (21.68f, 1.372f, -34.88f);
		}
		if (PlayerPrefs.GetString ("LastScene") == "Jungle") {
			//gameObject.transform.position = new Vector3 (21.68f, 1.372f, -34.88f);
			gameObject.transform.position = new Vector3 (-36.4f, 1.372f, -8.374f);
		}
	}

}
