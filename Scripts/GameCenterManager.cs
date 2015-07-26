using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class GameCenterManager : MonoBehaviour {


	public static GameCenterManager instance;
	
	void Awake()
	{
		instance = this;
	}
	
	void Start () {
		Social.localUser.Authenticate (ProcessAuthentication);
	}
	
	public void ShowLeaderboardUI()
	{
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI();
		} else {
			Debug.Log("local user is not authenticated");
		}
	}

	void ProcessAuthentication (bool success) {
		if (success) 
			Debug.Log ("Authenticated");
		else
			Debug.Log ("Failed to authenticate");
	}
			                   	
	public void ReportScoreCallBack(bool success)
	{
		if (success) {
			Debug.Log("report score success");
		} else {
			Debug.Log("report score failed");
		}
	}

}