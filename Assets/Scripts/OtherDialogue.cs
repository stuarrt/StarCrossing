using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class OtherDialogue : Dialogue {

	private string[] lines2; //additional parsing
	private static string textfile2; //additional dialogue

	// Use this for initialization
	void Start () {
		npcname = "OtherName"; //Name of NPC (listed as a tag)
		textfile = File.ReadAllText ("Assets/Dialogue/OtherNPC/othernpc.txt"); //main dialogue
		//responsefile = File.ReadAllText ("Assets/Dialogue/OtherNPC/npcresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/OtherNPC/othernpc2.txt"); //other lines of dialogue
		lines = textfile.Split('\n'); //main parser
		lines2 = textfile2.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		if (!QuestList.quests [0].completed) {
			conversation(lines);
		}
		if (QuestList.quests [0].completed) {
			conversation(lines2);
		}
	}
}
