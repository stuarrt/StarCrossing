using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class NPCDialogue : Dialogue {

	void Start() {
		npcname = "NPCName";
		textfile = File.ReadAllText("Assets/npcname.txt");
		responsefile = File.ReadAllText("Assets/responses.txt");
		lines = textfile.Split('\n');
		responses = responsefile.Split('\n');
	}

}
