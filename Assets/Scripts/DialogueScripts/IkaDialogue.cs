using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class IkaDialogue : Dialogue {

	private string[] deliveryintronpc; //additional parsing
	private string[] deliveryintroresponses; //additional parsing
	private string[] deliveryduringnpc; //additional parsing
	private string[] deliveryduringresponses; //additional parsing
	private string[] deliverycompleted; //additional parsing
	private string[] deliveryfailed; //additional parsing
	private string[] delivery2intronpc; //additional parsing
	private string[] delivery2introresponses; //additional parsing
	private string[] delivery2duringnpc; //additional parsing
	private string[] delivery2duringresponses; //additional parsing
	private string[] delivery2completed; //additional parsing
	private string[] delivery2failed; //additional parsing
	private static string textfile2; //additional dialogue
	private static string textfile3; //additional dialogue
	private static string textfile4; //additional dialogue
	private static string textfile5; //additional dialogue
	private static string textfile6; //additional dialogue
	private static string textfile7; //additional dialogue
	private static string textfile8; //additional dialogue
	private static string textfile9; //additional dialogue
	private static string responsefile2;
	private static string responsefile3;
	private static string responsefile4;
	private static string responsefile5;

	public static bool checkedOn;
	
	// Use this for initialization
	void Start () {
		myname = "Ika";
		npcname = "Ika"; //Name of NPC (listed as a tag)
		friendmeter = PlayerPrefs.GetInt ("IkaMeter");
		textfile = File.ReadAllText ("Assets/Dialogue/Ika/introduction.txt"); //main dialogue
		responsefile = File.ReadAllText ("Assets/Dialogue/Ika/introresponses.txt"); //player responses
		textfile2 = File.ReadAllText ("Assets/Dialogue/Ika/deliveryQuestIntro.txt"); //main dialogue
		responsefile2 = File.ReadAllText ("Assets/Dialogue/Ika/deliveryQuestIntroResponses.txt"); //player responses
		textfile3 = File.ReadAllText ("Assets/Dialogue/Ika/deliveryQuestDuring.txt"); //main dialogue
		responsefile3 = File.ReadAllText ("Assets/Dialogue/Ika/deliveryQuestDuringResponses.txt"); //player responses
		textfile4 = File.ReadAllText ("Assets/Dialogue/Ika/deliveryQuestCompleted.txt"); //main dialogue
		textfile5 = File.ReadAllText ("Assets/Dialogue/Ika/deliveryQuestFailed.txt"); //main dialogue
		textfile6 = File.ReadAllText ("Assets/Dialogue/Ika/delivery2QuestIntro.txt"); //main dialogue
		responsefile4 = File.ReadAllText ("Assets/Dialogue/Ika/delivery2QuestIntroResponses.txt"); //player responses
		textfile7 = File.ReadAllText ("Assets/Dialogue/Ika/delivery2QuestDuring.txt"); //main dialogue
		responsefile5 = File.ReadAllText ("Assets/Dialogue/Ika/delivery2QuestDuringResponses.txt"); //player responses
		textfile8 = File.ReadAllText ("Assets/Dialogue/Ika/delivery2QuestCompleted.txt"); //main dialogue
		textfile9 = File.ReadAllText ("Assets/Dialogue/Ika/delivery2QuestFailed.txt"); //main dialogue
		lines = textfile.Split('\n'); //main parser
		deliveryintronpc = textfile2.Split('\n');
		deliveryduringnpc = textfile3.Split('\n');
		deliverycompleted = textfile4.Split('\n');
		deliveryfailed = textfile5.Split('\n');
		delivery2intronpc = textfile6.Split('\n');
		delivery2duringnpc = textfile7.Split('\n');
		delivery2completed = textfile8.Split('\n');
		delivery2failed = textfile9.Split('\n');
		responses = responsefile.Split('\n'); //main responses
		deliveryintroresponses = responsefile2.Split('\n');
		deliveryduringresponses = responsefile3.Split('\n');
		delivery2introresponses = responsefile4.Split('\n');
		delivery2duringresponses = responsefile5.Split('\n');
	}
	
	public override void OnGUI() {
		//Inherits Dialogue OnGUI
		base.OnGUI ();
		//Dialogue based off whether the quest was completed or not
		conversation(lines, new List<int>(){});
		choiceBox(0, 1, 2, responses);
		if (QuestList.quests [3].display && (selection[0] == responses[0] || selection[0] == responses[1])) {
			checkedOn = true;
			QuestList.quests[7].completed = true;
		}
	}
}
