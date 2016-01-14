using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class DrCyabinDialogue : Dialogue {

	private string[] lines2; //additional parsing
	private string[] responses2;
	private static string textfile2; //additional dialogue
	private static string responsefile2; //additional dialogue
	private string[] lines3; //additional parsing
	private static string textfile3; //additional dialogue

	
	public static bool checkedOn;
	
	// Use this for initialization
	void Start () {
		myname = "Dr. Cyabin";
		npcname = "DrCyabin"; //Name of NPC (listed as a tag)
		textfile = File.ReadAllText ("Assets/Dialogue/DrCyabin/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/DrCyabin/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/DrCyabin/fossilQuest.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/DrCyabin/fossilResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/DrCyabin/fossilFinish.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		lines2 = textfile2.Split('\n'); //second parser
		lines3 = textfile3.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
		responses2 = responsefile2.Split('\n'); //main responses
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		if (!QuestList.quests [1].completed) {
			conversation (lines, new List<int> (){});
			choiceBox (0, 1, 2, responses);
		}
		if (QuestList.quests [1].completed && !QuestList.quests [11].completed) {
			conversation (lines2, new List<int> (){});
			choiceBox (0, 1, 2, responses2);
		}
		if (QuestList.quests [11].display && QuestList.quests [11].completed && QuestList.quests [1].completed) {
			conversation (lines3, new List<int> (){});
		}
		if (QuestList.quests [1].completed && (selection[0] == responses2[0] || selection[0] == responses2[1])) {
			addQuest(11);
		}
		if (QuestList.quests [1].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[3].completed = true;
		}
	}
}
