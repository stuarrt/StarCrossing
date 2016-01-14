using UnityEngine;
using System.Collections;

public class MakeGhost : MonoBehaviour {

	public DayNightCycle dnc;

	// Update is called once per frame
	void Update () {

	//	print (dnc.currentTime);

		if (dnc.currentTime < 0.28f || dnc.currentTime > 0.74f) {
			this.gameObject.GetComponent<Renderer>().enabled = true;
			this.gameObject.GetComponent<BoxCollider>().enabled = true;
		}
		else {
			this.gameObject.GetComponent<Renderer>().enabled = false;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;

		}
	}
}
