using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class KhetDialogue : Dialogue {

	private string[] scrapintronpc; //additional parsing
	private string[] scrapintroresponses; //additional parsing
	private string[] scrapduringnpc; //additional parsing
	private string[] scrapduringresponses; //additional parsing
	private string[] scrapcompleted; //additional parsing
	private string[] scrapfailed; //additional parsing
	private string[] shelterintronpc; //additional parsing
	private string[] shelterintroresponses; //additional parsing
	private string[] shelterduringnpc; //additional parsing
	private string[] shelterduringresponses; //additional parsing
	private string[] sheltercompleted; //additional parsing
	private string[] shelterfailed; //additional parsing
	private string[] slimeintronpc; //additional parsing
	private string[] slimeintroresponses; //additional parsing
	private string[] slimeduringnpc; //additional parsing
	private string[] slimeduringresponses; //additional parsing
	private string[] slimecompleted; //additional parsing
	private string[] slimefailed; //additional parsing
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
		myname = "Khet";
		npcname = "Khet"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("KhetMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Khet/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Khet/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Khet/scrapQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Khet/scrapQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/Khet/scrapQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/Khet/scrapQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/Khet/scrapQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/Khet/scrapQuestFailed.txt"); //main dialogue
		textfile6 = File.ReadAllText ("Assets/Dialogue/Khet/shelterQuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/Khet/shelterQuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/Khet/shelterQuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/Khet/shelterQuestDuringResponses.txt"); //player responses
		textfile8 = File.ReadAllText ("Assets/Dialogue/Khet/shelterQuestCompleted.txt"); //main dialogue
		textfile9 = File.ReadAllText ("Assets/Dialogue/Khet/shelterQuestFailed.txt"); //main dialogue
		textfile10 = File.ReadAllText ("Assets/Dialogue/Khet/slimeQuestIntro.txt"); //main dialogue
		responsefile6 = File.ReadAllText ("Assets/Dialogue/Khet/slimeQuestIntroResponses.txt"); //player responses
		textfile11 = File.ReadAllText ("Assets/Dialogue/Khet/slimeQuestDuring.txt"); //main dialogue
		responsefile7 = File.ReadAllText ("Assets/Dialogue/Khet/slimeQuestDuringResponses.txt"); //player responses
		textfile12 = File.ReadAllText ("Assets/Dialogue/Khet/slimeQuestCompleted.txt"); //main dialogue
		textfile13 = File.ReadAllText ("Assets/Dialogue/Khet/slimeQuestFailed.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		scrapintronpc = textfile2.Split('\n');
		scrapduringnpc = textfile3.Split('\n');
		scrapcompleted = textfile4.Split('\n');
		scrapfailed = textfile5.Split('\n');
		shelterintronpc = textfile6.Split('\n');
		shelterduringnpc = textfile7.Split('\n');
		sheltercompleted = textfile8.Split('\n');
		shelterfailed = textfile9.Split('\n');
		slimeintronpc = textfile10.Split('\n');
		slimeduringnpc = textfile11.Split('\n');
		slimecompleted = textfile12.Split('\n');
		slimefailed = textfile13.Split('\n');
		responses = responsefile.Split('\n'); //main responses
		scrapintroresponses = responsefile2.Split('\n');
		scrapduringresponses = responsefile3.Split('\n');
		shelterintroresponses = responsefile4.Split('\n');
		shelterduringresponses = responsefile5.Split('\n');
		slimeintroresponses = responsefile6.Split('\n');
		slimeduringresponses = responsefile7.Split('\n');
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2, responses);
		if (QuestList.quests [3].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[8].completed = true;
		}
	}
}
