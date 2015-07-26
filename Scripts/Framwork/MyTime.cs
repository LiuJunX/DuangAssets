using UnityEngine;
using System.Collections;

public class MyTime
{
	public static MyTime GlobalTimer = new MyTime ();

	public float realtimeSinceStartup
	{
		get
		{
			if (paused)
				return pauseTimePoint - pausedTime;
			else
				return Time.realtimeSinceStartup - pausedTime;
		}
	}
	float pauseTimePoint;
	float pausedTime;
	bool paused = false;
	public void Pause()
	{
		paused = true;
		pauseTimePoint = Time.realtimeSinceStartup;
	}
	public void Start()
	{
		paused = false;
		pausedTime += Time.realtimeSinceStartup - pauseTimePoint;
	}
}