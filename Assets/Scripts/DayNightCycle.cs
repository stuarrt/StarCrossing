using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

	public Light sun;
	public float seconds = 60f;
	public float currentTime = 0;
	public float timeMultiplier = 1f;
	public GUIStyle timeStyle;

	private int days;

	float sunIntensity;

	// Use this for initialization
	void Start () {
		sunIntensity = sun.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		changeSun ();
		currentTime += (Time.deltaTime / seconds) * timeMultiplier;

		if (currentTime >= 1) {
			currentTime = 0;
			days += 1;
		}
	}

	void changeSun() {
		sun.transform.localRotation = Quaternion.Euler ((currentTime * 360f) - 90, 170, 0);

		float intmult = 1;
		if (currentTime <= 0.23f || currentTime >= 0.75f) {
			intmult = 0;
		} else if (currentTime <= 0.25f) { 
			intmult = Mathf.Clamp01 ((currentTime - 0.23f) * (1 / 0.02f));
		} else if (currentTime >= 0.73f) {
			intmult = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
		}

		sun.intensity = sunIntensity * intmult;
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 200, 50), "Days: " + days, timeStyle);
	}
}
