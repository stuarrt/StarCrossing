using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class BurnadineDialogue : Dialogue {

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
	private string[] sporeintronpc; //additional parsing
	private static string textfile6; //additional dialogue
	private static string responsefile4;
	private string[] sporeduringnpc; //additional parsing
	private static string textfile7; //additional dialogue
	private static string responsefile5;
	private string[] sporeintroresponses; //additional parsing
	private string[] sporeduringresponses; //additional parsing
	private string[] sporecompleted; //additional parsing
	private static string textfile8; //additional dialogue
	private string[] sporefailed; //additional parsing
	private static string textfile9; //additional dialogue

	public static bool checkedOn;
	
	// Use this for initialization
	void Start () {
		myname = "Burnadine";
		npcname = "Burnadine"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("BurnadineMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Burnadine/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Burnadine/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Burnadine/cleanScrapQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Burnadine/cleanScrapQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/Burnadine/cleanScrapQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/Burnadine/cleanScrapQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/Burnadine/cleanScrapQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/Burnadine/cleanScrapQuestFailed.txt"); //player responses
		textfile6 = File.ReadAllText ("Assets/Dialogue/Burnadine/plantSporesQuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/Burnadine/plantSporesQuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/Burnadine/plantSporesQuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/Burnadine/plantSporesQuestDuringResponses.txt"); //player responses
		textfile8 = File.ReadAllText ("Assets/Dialogue/Burnadine/plantSporesQuestCompleted.txt"); //main dialogue
		textfile9 = File.ReadAllText ("Assets/Dialogue/Burnadine/plantSporesQuestFailed.txt"); //player responses
		lines = textfile.Split('\n'); //main parser
		scrapintronpc = textfile2.Split('\n'); //second parser
		scrapduringnpc = textfile3.Split('\n'); //second parser
		scrapcompleted = textfile4.Split('\n');
		scrapfailed = textfile5.Split('\n');
		sporeintronpc = textfile6.Split('\n'); //second parser
		sporeduringnpc = textfile7.Split('\n'); //second parser
		sporecompleted = textfile8.Split('\n'); //second parser
		sporefailed = textfile9.Split('\n'); //second parser
		responses = responsefile.Split('\n'); //main responses
		scrapintroresponses = responsefile2.Split('\n'); //main responses
		scrapduringresponses = responsefile3.Split('\n'); //main responses
		sporeintroresponses = responsefile4.Split('\n'); //main responses
		sporeduringresponses = responsefile5.Split('\n'); //main responses
	}

	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2, responses);
		if (QuestList.quests [3].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[4].completed = true;
		}
	}
}
