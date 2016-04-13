using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class TroxDialogue : Dialogue {

	private string[] winkyintronpc; //additional parsing
	private string[] winkyintroresponses; //additional parsing
	private string[] winkyduringnpc; //additional parsing
	private string[] winkyduringresponses; //additional parsing
	private string[] winkycompleted; //additional parsing
	private string[] winkyfailed; //additional parsing
	private string[] winky2intronpc; //additional parsing
	private string[] winky2introresponses; //additional parsing
	private string[] winky2duringnpc; //additional parsing
	private string[] winky2duringresponses; //additional parsing
	//private string[] winky2completed; //additional parsing
	//private string[] winky2failed; //additional parsing
	private static string textfile2; //additional dialogue
	private static string textfile3; //additional dialogue
	private static string textfile4; //additional dialogue
	private static string textfile5; //additional dialogue
	private static string textfile6; //additional dialogue
	private static string textfile7; //additional dialogue
	//private static string textfile8; //additional dialogue
	//private static string textfile9; //additional dialogue
	private static string responsefile2;
	private static string responsefile3;
	private static string responsefile4;
	private static string responsefile5;

	public static bool checkedOn;
	
	// Use this for initialization
	void Start () {
		myname = "Trox";
		npcname = "Trox"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("TroxMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Trox/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Trox/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Trox/winkyQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Trox/winkyQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/Trox/winkyQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/Trox/winkyQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/Trox/winkyQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/Trox/winkyQuestFailed.txt"); //main dialogue
		textfile6 = File.ReadAllText ("Assets/Dialogue/Trox/winky2QuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/Trox/winky2QuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/Trox/winky2QuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/Trox/winky2QuestDuringResponses.txt"); //player responses
		//textfile8 = File.ReadAllText ("Assets/Dialogue/Trox/winky2QuestCompleted.txt"); //main dialogue
		//textfile9 = File.ReadAllText ("Assets/Dialogue/Trox/winky2QuestFailed.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		winkyintronpc = textfile2.Split('\n');
		winkyduringnpc = textfile3.Split('\n');
		winkycompleted = textfile4.Split('\n');
		winkyfailed = textfile5.Split('\n');
		winky2intronpc = textfile6.Split('\n');
		winky2duringnpc = textfile7.Split('\n');
		//winky2completed = textfile8.Split('\n');
		//winky2failed = textfile9.Split('\n');
		winkyintroresponses = responsefile2.Split('\n');
		winkyduringresponses = responsefile3.Split('\n');
		winky2introresponses = responsefile4.Split('\n');
		winky2duringresponses = responsefile5.Split('\n');
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		//if (!QuestList.quests [3].completed) {
			conversation (lines, new List<int> (){});
			choiceBox (0, 1, 2, responses);
		//}
		/*
		if (QuestList.quests [3].completed && !QuestList.quests [12].completed) {
			conversation (lines2, new List<int> (){});
			choiceBox (0, 1, 2, responses2);
		}
		if (QuestList.quests [12].display && QuestList.quests [12].completed && QuestList.quests [3].completed) {
			conversation (lines3, new List<int> (){});
		}
		if (QuestList.quests [3].completed && (selection[0] == responses2[0] || selection[0] == responses2[1])) {
			addQuest(12);
		}
		*/
		if (QuestList.quests [3].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[11].completed = true;
		}
	}
}
