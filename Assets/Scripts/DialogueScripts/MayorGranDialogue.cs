using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class MayorGranDialogue : Dialogue {

	private string[] lines2; //additional parsing
	private static string textfile2; //additional dialogue

	// Use this for initialization
	void Start () {
		myname = "Mayor Gran";
		npcname = "MayorGran"; //Name of NPC (listed as a tag)
		textfile = File.ReadAllText ("Assets/Dialogue/MayorGran/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/MayorGran/introresponses.txt"); //player responses
		lines = textfile.Split('\n'); //main parser
		//lines2 = textfile2.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2, responses);
		if (!QuestList.quests [0].completed && (selection[0] == responses[0] || selection[0] == responses[1])) {
			addQuest(0);
		}
	}
}
