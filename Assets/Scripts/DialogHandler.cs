using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogHandler : MonoBehaviour {

	public static DialogHandler Instance { get; private set; }
	static Image[] DialogUI;

	public static NPCDialogue[] NPCDialogues;

	// Use this for initialization
	void Start () {

		if (Instance != null)
		{
			Debug.LogError("More than one Dialog Handler in scene!");
			return;
		}
		Instance = this;

		DialogUI = gameObject.GetComponentsInChildren<Image>();

		NPCDialogues = FindObjectsOfType(typeof(NPCDialogue)) as NPCDialogue[];

		ToggleUI(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleUI(bool state){
		foreach (Image i in DialogUI){
			i.enabled = state;
		}
	}

	public void NextButtonDown(){
		foreach (NPCDialogue n in NPCDialogues){
			n.SendMessage("nextPage");
		}
	}
}
