using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class RubyDialogue : Dialogue {

	private static string textfile2; //additional dialogue
	private string[] lines2; //additional parsing
	
	void Start() {
		myname = "Ruby";
		npcname = "Ruby"; //Name of NPC (listed as a tag)
		textfile = File.ReadAllText ("Assets/Dialogue/Ruby/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Ruby/introresponses.txt"); //player responses
		//textfile2 = File.ReadAllText ("Assets/Dialogue/Ruby/sunnpc2.txt"); //other lines of dialogue
		lines = textfile.Split('\n'); //main parser
	//	lines2 = textfile2.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2);
		if (QuestList.quests [0].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			QuestList.quests[0].completed = true;
			addQuest(1);
		}
		if (SallyDialogue.checkedOn && TroxDialogue.checkedOn && MorryDialogue.checkedOn && KhetDialogue.checkedOn && IkaDialogue.checkedOn && HatPersonDialogue.checkedOn && DrCyabinDialogue.checkedOn && BurnadineDialogue.checkedOn) {
			QuestList.quests[1].completed = true;
		}
	}
}
