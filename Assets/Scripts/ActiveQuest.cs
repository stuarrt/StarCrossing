using UnityEngine;
using System.Collections;

public class ActiveQuest : MonoBehaviour {

	public GameObject fossil;
	public GameObject wallacepost;

	// Use this for initialization
	void Start () {
		fossil.SetActive (false);
		wallacepost.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		int doOnceA = 0;
		int doOnceB = 0;
		if (QuestList.quests [12].display && doOnceA == 0) {
			doOnceA = 1;
			wallacepost.SetActive(true);
		}
		if (QuestList.quests [13].display && doOnceB == 0) {
			doOnceB = 1;
			fossil.SetActive(true);
		}
	}
}
