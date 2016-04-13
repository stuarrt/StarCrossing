using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class DrCyabinDialogue : Dialogue {

	private string[] wingintronpc; //additional parsing
	private string[] wingintroresponses; //additional parsing
	private string[] wingduringnpc; //additional parsing
	private string[] wingduringresponses; //additional parsing
	private string[] wingcompleted; //additional parsing
	private string[] wingfailed; //additional parsing
	private string[] talkintronpc; //additional parsing
	private string[] talkintroresponses; //additional parsing
	private string[] talkduringnpc; //additional parsing
	private string[] talkduringresponses; //additional parsing
	private string[] talkcompleted; //additional parsing
	private string[] talkfailed; //additional parsing
	private string[] engineintronpc; //additional parsing
	private string[] engineintroresponses; //additional parsing
	private string[] engineduringnpc; //additional parsing
	private string[] engineduringresponses; //additional parsing
	private string[] enginecompleted; //additional parsing
	private string[] enginefailed; //additional parsing
	private static string textfile2; //additional dialogue
	private static string textfile3; //additional dialogue
	private static string textfile4; //additional dialogue
	private static string textfile5; //additional dialogue
	private static string textfile6; //additional dialogue
	private static string textfile7; //additional dialogue
	private static string textfile8; //additional dialogue
	private static string textfile9; //additional dialogue
	private static string textfile10; //additional dialogue
	private static string textfile11; //additional dialogue
	private static string textfile12; //additional dialogue
	private static string textfile13; //additional dialogue
	private static string responsefile2;
	private static string responsefile3;
	private static string responsefile4;
	private static string responsefile5;
	private static string responsefile6;
	private static string responsefile7;

	
	public static bool checkedOn;
	
	// Use this for initialization
	void Start () {
		myname = "Dr. Cyabin";
		npcname = "DrCyabin"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("DrCyabinMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/DrCyabin/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/DrCyabin/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/DrCyabin/wingQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/DrCyabin/wingQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/DrCyabin/wingQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/DrCyabin/wingQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/DrCyabin/wingQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/DrCyabin/wingQuestFailed.txt"); //main dialogue
		textfile6 = File.ReadAllText ("Assets/Dialogue/DrCyabin/talkQuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/DrCyabin/talkQuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/DrCyabin/talkQuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/DrCyabin/talkQuestDuringResponses.txt"); //player responses
		textfile8 = File.ReadAllText ("Assets/Dialogue/DrCyabin/talkQuestCompleted.txt"); //main dialogue
		textfile9 = File.ReadAllText ("Assets/Dialogue/DrCyabin/talkQuestFailed.txt"); //main dialogue
		textfile10 = File.ReadAllText ("Assets/Dialogue/DrCyabin/engineQuestIntro.txt"); //main dialogue
		responsefile6 = File.ReadAllText ("Assets/Dialogue/DrCyabin/engineQuestIntroResponses.txt"); //player responses
		textfile11 = File.ReadAllText ("Assets/Dialogue/DrCyabin/engineQuestDuring.txt"); //main dialogue
		responsefile7 = File.ReadAllText ("Assets/Dialogue/DrCyabin/engineQuestDuringResponses.txt"); //player responses
		textfile12 = File.ReadAllText ("Assets/Dialogue/DrCyabin/engineQuestCompleted.txt"); //main dialogue
		textfile13 = File.ReadAllText ("Assets/Dialogue/DrCyabin/engineQuestFailed.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		wingintronpc = textfile2.Split('\n');
		wingduringnpc = textfile3.Split('\n');
		wingcompleted = textfile4.Split('\n');
		wingfailed = textfile5.Split('\n');
		talkintronpc = textfile6.Split('\n');
		talkduringnpc = textfile7.Split('\n');
		talkcompleted = textfile8.Split('\n');
		talkfailed = textfile9.Split('\n');
		engineintronpc = textfile10.Split('\n');
		engineduringnpc = textfile11.Split('\n');
		enginecompleted = textfile12.Split('\n');
		enginefailed = textfile13.Split('\n');
		wingintroresponses = responsefile2.Split('\n');
		wingduringresponses = responsefile3.Split('\n');
		talkintroresponses = responsefile4.Split('\n');
		talkduringresponses = responsefile5.Split('\n');
		engineintroresponses = responsefile6.Split('\n');
		engineduringresponses = responsefile7.Split('\n');
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		//if (!QuestList.quests [3].completed) {
			conversation (lines, new List<int> (){});
			choiceBox (0, 1, 2, responses);
	//	}
		/*
		if (QuestList.quests [3].completed && !QuestList.quests [13].completed) {
			conversation (lines2, new List<int> (){});
			choiceBox (0, 1, 2, responses2);
		}
		if (QuestList.quests [13].display && QuestList.quests [13].completed && QuestList.quests [2].completed) {
			conversation (lines3, new List<int> (){});
		}
		if (QuestList.quests [3].completed && (selection[0] == responses2[0] || selection[0] == responses2[1])) {
			addQuest(13);
		}
		*/
		if (QuestList.quests [3].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[5].completed = true;
		}
	}
}
