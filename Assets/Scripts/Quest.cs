using UnityEngine;
using System.Collections;

public class Quest {

	//Quests are based off their name and whether they should be displayed and if they have been completed
	public string name;
	public bool display;
	public bool completed;
		
	public Quest(string n, bool d, bool c) {
		name = n;
		display = d;
		completed = c;
	}

}
