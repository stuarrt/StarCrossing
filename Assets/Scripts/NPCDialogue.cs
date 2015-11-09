using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NPCDialogue : Dialogue {

	private static string textfile2; //additional dialogue
	private string[] lines2; //additional parsing

	void Start() {
		npcname = "NPCName"; //Name of NPC (listed as a tag)
		textfile = File.ReadAllText ("Assets/Dialogue/NPCName/npcname.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/NPCName/npcresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/NPCName/npcname2.txt"); //other lines of dialogue
		lines = textfile.Split('\n'); //main parser
		lines2 = textfile2.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
	}

	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		if (!QuestList.quests [0].completed || !QuestList.quests [0].display) {
			makeChoice(lines, new List<int>(){1}, responses[0], responses[1], responses[2]);
			dropMenu(0, 150, 1);
		//	choiceBox(0, 1);
		}
		//How much dialogue the player must go through to accept the quest ##dialoguecount >= 1
		if (selection[0] == responses[0] && goodbye) {
			addQuest(0);
		}
		//If the player has accepted and completed the quest
		if (QuestList.quests [0].completed && QuestList.quests [0].display) {
			conversation(lines2);
		}
	}
}
