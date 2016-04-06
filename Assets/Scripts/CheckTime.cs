using UnityEngine;
using System.Collections;
using System;

public class CheckTime : MonoBehaviour {

	public static CheckTime Instance { get; private set; }

	//Current Time
	DateTime curr;

	//Last time played
	DateTime old;

	//Days since last played
	string days;

	//Hours since last played
	string hours;

	//Minutes since last played
	string minutes;

	//Seconds since last played
	string seconds;

	//Total Days played
	int totalDays;

	//Total Hours played
	int totalHours;

	//Total Minutes Played
	int totalMinutes;

	//Total Seconds Played
	int totalSeconds;


	public GUIStyle timeStyle;
	
	// Use this for initialization
	void Start () {

		curr = System.DateTime.Now;

		long temp = Convert.ToInt64 (PlayerPrefs.GetString ("LastTime"));

		Instance = this;

		DateTime old = DateTime.FromBinary (temp);
		print("oldDate: " + old);

		TimeSpan timediff = curr.Subtract (old);
		PlayerPrefs.SetString ("TimeDiffDays", timediff.Days.ToString());
		PlayerPrefs.SetString ("TimeDiffHours", timediff.Hours.ToString());
		PlayerPrefs.SetString ("TimeDiffMinutes", timediff.Minutes.ToString());
		PlayerPrefs.SetString ("TimeDiffSeconds", timediff.Seconds.ToString());
		totalDays = PlayerPrefs.GetInt ("TotalDays") + timediff.Days;
		totalHours = PlayerPrefs.GetInt ("TotalHours") + timediff.Hours;
		totalMinutes = PlayerPrefs.GetInt ("TotalMinutes") + timediff.Minutes;
		totalSeconds = PlayerPrefs.GetInt ("TotalSeconds") + timediff.Seconds;
		//Converts 60+ seconds into minutes
		if (totalSeconds >= 60) {
			totalMinutes += 1;
			totalSeconds -= 60;
		}
		//Converts 60+ minutes into hours
		if (totalMinutes >= 60) {
			totalHours += 1;
			totalMinutes -= 60;
		}
		//Converts 24+ hours into days
		if (totalHours >= 24) {
			totalDays += 1;
			totalHours -= 24;
			CallChangeDay ();
		}
		days = PlayerPrefs.GetString ("TimeDiffDays");
		hours = PlayerPrefs.GetString ("TimeDiffHours");
		minutes = PlayerPrefs.GetString ("TimeDiffMinutes");
		seconds = PlayerPrefs.GetString ("TimeDiffSeconds");
		print("Difference: " + timediff);

		CallChangeDay ();
	}
	
	// Update is called once per frame
	void OnApplicationQuit() {

		PlayerPrefs.SetString("LastTime", System.DateTime.Now.ToBinary().ToString());
		PlayerPrefs.SetInt ("TotalDays", totalDays);
		PlayerPrefs.SetInt ("TotalHours", totalHours);
		PlayerPrefs.SetInt ("TotalMinutes", totalMinutes);
		PlayerPrefs.SetInt ("TotalSeconds", totalSeconds);
		PlayerPrefs.Save ();
		print("Saving this date to prefs: " + System.DateTime.Now);

	}

	void Update() {
		curr = System.DateTime.Now;
	}

	void CallChangeDay(){
	//	DayNightCycle.Instance.SendMessage ("ChangeNPCDay", totalDays, SendMessageOptions.RequireReceiver);
	}

	void OnGUI() {
		//GUI.Label (new Rect (10, 10, 200, 50), "Days: " + totalDays, timeStyle);
		//GUI.Label (new Rect (Screen.width / 2, 50, 200, 50), "Days: " + days + " Hours: " + hours + " Minutes: " + minutes + " Seconds: " + seconds, timeStyle);
		//GUI.Label (new Rect (Screen.width / 2, 25, 200, 50), "Time: " + curr, timeStyle);
		//GUI.Label (new Rect (Screen.width / 2, 75, 200, 50), "Time Since Start*** Days: " + totalDays + " Hours: " + totalHours + " Minutes: " + totalMinutes + " Seconds: " + totalSeconds, timeStyle);
	}
}
