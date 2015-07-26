using UnityEngine;
using System.Collections;

public class UI_Setting : MonoBehaviour {

	public static UI_Setting instance;

	public bool isShowing = false;
	State state;
	public Animator entryButtonAni;	

	public void Show()
	{
		Debug.Log ("show setting");
		isShowing = true;
		gameObject.SetActive (true);
		GameManager.instance.SetState(GameManager.State.Setting);
	}

	public void Close()
	{
		Debug.Log ("close setting");
		isShowing = false;
		gameObject.SetActive (false);
		GridBg.instance.ResetState ();
		GameManager.instance.SetStateToPreState ();
	}

	public void SetState(State s)
	{
		this.state = s;
		switch (state) {
		case State.Entering:
			Show();
			break;
		case State.Stay:
			break;
		case State.Exiting:
			Close();
			break;
		}
	}

	public enum State
	{
		Entering,
		Stay,
		Exiting
	}

}
