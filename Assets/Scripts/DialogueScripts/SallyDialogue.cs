using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SallyDialogue : Dialogue {

	private string[] boatintronpc; //additional parsing
	private string[] boatintroresponses; //additional parsing
	private string[] boatduringnpc; //additional parsing
	private string[] boatduringresponses; //additional parsing
	private string[] boatcompleted; //additional parsing
	private string[] boatfailed; //additional parsing
	private string[] hookintronpc; //additional parsing
	private string[] hookintroresponses; //additional parsing
	private string[] hookduringnpc; //additional parsing
	private string[] hookduringresponses; //additional parsing
	private string[] hookcompleted; //additional parsing
	private string[] hookfailed; //additional parsing
	private string[] pellyintronpc; //additional parsing
	private string[] pellyduringnpc; //additional parsing
	private string[] pellycompleted; //additional parsing
	private string[] pellyfailed; //additional parsing
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


	public static bool checkedOn;
	
	// Use this for initialization
	void Start () {
		myname = "Sally";
		npcname = "Sally"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("SallyMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Sally/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Sally/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Sally/boatQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Sally/boatQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/Sally/boatQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/Sally/boatQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/Sally/boatQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/Sally/boatQuestFailed.txt"); //main dialogue
		textfile6 = File.ReadAllText ("Assets/Dialogue/Sally/hookQuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/Sally/hookQuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/Sally/hookQuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/Sally/hookQuestDuringResponses.txt"); //player responses
		textfile8 = File.ReadAllText ("Assets/Dialogue/Sally/hookQuestCompleted.txt"); //main dialogue
		textfile9 = File.ReadAllText ("Assets/Dialogue/Sally/hookQuestFailed.txt"); //main dialogue
		textfile10 = File.ReadAllText ("Assets/Dialogue/Sally/pellyQuestIntro.txt"); //main dialogue
		textfile11 = File.ReadAllText ("Assets/Dialogue/Sally/pellyQuestDuring.txt"); //main dialogue
		textfile12 = File.ReadAllText ("Assets/Dialogue/Sally/pellyQuestCompleted.txt"); //main dialogue
		textfile13 = File.ReadAllText ("Assets/Dialogue/Sally/pellyQuestFailed.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		boatintronpc = textfile2.Split('\n');
		boatduringnpc = textfile3.Split('\n');
		boatcompleted = textfile4.Split('\n');
		boatfailed = textfile5.Split('\n');
		hookintronpc = textfile6.Split('\n');
		hookduringnpc = textfile7.Split('\n');
		hookcompleted = textfile8.Split('\n');
		hookfailed = textfile9.Split('\n');
		pellyintronpc = textfile10.Split('\n');
		pellyduringnpc = textfile11.Split('\n');
		pellycompleted = textfile12.Split('\n');
		pellyfailed = textfile13.Split('\n');
		responses = responsefile.Split('\n'); //main responses
		boatintroresponses = responsefile2.Split('\n');
		boatduringresponses = responsefile3.Split('\n');
		hookintroresponses = responsefile4.Split('\n');
		hookduringresponses = responsefile5.Split('\n');
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2, responses);
		if (QuestList.quests [3].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[10].completed = true;
		}
	}
}
