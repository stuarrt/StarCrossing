using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NPCDialogue : Dialogue {

	private static string textfile2; //additional dialogue
	private string[] lines2; //additional parsing

	void Start() {
		npcname = "NPCName"; //Name of NPC (listed as a tag)
		textfile = File.ReadAllText ("Assets/npcname.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/npcresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/npcname2.txt"); //other lines of dialogue
		lines = textfile.Split('\n'); //main parser
		lines2 = textfile2.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
	}

	public override void OnGUI() {
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		if (!QuestList.quests [0].completed) {
			conversation(lines);
		}
		if (dialoguecount >= 1) {
			addQuest(0);
		}
		//If the player has talked to
		if (QuestList.quests [0].completed && QuestList.quests [0].display) {
			conversation(lines2);
		}
	}
}
