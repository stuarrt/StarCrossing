using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NPCDialogue : Dialogue {

	private static string textfile2;
	private string[] lines2;

	void Start() {
		npcname = "NPCName";
		textfile = File.ReadAllText ("Assets/npcname.txt");
		responsefile = File.ReadAllText ("Assets/responses.txt");
		textfile2 = File.ReadAllText ("Assets/npcname2.txt");
		lines = textfile.Split('\n');
		lines2 = textfile2.Split('\n');
		responses = responsefile.Split('\n');
	}

	public override void OnGUI() {
		base.OnGUI ();
		if (!QuestList.quests [0].completed) {
			conversation(lines);
		}
		if (QuestList.quests [0].completed) {
			conversation(lines2);
		}
	}
}
