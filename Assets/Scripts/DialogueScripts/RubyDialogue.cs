using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class RubyDialogue : Dialogue {

	private static string textfile2; //additional dialogue
	private static string responsefile2; //additional dialogue
	private static string textfile3; //additional dialogue
	private static string responsefile3; //additional dialogue
	private string[] lines2; //additional parsing
	private string[] responses2;
	private string[] lines3; //additional parsing
	private string[] responses3;
	private string[] droughtintronpc; //additional parsing
	private string[] droughtintroresponses; //additional parsing
	private string[] droughtduringnpc; //additional parsing
	private string[] droughtduringresponses; //additional parsing
	private string[] droughtcompleted; //additional parsing
	private string[] droughtfailed; //additional parsing
	private static string textfile6; //additional dialogue
	private static string textfile7; //additional dialogue
	private static string textfile8; //additional dialogue
	private static string textfile9; //additional dialogue
	private static string responsefile4;
	private static string responsefile5;
	
	void Start() {
		myname = "Ruby";
		npcname = "Ruby"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("RubyMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Ruby/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Ruby/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Ruby/introductionFinished.txt"); //other lines of dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Ruby/introductionFinishedresponses.txt"); //other lines of dialogue
		textfile3 = File.ReadAllText ("Assets/Dialogue/Ruby/introductionFinished.txt"); //other lines of dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/Ruby/introductionFinishedresponses.txt"); //other lines of dialogue
		textfile6 = File.ReadAllText ("Assets/Dialogue/Ruby/droughtQuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/Ruby/droughtQuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/Ruby/droughtQuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/Ruby/droughtQuestDuringResponses.txt"); //player responses
		textfile8 = File.ReadAllText ("Assets/Dialogue/Ruby/droughtQuestCompleted.txt"); //main dialogue
		textfile9 = File.ReadAllText ("Assets/Dialogue/Ruby/droughtQuestFailed.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		lines2 = textfile2.Split('\n'); //second parser
		lines3 = textfile3.Split('\n'); //second parser
		droughtintronpc = textfile6.Split('\n');
		droughtduringnpc = textfile7.Split('\n');
		droughtcompleted = textfile8.Split('\n');
		droughtfailed = textfile9.Split('\n');
		responses = responsefile.Split('\n'); //main responses
		responses2 = responsefile2.Split('\n'); //main responses
		responses3 = responsefile3.Split('\n'); //main responses
		droughtintroresponses = responsefile4.Split('\n');
		droughtduringresponses = responsefile5.Split('\n');
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		if (!QuestList.quests [3].completed) {
			conversation (lines, new List<int> (){});
			choiceBox (0, 1, 2, responses);
		}
		if (QuestList.quests [3].completed) {
			conversation (lines2, new List<int> (){});
			choiceBox (0, 1, 2, responses2);
		}
		if (QuestList.quests [2].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			QuestList.quests[2].completed = true;
			addQuest(3);
			addQuest(4);
			addQuest(5);
			addQuest(6);
			addQuest(7);
			addQuest(8);
			addQuest(9);
			addQuest(10);
			addQuest(11);
		//	print ("Quest Display: " + QuestList.quests[6].display);
		}
		if (SallyDialogue.checkedOn && TroxDialogue.checkedOn && MorryDialogue.checkedOn && KhetDialogue.checkedOn && IkaDialogue.checkedOn && HatPersonDialogue.checkedOn && DrCyabinDialogue.checkedOn && BurnadineDialogue.checkedOn) {
			QuestList.quests[3].completed = true;
		}
	}
}
