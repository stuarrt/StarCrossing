using UnityEngine;
using System.Collections;

public class Quest {

	//Quests are based off their name and whether they are completed or not
	public string name;
	public bool completed;
		
	public Quest(string n, bool c) {
		name = n;
		completed = c;
	}

}
