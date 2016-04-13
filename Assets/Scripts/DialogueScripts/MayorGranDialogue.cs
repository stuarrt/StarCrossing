using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class MayorGranDialogue : Dialogue {

	private string[] checkMorryintronpc; //additional parsing
	private string[] checkMorryintroresponses; //additional parsing
	private string[] checkMorryduringnpc; //additional parsing
	private string[] checkMorryduringresponses; //additional parsing
	private string[] checkMorrycompleted; //additional parsing
	private string[] checkMorryfailed; //additional parsing
	private static string textfile2; //additional dialogue
	private static string textfile3; //additional dialogue
	private static string textfile4; //additional dialogue
	private static string textfile5; //additional dialogue
	private static string responsefile2;
	private static string responsefile3;

	// Use this for initialization
	void Start () {
		myname = "Mayor Gran";
		npcname = "MayorGran"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("MayorGranMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/MayorGran/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/MayorGran/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/MayorGran/checkMorryQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/MayorGran/checkMorryQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/MayorGran/checkMorryQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/MayorGran/checkMorryQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/MayorGran/checkMorryQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/MayorGran/checkMorryQuestFailed.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		checkMorryintronpc = textfile2.Split('\n');
		checkMorryduringnpc = textfile3.Split('\n');
		checkMorrycompleted = textfile4.Split('\n');
		checkMorryfailed = textfile5.Split('\n');
		responses = responsefile.Split('\n'); //main responses
		checkMorryintroresponses = responsefile2.Split('\n');
		checkMorryduringresponses = responsefile3.Split('\n');
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2, responses);
		if (!QuestList.quests [2].completed && (selection[0] == responses[0] || selection[0] == responses[1])) {
			addQuest(2);
			QuestList.quests[1].completed = true;
		}
	}
}
