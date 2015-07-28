using UnityEngine;
using System.Collections;

public class UI_Setting : MonoBehaviour {

	public static UI_Setting instance;

	public State statePre;
	public State state;

	public bool diffChanged = false;
	public Animator entryButtonAni;	
	public float speedDeadZone = 0.1f;

	public float damping;
	public float damping1 = 0.3f;
	public float damping2 = 0.2f;
 	
	public float g;
	public float g1 = 3f;
	public float g2 = 2f;

	public float beginSpeed = 0;
	public float speed = 0f;
	public float beginTime = 0;
	public float passTime = 0;
	public float beginDis = 0;

	//[0,1]
	public float windowHeightPercentage = 0f;


	RectTransform trans;
	float deltaAnchorY;

	void Start()
	{
		trans = GetComponent<RectTransform> ();
		deltaAnchorY = trans.anchorMax.y - trans.anchorMin.y;
		gameObject.SetActive (false);
		trans.anchorMin = new Vector2 (trans.anchorMin.x, trans.anchorMax.y);
	}

	void Update()
	{
		if (state == State.Stay)
			return;

		bool over = false;
		passTime = Time.realtimeSinceStartup - beginTime;
		windowHeightPercentage = beginDis + beginSpeed * passTime + g * passTime * passTime * 0.5f;
		
		if (state == State.Entering) {
			speed = beginSpeed + g * passTime;
			if (windowHeightPercentage >= 0.99f) {
				windowHeightPercentage = 1;
				beginSpeed = - speed * damping;
				speed = beginSpeed;
				beginDis = 1;
				beginTime = Time.realtimeSinceStartup;
				if (Mathf.Abs (speed) < speedDeadZone)
					over = true;
				damping = damping2;
				g = g2;
			}
		} else {
			if (windowHeightPercentage <= 0.01f) {
				windowHeightPercentage = 0;
				over = true;
			}
		}

		trans.anchorMin = new Vector2 (trans.anchorMin.x, trans.anchorMax.y - windowHeightPercentage * deltaAnchorY);
		
		if (over)
			SetState (State.Stay);

	}

	public void SetState(State s)
	{
		if (state == s)
			return;
		this.statePre = state;
		this.state = s;
		switch (state) {
		case State.Entering:
			GridBg.instance.Pause();
			diffChanged = false;
			damping = damping1;
			g = g1;
			gameObject.SetActive (true);
			GameManager.instance.SetState(GameManager.State.Setting);
			damping = 0.2f;
			beginDis = 0;
			g = Mathf.Abs(g);
			beginSpeed = speed = 0;
			beginTime = Time.realtimeSinceStartup;
			break;
		case State.Stay:
			if(statePre == State.Exiting)
			{
				gameObject.SetActive (false);
				if(diffChanged)
					GridBg.instance.ResetState ();
				GridBg.instance.Resume();
				GameManager.instance.SetStateToPreState ();
			}
			break;
		case State.Exiting:
			beginSpeed = speed = 0;
			g = - Mathf.Abs(g);
			beginDis = 1;
			beginTime = Time.realtimeSinceStartup;
			break;
		}
	}

	public void ClickSettingEntry()
	{
		if (state == State.Entering || state == State.Exiting)
			return;
		if (statePre == State.Entering)
			SetState (State.Exiting);
		else {
			SetState (State.Entering);
		}
	}

	public enum State
	{
		Stay,
		Entering,
		Exiting
	}

}
