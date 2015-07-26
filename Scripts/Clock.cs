using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public static Clock instance;
	
	[SerializeField]
	UnityEngine.UI.Text clockText;
	public int secends;
	float startTime;
	float stopTime;
	char[] timeStrBytes = new char[5];

	void Awake()
	{
		instance = this;
		timeStrBytes [2] = ':';
		Clear ();
	}

	public void Clear()
	{
		secends = 0;
		startTime = 0;
		stopTime = 0;
		clockText.text = "00:00";//"--:--";
	}

	public void ClockStart()
	{
		startTime = MyTime.GlobalTimer.realtimeSinceStartup;
		stopTime = -1;
		secends = 0;
		clockText.text = "00:00";
	}

	public void ClockStop()
	{
		Debug.Log ("stop clock");
		stopTime = MyTime.GlobalTimer.realtimeSinceStartup;
		RefreshClockText ();
	}

	void Update()
	{
		if (stopTime != -1)
			return;
		RefreshClockText ();
	}

	void RefreshClockText()
	{
		int deltaTime = (int)(MyTime.GlobalTimer.realtimeSinceStartup - startTime);
		if (deltaTime != this.secends)
		{
			this.secends = deltaTime;
			if(secends >= 3600)
				secends = 3599;
			int minute = secends / 60;
			secends = secends % 60;
			timeStrBytes[0] = ((minute / 10).ToString())[0];
			timeStrBytes[1] = ((minute % 10).ToString())[0];
			timeStrBytes[3] = ((secends / 10).ToString())[0];
			timeStrBytes[4] = ((secends % 10).ToString())[0];
			clockText.text = new string(timeStrBytes);
		}
	}



}