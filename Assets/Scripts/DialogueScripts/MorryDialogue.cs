using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class MorryDialogue : Dialogue {

	private string[] scrapintronpc; //additional parsing
	private string[] scrapintroresponses; //additional parsing
	private string[] scrapduringnpc; //additional parsing
	private string[] scrapduringresponses; //additional parsing
	private string[] scrapcompleted; //additional parsing
	private string[] scrapfailed; //additional parsing
	private string[] fliersintronpc; //additional parsing
	private string[] fliersintroresponses; //additional parsing
	private string[] fliersduringnpc; //additional parsing
	private string[] fliersduringresponses; //additional parsing
	private string[] flierscompleted; //additional parsing
	private string[] fliersfailed; //additional parsing
	private string[] joinChurchintronpc; //additional parsing
	private string[] joinChurchintroresponses; //additional parsing
	private string[] joinChurchduringnpc; //additional parsing
	private string[] joinChurchduringresponses; //additional parsing
	private string[] joinChurchcompleted; //additional parsing
	private string[] joinChurchfailed; //additional parsing
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
		myname = "Morry";
		npcname = "Morry"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("MorryMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Morry/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Morry/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Morry/scrapQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Morry/scrapQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/Morry/scrapQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/Morry/scrapQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/Morry/scrapQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/Morry/scrapQuestFailed.txt"); //main dialogue
		textfile6 = File.ReadAllText ("Assets/Dialogue/Morry/fliersQuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/Morry/fliersQuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/Morry/fliersQuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/Morry/fliersQuestDuringResponses.txt"); //player responses
		textfile8 = File.ReadAllText ("Assets/Dialogue/Morry/fliersQuestCompleted.txt"); //main dialogue
		textfile9 = File.ReadAllText ("Assets/Dialogue/Morry/fliersQuestFailed.txt"); //main dialogue
		textfile10 = File.ReadAllText ("Assets/Dialogue/Morry/joinChurchQuestIntro.txt"); //main dialogue
		responsefile6 = File.ReadAllText ("Assets/Dialogue/Morry/joinChurchQuestIntroResponses.txt"); //player responses
		textfile11 = File.ReadAllText ("Assets/Dialogue/Morry/joinChurchQuestDuring.txt"); //main dialogue
		responsefile7 = File.ReadAllText ("Assets/Dialogue/Morry/joinChurchQuestDuringResponses.txt"); //player responses
		textfile12 = File.ReadAllText ("Assets/Dialogue/Morry/joinChurchQuestCompleted.txt"); //main dialogue
		textfile13 = File.ReadAllText ("Assets/Dialogue/Morry/joinChurchQuestFailed.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		scrapintronpc = textfile2.Split('\n');
		scrapduringnpc = textfile3.Split('\n');
		scrapcompleted = textfile4.Split('\n');
		scrapfailed = textfile5.Split('\n');
		fliersintronpc = textfile6.Split('\n');
		fliersduringnpc = textfile7.Split('\n');
		flierscompleted = textfile8.Split('\n');
		fliersfailed = textfile9.Split('\n');
		joinChurchintronpc = textfile10.Split('\n');
		joinChurchduringnpc = textfile11.Split('\n');
		joinChurchcompleted = textfile12.Split('\n');
		joinChurchfailed = textfile13.Split('\n');
		responses = responsefile.Split('\n'); //main responses
		scrapintroresponses = responsefile2.Split('\n');
		scrapduringresponses = responsefile3.Split('\n');
		fliersintroresponses = responsefile4.Split('\n');
		fliersduringresponses = responsefile5.Split('\n');
		joinChurchintroresponses = responsefile6.Split('\n');
		joinChurchduringresponses = responsefile7.Split('\n');
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2, responses);
		if (QuestList.quests [3].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[9].completed = true;
		}
	}
}
