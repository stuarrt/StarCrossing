using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

	public static DayNightCycle Instance { get; private set; }

	public enum TimeOfDay
	{
		Dawn, 
		Noon, 
		Dusk, 
		Midnight,
	}

	public TimeOfDay dayState;
	public Light sun;
	public float seconds = 900f;
	public float currentTime = 0;
	public float timeMultiplier = 1f;
	public GUIStyle timeStyle;

	public int days;

	float sunIntensity;

	// Use this for initialization
	void Start () {
		if (Instance != null)
		{
			Debug.LogError("More than one DayNightCycle in scene!");
			return;
		}
		Instance = this;

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
		//TODO: Separating the (currentTime <= 0.23f || currentTime >= 0.75f) case 
		//into two cases so that we can have four time states: Dawn/Noon/Dusk/Midnight.
		if (currentTime <= 0.23f) {
			dayState = TimeOfDay.Dawn;
			intmult = 0;
		}else if (currentTime <= 0.25f) { 
			dayState = TimeOfDay.Noon;
			intmult = Mathf.Clamp01 ((currentTime - 0.23f) * (1 / 0.02f));
		} else if (currentTime >= 0.73f) {
			dayState = TimeOfDay.Dusk;
			intmult = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
		} else if (currentTime >= 0.75f) {
			dayState = TimeOfDay.Midnight;
			intmult = 0;
		}

		sun.intensity = sunIntensity * intmult;
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 200, 50), "Days: " + days, timeStyle);
	}
}
