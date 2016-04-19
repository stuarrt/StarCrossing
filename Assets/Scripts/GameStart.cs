using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	private bool loading;

	// Use this for initialization
	void Start () {
		//Character Friend Meters
		PlayerPrefs.SetInt ("BurnadineMeter", 0);
		PlayerPrefs.SetInt ("DrCyabinMeter", 0);
		PlayerPrefs.SetInt ("GhostMeter", 0);
		PlayerPrefs.SetInt ("HatPersonMeter", 0);
		PlayerPrefs.SetInt ("IkaMeter", 0);
		PlayerPrefs.SetInt ("KhetMeter", 0);
		PlayerPrefs.SetInt ("MayorGranMeter", 0);
		PlayerPrefs.SetInt ("MorryMeter", 0);
		PlayerPrefs.SetInt ("RubyMeter", 0);
		PlayerPrefs.SetInt ("SallyMeter", 0);
		PlayerPrefs.SetInt ("TroxMeter", 0);
		//Quest Displayed
		PlayerPrefs.SetInt ("Quest0Displayed", 1);
		PlayerPrefs.SetInt ("Quest1Displayed", 1);
		PlayerPrefs.SetInt ("Quest2Displayed", 0);
		PlayerPrefs.SetInt ("Quest3Displayed", 0);
		PlayerPrefs.SetInt ("Quest4Displayed", 0);
		PlayerPrefs.SetInt ("Quest5Displayed", 0);
		PlayerPrefs.SetInt ("Quest6Displayed", 0);
		PlayerPrefs.SetInt ("Quest7Displayed", 0);
		PlayerPrefs.SetInt ("Quest8Displayed", 0);
		PlayerPrefs.SetInt ("Quest9Displayed", 0);
		PlayerPrefs.SetInt ("Quest10Displayed", 0);
		PlayerPrefs.SetInt ("Quest11Displayed", 0);
		PlayerPrefs.SetInt ("Quest12Displayed", 0);
		PlayerPrefs.SetInt ("Quest13Displayed", 0);
		//Quest Completed
		PlayerPrefs.SetInt ("Quest0Completed", 0);
		PlayerPrefs.SetInt ("Quest1Completed", 0);
		PlayerPrefs.SetInt ("Quest2Completed", 0);
		PlayerPrefs.SetInt ("Quest3Completed", 0);
		PlayerPrefs.SetInt ("Quest4Completed", 0);
		PlayerPrefs.SetInt ("Quest5Completed", 0);
		PlayerPrefs.SetInt ("Quest6Completed", 0);
		PlayerPrefs.SetInt ("Quest7Completed", 0);
		PlayerPrefs.SetInt ("Quest8Completed", 0);
		PlayerPrefs.SetInt ("Quest9Completed", 0);
		PlayerPrefs.SetInt ("Quest10Completed", 0);
		PlayerPrefs.SetInt ("Quest11Completed", 0);
		PlayerPrefs.SetInt ("Quest12Completed", 0);
		PlayerPrefs.SetInt ("Quest13Completed", 0);
		//Quest Failed
		PlayerPrefs.SetInt ("Quest0Failed", 0);
		PlayerPrefs.SetInt ("Quest1Failed", 0);
		PlayerPrefs.SetInt ("Quest2Failed", 0);
		PlayerPrefs.SetInt ("Quest3Failed", 0);
		PlayerPrefs.SetInt ("Quest4Failed", 0);
		PlayerPrefs.SetInt ("Quest5Failed", 0);
		PlayerPrefs.SetInt ("Quest6Failed", 0);
		PlayerPrefs.SetInt ("Quest7Failed", 0);
		PlayerPrefs.SetInt ("Quest8Failed", 0);
		PlayerPrefs.SetInt ("Quest9Failed", 0);
		PlayerPrefs.SetInt ("Quest10Failed", 0);
		PlayerPrefs.SetInt ("Quest11Failed", 0);
		PlayerPrefs.SetInt ("Quest12Failed", 0);
		PlayerPrefs.SetInt ("Quest13Failed", 0);
		//Fire Life
		PlayerPrefs.SetInt ("Fire0", 3);
		PlayerPrefs.SetInt ("Fire1", 3);
		PlayerPrefs.SetInt ("Fire2", 3);
		PlayerPrefs.SetInt ("Fire3", 3);
		PlayerPrefs.SetInt ("Fire4", 3);
		PlayerPrefs.SetInt ("Fire5", 3);
		PlayerPrefs.SetInt ("Fire6", 3);
		PlayerPrefs.SetInt ("Fire7", 3);
		PlayerPrefs.SetInt ("Fire8", 3);
		PlayerPrefs.SetInt ("Fire9", 3);
		PlayerPrefs.SetInt ("Fire10", 3);
		PlayerPrefs.SetInt ("Fire11", 3);
		PlayerPrefs.SetInt ("Fire12", 3);
		PlayerPrefs.SetInt ("Fire13", 3);
		//Inventory
		PlayerPrefs.SetInt ("HasShovel", 0);
		//Player Money
		PlayerPrefs.SetInt ("Money", 0);
		//Track Scene
		PlayerPrefs.SetString ("LastScene", "Main");
		PlayerPrefs.SetString ("CurrentScene", "Main");
	}

	void OnGUI() {
		//GUI.Box (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 150, 200, 300), "");
		//GUI.Box (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 150, 200, 300), "");
		//GUI.Box (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 150, 200, 300), "");
		if (loading) {
			GUI.Label (new Rect(Screen.width / 2, (Screen.height / 2), 300, 40), "Loading...");
		}
		if (GUI.Button (new Rect ((Screen.width / 2) - 75, (Screen.height / 2) - 125, 150, 50), "Play")) {
			loading = true;
			Application.LoadLevel ("testScene - Backup");
		}
		if (GUI.Button (new Rect ((Screen.width / 2) - 75, (Screen.height / 2) + 55, 150, 50), "Quit")) {
			Application.Quit ();
		}
	}
}
