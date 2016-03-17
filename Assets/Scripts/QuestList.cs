using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class QuestList : MonoBehaviour {

	public GUIStyle qlist;

	public GUIStyle qboxStyle;

	public GUIStyle qboxBStyle;

	public GUIStyle noteStyle;

	public GUIStyle buttonStyle;

	public GUIStyle fontStyle;

	private bool notebook;

	private bool showinfo;

	private Texture questimage;

	//Quest Images
	public Texture mayorgran;
	public Texture ruby;
	public Texture burnadine;
	public Texture drcyabine;
	public Texture hatperson;
	public Texture ika;
	public Texture khet;
	public Texture morry;
	public Texture sally;
	public Texture trox;
	public Texture wallacepost;
	public Texture fossil;

	private string qinfo;

	private int page;

	//Holds the quests that the player can complete/has completed
	public static List<Quest> quests = new List<Quest>();

	void Start() {
		//Quests are added here
		//***NOTE: Comment to put the quest number at the end
		page = 0;
		showinfo = false;
		qinfo = "";
		quests.Add(new Quest("Talk to Mayor Gran", true, false)); //0
		quests.Add(new Quest("Talk to Ruby", false, false)); //1
		quests.Add(new Quest("Check on the Town", false, false)); //2
		quests.Add(new Quest("Talk to Burnadine", false, false)); //3
		quests.Add(new Quest("Talk to Dr. Cyabin", false, false)); //4
		quests.Add(new Quest("Talk to Hat Person", false, false)); //5
		quests.Add(new Quest("Talk to Ika", false, false)); //6
		quests.Add(new Quest("Talk to Khet", false, false)); //7
		quests.Add(new Quest("Talk to Morry", false, false)); //8
		quests.Add(new Quest("Talk to Sally", false, false)); //9
		quests.Add(new Quest("Talk to Trox", false, false)); //10
		quests.Add(new Quest("Find Wallace Poster", false, false)); //11
		quests.Add(new Quest("Find Missing Fossil", false, false)); //12
	}

	// Update is called once per frame
	void Update () {
		//These are the quest conditions
		//If a quest is completed, this updates to let the game know
		//That the player has completed the quest
		if (quests[12].display && Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Fossil]) {
			quests[12].completed = true;
		}
		if (quests[11].display && Inventory.Instance.CurrentInventory [Inventory.InventoryObjects.Shovel]) {
			quests[11].completed = true;
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			notebook = !notebook;
		}
		if (notebook) {
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				page = 0;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2) && (quests[3].display || quests[4].display || quests[5].display)) {
				page = 1;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3) && (quests[6].display || quests[7].display || quests[8].display)) {
				page = 2;
			}
			if (Input.GetKeyDown(KeyCode.Alpha4) && (quests[9].display || quests[10].display || quests[11].display)) {
				page = 3;
			}
			if (Input.GetKeyDown(KeyCode.Alpha5) && quests[12].display) {
				page = 4;
			}
			/*
			if (Input.GetKeyDown(KeyCode.Alpha6)) {
				page = 5;
			}
			if (Input.GetKeyDown(KeyCode.Alpha7)) {
				page = 6;
			}
			if (Input.GetKeyDown(KeyCode.Alpha8)) {
				page = 7;
			}
			if (Input.GetKeyDown(KeyCode.Alpha9)) {
				page = 8;
			}
			if (Input.GetKeyDown(KeyCode.Alpha0)) {
				page = 9;
			}
			if (Input.GetKeyDown(KeyCode.Minus)) {
				page = 10;
			}
			*/
		}
	}

	string questCheck(bool completed) {
		if (completed) {
			return "Completed";
		} else {
			return "In Progress";
		}
	}

	void OnGUI() {
		//Temp inventory
	//	GUI.Box (new Rect (Screen.width - 150, (Screen.height / 4) - 100, 100, 50), "");
	//	GUI.Box (new Rect (Screen.width - 150, (Screen.height / 4)- 100, 100, 50), "");
	//	GUI.Box (new Rect (Screen.width - 150, (Screen.height / 4) - 100, 100, 50), "");
	//	GUI.Label (new Rect (Screen.width - 135, (Screen.height / 4) - 85, 100, 50), "Inventory [I]");
		//Interface for Quest list
		//Opens the quest list
		//GUI.Box (new Rect (10, (Screen.height / 4) - 100, 400, 200), notebookBack, qlist);
	//	GUI.Box (new Rect (10, (Screen.height / 4) - 100, 200, 100), "");
	//	GUI.Box (new Rect (10, (Screen.height / 4) - 100, 200, 100), "");
		if (!notebook) {
		//	GUI.Box (new Rect (10, (Screen.height / 4) - 100, 100, 50), "", noteStyle);
			if (GUI.Button (new Rect (10, (Screen.height / 4) - 100, 100, 50), "", noteStyle)) {
				notebook = !notebook;
			}
		}
		//Display of the quest list
		if (notebook) {
			GUI.Box (new Rect (10, (Screen.height / 4) - 100, 300, 150), "", noteStyle);
			//GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			//GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			//GUI.Box (new Rect (10, (Screen.height / 4), 200, 20), "");
			/*
			if (page <= 9) {
				if (GUI.Button (new Rect(275, (Screen.height / 4) + 20, 20, 20), ">", buttonStyle)) {
					page += 1;
				}
			}
			*/
			if (page == 0 && (quests[3].display || quests[4].display || quests[5].display)) {
				if (GUI.Button (new Rect(275, (Screen.height / 4) + 20, 20, 20), ">", buttonStyle)) {
					page += 1;
				}
			}
			if (page == 1 && (quests[6].display || quests[7].display || quests[8].display)) {
				if (GUI.Button (new Rect(275, (Screen.height / 4) + 20, 20, 20), ">", buttonStyle)) {
					page += 1;
				}
			}
			if (page == 2 && (quests[9].display || quests[10].display || quests[11].display)) {
				if (GUI.Button (new Rect(275, (Screen.height / 4) + 20, 20, 20), ">", buttonStyle)) {
					page += 1;
				}
			}
			if (page == 3 && quests[12].display) {
				if (GUI.Button (new Rect(275, (Screen.height / 4) + 20, 20, 20), ">", buttonStyle)) {
					page += 1;
				}
			}
			if (page >= 1) {
				if (GUI.Button (new Rect(25, (Screen.height / 4) + 20, 20, 20), "<", buttonStyle)) {
					page -= 1;
				}
			}
			if (page == 0) {
				if (quests[0].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 70, 270, 100), quests [1].name + " - " + questCheck(quests [0].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 70, 280, 25), quests [0].name + " - " + questCheck(quests [0].completed), qlist)) {
						showinfo = true;
						questimage = mayorgran;
						qinfo = "Talk to Mayor Gran Ite, leader of the planet you have just crashed landed on. He will surely want to talk to you and will probably need your help.";
					}
				}
				if (!quests[0].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxBStyle);
				}
				if (quests[1].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 40, 270, 100), quests [1].name + " - " + questCheck(quests [1].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 40, 280, 25), quests [1].name + " - " + questCheck(quests [1].completed), qlist)) {
						showinfo = true;
						questimage = ruby;
						qinfo = "Mayor Gran wants you to speak to his daughter, Ruby, about the destruction of the town. She usually hangs out near the center of the town.";
					}
				}
				if (!quests[1].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxBStyle);
				}
				if (quests[2].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 10, 270, 100), quests [2].name + " - " + questCheck(quests [2].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 10, 280, 25), quests [2].name + " - " + questCheck(quests [2].completed), qlist)) {
						showinfo = true;
						questimage = ruby;
						qinfo = "Ruby wants you to check on the rest of the town and talk to all everyone to make sure that they are okay.";
					}
				}
				if (!quests[2].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
				}
				//***Insert Quest 2 here
				//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
			}
			if (page == 1) {
				if (quests[3].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 70, 270, 100), quests [3].name + " - " + questCheck(quests [3].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 70, 280, 25), quests [3].name + " - " + questCheck(quests [3].completed), qlist)) {
						showinfo = true;
						questimage = burnadine;
						qinfo = "Burnadine usually hangs around with Morry near their mushroom houses on the east side of town.";
					}
				}
				if (!quests[3].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxBStyle);
				}
				if (quests[4].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 40, 270, 100), quests [4].name + " - " + questCheck(quests [4].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 40, 280, 25), quests [4].name + " - " + questCheck(quests [4].completed), qlist)) {
						showinfo = true;
						questimage = drcyabine;
						qinfo = "Dr. Cyabine is often spotted near his observatory towards the north of the town.";
					}
				}
				if (!quests[4].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxBStyle);
				}
				if (quests[5].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 10, 270, 100), quests [5].name + " - " + questCheck(quests [5].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 10, 280, 25), quests [5].name + " - " + questCheck(quests [5].completed), qlist)) {
						showinfo = true;
						questimage = hatperson;
						qinfo = "Hat Person can be spotted towards the center of town near Ruby, often trying to get people to go to his store and buy hats.";
					}
				}
				if (!quests[5].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
				}
				//***Insert Quest 2 here
				//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
			}
			if (page == 2) {
				if (quests[6].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 70, 270, 100), quests [6].name + " - " + questCheck(quests [6].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 70, 280, 25), quests [6].name + " - " + questCheck(quests [6].completed), qlist)) {
						showinfo = true;
						questimage = ika;
						qinfo = "Ika works at his ramen shop towards the south end of the town on the beach.";
					}
				}
				if (!quests[6].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxBStyle);
				}
				if (quests[7].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 40, 270, 100), quests [7].name + " - " + questCheck(quests [7].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 40, 280, 25), quests [7].name + " - " + questCheck(quests [7].completed), qlist)) {
						showinfo = true;
						questimage = khet;
						qinfo = "Khet can be found near Ika on the beach towards the south end of the town.";
					}
				}
				if (!quests[7].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxBStyle);
				}
				if (quests[8].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 10, 270, 100), quests [8].name + " - " + questCheck(quests [8].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 10, 280, 25), quests [8].name + " - " + questCheck(quests [8].completed), qlist)) {
						showinfo = true;
						questimage = morry;
						qinfo = "Morry usually hangs out in the mushroom field near Burnadine towards the east side of the town.";
					}
				}
				if (!quests[8].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
				}
				//***Insert Quest 2 here
				//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
			}
			if (page == 3) {
				if (quests[9].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 70, 270, 100), quests [9].name + " - " + questCheck(quests [9].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 70, 280, 25), quests [9].name + " - " + questCheck(quests [9].completed), qlist)) {
						showinfo = true;
						questimage = sally;
						qinfo = "Sally hangs around the Fish Hut towards the south end of the town near the beach.";
					}
				}
				if (!quests[9].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxBStyle);
				}
				if (quests[10].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 40, 270, 100), quests [10].name + " - " + questCheck(quests [10].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 40, 280, 25), quests [10].name + " - " + questCheck(quests [10].completed), qlist)) {
						showinfo = true;
						questimage = trox;
						qinfo = "Trox is often located towards the western end of the town, usually close to the beach.";
					}
				}
				if (!quests[10].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxBStyle);
				}
				if (quests[11].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 10, 270, 100), quests [11].name + " - " + questCheck(quests [11].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 10, 280, 25), quests [11].name + " - " + questCheck(quests [11].completed), qlist)) {
						showinfo = true;
						questimage = wallacepost;
						qinfo = "Trox wants you to find his missing Wallace Poster. According to him, it was blown away towards the Observatory.";
					}
				}
				if (!quests[11].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
				}
				//***Insert Quest 2 here
				//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
			}
			if (page == 4) {
				if (quests[12].display) {
					//GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxStyle);
					//GUI.Label (new Rect (15, (Screen.height / 4) - 70, 270, 100), quests [12].name + " - " + questCheck(quests [12].completed), qlist);
					if (GUI.Button (new Rect (20, (Screen.height / 4) - 70, 280, 25), quests [12].name + " - " + questCheck(quests [12].completed), qlist)) {
						showinfo = true;
						questimage = fossil;
						qinfo = "Dr. Cyabin needs you to find a fossil for his research. Rumor has it that it is near the southeast end of the town.";
					}
				}
				if (!quests[12].display) {
					GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxBStyle);
				//***Insert Quest 2 here
				//GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
				}
				GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxBStyle);
				GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
			}
			//***Insert other quest pages here
			if (page > 4) {
				GUI.Box (new Rect (20, (Screen.height / 4) - 70, 280, 25), "", qboxBStyle);
				GUI.Box (new Rect (20, (Screen.height / 4) - 40, 280, 25), "", qboxBStyle);
				GUI.Box (new Rect (20, (Screen.height / 4) - 10, 280, 25), "", qboxBStyle);
			}
			//if (GUI.Button (new Rect (10, (Screen.height / 4), 200, 20), "Close")) {
			//	notebook = !notebook;
			//}
			if (showinfo) {
				GUI.Box(new Rect(50, (Screen.height / 4) - 70, 600, 430), "", noteStyle);
				GUI.Box (new Rect (70, (Screen.height / 4), 560, 300), "", qboxStyle);
				GUI.Box (new Rect (315, (Screen.height / 4) + 160, 100, 100), questimage, fontStyle);
				GUI.Label(new Rect (70, (Screen.height / 4) + 30, 540, 300), qinfo, fontStyle);
				if (GUI.Button (new Rect (325, (Screen.height / 4) + 310, 60, 100), "Close", qlist)) {
					showinfo = false;
					qinfo = "";
				}
			}
		}
	}

}
