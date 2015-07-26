using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

public class PersistentData : MonoBehaviour {

	public static PersistentData instance;

	public const string PREFS_record = "PREFS_PersistentData_score";
	public const string PREFS_curDiff = "PREFS_PersistentData_curDiff";

	int record = -1;
	int curDiff = 0;

	public bool deleteAll = true;

	public System.Action<int> newRecord;

	void Awake()
	{
		if (deleteAll)
			PlayerPrefs.DeleteAll ();
		instance = this;
		if (PlayerPrefs.HasKey (PREFS_record)) {
			record = PlayerPrefs.GetInt (PREFS_record);
		} else {
			PlayerPrefs.SetInt(PREFS_record, record);
		}
		if (PlayerPrefs.HasKey (PREFS_record)) {
			record = PlayerPrefs.GetInt (PREFS_record);
		} else {
			PlayerPrefs.SetInt(PREFS_record, record);
		}
	}

	public int Record()
	{
		return record;
	}

	public int CurDiff()
	{
		return curDiff;
	}

	public bool NewScore(int newScore)
	{
		if (record == -1 || newScore < record) {
			this.record = newScore;
			PlayerPrefs.SetInt(PREFS_record, record);
			if(newRecord != null)
				newRecord(record);
			if(Social.localUser.authenticated)
			{
				Social.ReportScore(record, "LeaderboardID", GameCenterManager.instance.ReportScoreCallBack);
			} else {
				Debug.Log("local user is not authenticated");
			}
			return true;
		}	
		return false;
	}

	public void StoreDiff(int diff)
	{
		if (curDiff == diff)
			return;

		curDiff = diff;
		PlayerPrefs.GetInt (PREFS_curDiff, curDiff);
	}
	

}
