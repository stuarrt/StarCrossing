using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class HatPersonDialogue : Dialogue {

	private string[] scrapintronpc; //additional parsing
	private static string textfile2; //additional dialogue
	private static string responsefile2;
	private string[] scrapduringnpc; //additional parsing
	private static string textfile3; //additional dialogue
	private static string responsefile3;
	private string[] scrapintroresponses; //additional parsing
	private string[] scrapduringresponses; //additional parsing
	private string[] scrapcompleted; //additional parsing
	private static string textfile4; //additional dialogue
	private string[] scrapfailed; //additional parsing
	private static string textfile5; //additional dialogue
	private string[] suitintronpc; //additional parsing
	private static string textfile6; //additional dialogue
	private static string responsefile4;
	private string[] suitduringnpc; //additional parsing
	private static string textfile7; //additional dialogue
	private static string responsefile5;
	private string[] suitintroresponses; //additional parsing
	private string[] suitduringresponses; //additional parsing
	private string[] suitcompleted; //additional parsing
	private static string textfile8; //additional dialogue
	private string[] suitfailed; //additional parsing
	private static string textfile9; //additional dialogue

	public static bool checkedOn;
	
	// Use this for initialization
	void Start () {
		myname = "Hat Person";
		npcname = "HatPerson"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("HatPersonMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Hatguy/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Hatguy/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Hatguy/scrapQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Hatguy/scrapQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/Hatguy/scrapQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/Hatguy/scrapQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/Hatguy/scrapQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/Hatguy/scrapQuestFailed.txt"); //player responses
		textfile6 = File.ReadAllText ("Assets/Dialogue/Hatguy/suitQuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/Hatguy/suitQuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/Hatguy/suitQuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/Hatguy/suitQuestDuringResponses.txt"); //player responses
		textfile8 = File.ReadAllText ("Assets/Dialogue/Hatguy/suitQuestCompleted.txt"); //main dialogue
		textfile9 = File.ReadAllText ("Assets/Dialogue/Hatguy/suitQuestFailed.txt"); //player responses
		lines = textfile.Split('\n'); //main parser
		scrapintronpc = textfile2.Split('\n'); //second parser
		scrapduringnpc = textfile3.Split('\n'); //second parser
		scrapcompleted = textfile4.Split('\n');
		scrapfailed = textfile5.Split('\n');
		suitintronpc = textfile6.Split('\n'); //second parser
		suitduringnpc = textfile7.Split('\n'); //second parser
		suitcompleted = textfile8.Split('\n'); //second parser
		suitfailed = textfile9.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
		scrapintroresponses = responsefile2.Split('\n'); //main responses
		scrapduringresponses = responsefile3.Split('\n'); //main responses
		suitintroresponses = responsefile4.Split('\n'); //main responses
		suitduringresponses = responsefile5.Split('\n'); //main responses
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2, responses);
		if (QuestList.quests [3].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[6].completed = true;
		}
	}
}
