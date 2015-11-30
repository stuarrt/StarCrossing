using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SunDialogue : Dialogue {

	private static string textfile2; //additional dialogue
	private string[] lines2; //additional parsing
	
	void Start() {
		npcname = "SunName"; //Name of NPC (listed as a tag)
		textfile = File.ReadAllText ("Assets/Dialogue/SunNPC/sunnpc.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/SunNPC/sunresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/SunNPC/sunnpc2.txt"); //other lines of dialogue
		lines = textfile.Split('\n'); //main parser
		lines2 = textfile2.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		if (!QuestList.quests [1].completed || !QuestList.quests [1].display) {
			conversation(lines, new List<int>(){});
			choiceBox(0, 1);
		}
		//How much dialogue the player must go through to accept the quest ##dialoguecount >= 1
		if (selection[0] == responses[0]) { //used to include && goodbye
			addQuest(1);
		}
		//If the player has accepted and completed the quest
		if (QuestList.quests [1].completed && QuestList.quests [1].display) {
			conversation(lines2, new List<int>(){});
		}
	}
}
