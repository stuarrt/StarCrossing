using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class RubyDialogue : Dialogue {

	private static string textfile2; //additional dialogue
	private static string responsefile2; //additional dialogue
	private string[] lines2; //additional parsing
	private string[] responses2;
	
	void Start() {
		myname = "Ruby";
		npcname = "Ruby"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("RubyMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Ruby/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Ruby/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Ruby/introductionFinished.txt"); //other lines of dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Ruby/introductionFinishedresponses.txt"); //other lines of dialogue
		lines = textfile.Split('\n'); //main parser
		lines2 = textfile2.Split('\n'); //second parser
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
		if (QuestList.quests [1].completed) {
			conversation (lines2, new List<int> (){});
			choiceBox (0, 1, 2, responses2);
		}
		if (QuestList.quests [0].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			QuestList.quests[0].completed = true;
			addQuest(1);
			addQuest(2);
			addQuest(3);
			addQuest(4);
			addQuest(5);
			addQuest(6);
			addQuest(7);
			addQuest(8);
			addQuest(9);
		}
		if (SallyDialogue.checkedOn && TroxDialogue.checkedOn && MorryDialogue.checkedOn && KhetDialogue.checkedOn && IkaDialogue.checkedOn && HatPersonDialogue.checkedOn && DrCyabinDialogue.checkedOn && BurnadineDialogue.checkedOn) {
			QuestList.quests[1].completed = true;
		}
	}
}
