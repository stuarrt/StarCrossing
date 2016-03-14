using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class GhostDialogue : Dialogue {

	private static string textfile2; //additional dialogue
	private string[] lines2; //additional parsing
	public DayNightCycle dnc;
	
	void Start() {
		myname = "Wallace";
		npcname = "Ghost"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("GhostMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Ghost/dayone.txt"); //main dialogue
		//responsefile = File.ReadAllText ("Assets/Dialogue/Ghost/sunresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Ghost/daytwo.txt"); //other lines of dialogue
		lines = textfile.Split('\n'); //main parser
		lines2 = textfile2.Split('\n'); //second parser
		//responses = responsefile.Split('\n'); //main responses
	}

	void Update() {
		if (dnc.currentTime < 0.28f || dnc.currentTime > 0.74f) {
			this.gameObject.GetComponent<BoxCollider>().enabled = true;
		}
		else {
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			cantalk = false;
		}
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		if (dnc.days < 1) {
			conversation(lines, new List<int>(){});
		}
		//If the player has accepted and completed the quest
		if (dnc.days >= 1) {
			conversation(lines2, new List<int>(){});
		}
	}
}
