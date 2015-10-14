using UnityEngine;
using System.Collections;

public class Quest {

	//Quests are based off their name and whether they are completed or not
	public string name;
	public bool display;
	public bool completed;
		
	public Quest(string n, bool d, bool c) {
		name = n;
		display = d;
		completed = c;
	}

}
