using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public int targetFrameRate = 30;
	State statePre = State.Waiting;
	State stateCur = State.Waiting;
	public UnityAction<State> stateChanged;	

	void Awake()
	{
		instance = this;
		Application.targetFrameRate = targetFrameRate;
	}

	//void OnApplicationPause(bool pauseStatus) {
	//	Debug.Log ("pauseStatus:" + pauseStatus);
	//}

	void OnApplicationFocus(bool focusStatus) {
		Debug.Log ("focusStatus:" + focusStatus);
		if (focusStatus) {
			SetStateToPreState();
		}
		else {
			SetState(State.Paused);
		}
	}

	public void SetState(State s)
	{
		if (this.stateCur == s)
			return;
		this.statePre = stateCur;
		this.stateCur = s;
		switch (stateCur) {
		case State.Waiting:
			break;
		case State.Playing:
			break;
		case State.Setting:
			break;
		case State.Paused:
			break;
		case State.GameOver:
			break;
		}
		if (stateChanged != null)
			stateChanged.Invoke (this.stateCur);
	}

	public void SetStateToPreState()
	{
		SetState (statePre);
	}

	public enum State
	{
		Waiting,
		Playing,
		Setting,
		Paused,
		GameOver
	}

}