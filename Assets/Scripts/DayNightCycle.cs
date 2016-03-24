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
	float sunIntensity;

	public float seconds = 900f;
	public float currentTime = 0;
	public float timeMultiplier = 1f;
	public GUIStyle timeStyle;
	public int days;

	NPC[] NPCs;

	public AudioClip dayMusic;
	public AudioClip nightMusic;
	AudioSource audio; 

	Color skyboxColor;

	// Use this for initialization
	void Awake () {
		if (Instance != null)
		{
			Debug.LogError("More than one DayNightCycle in scene!");
			return;
		}
		Instance = this;

		sunIntensity = sun.intensity;

		NPCs = FindObjectsOfType (typeof(NPC)) as NPC[];
		audio = this.GetComponent<AudioSource> ();
		skyboxColor = new Color (.5f, .5f, .5f);//RenderSettings.skybox.GetColor("_Tint");
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
			if (dayState != TimeOfDay.Dawn) {
				ChangeNPCLocations (0);
				dayState = TimeOfDay.Dawn;
			}
			intmult = 0;
		}else if (currentTime <= 0.25f) { 
			if (dayState != TimeOfDay.Noon) {
				ChangeNPCLocations (1);
				dayState = TimeOfDay.Noon;
				StartCoroutine(FadeAudio (dayMusic));
			}			
			intmult = Mathf.Clamp01 ((currentTime - 0.23f) * (1 / 0.02f));
		} else if (currentTime >= 0.73f) {
			if (dayState != TimeOfDay.Dusk) {
				ChangeNPCLocations (2);
				dayState = TimeOfDay.Dusk;
				StartCoroutine(FadeAudio (nightMusic));
			}			
			intmult = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
		} else if (currentTime >= 0.75f) {
			if (dayState != TimeOfDay.Midnight) {
				ChangeNPCLocations (3);
				dayState = TimeOfDay.Midnight;
			}			
			intmult = 0;
		}
		RenderSettings.skybox.SetColor("_Tint", skyboxColor * intmult);
		sun.intensity = sunIntensity * intmult;
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 200, 50), "Days: " + days, timeStyle);
	}

	void ChangeNPCLocations(int t){
		foreach (NPC n in NPCs){
			n.SendMessage("changeLocation", t, SendMessageOptions.RequireReceiver);
		}
	}

	void ChangeNPCDay(float totalDays){
		foreach (NPC n in NPCs){
			n.SendMessage("changeDay", totalDays, SendMessageOptions.RequireReceiver);
		}
	}

	IEnumerator FadeAudio(AudioClip newClip){
		int i = 10;
		while (i > 0){
			audio.volume = i * .1f;
			yield return new WaitForSeconds (.5f);
			i--;
		}

		audio.clip = newClip;
		audio.Play ();
		while (i < 11) {
			audio.volume = i * .1f;
			yield return new WaitForSeconds (.5f);
			i++;
		}
	}
}
