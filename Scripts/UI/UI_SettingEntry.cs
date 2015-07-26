using UnityEngine;
using System.Collections;

public class UI_SettingEntry : MonoBehaviour {

	Animator ani;

	public UI_Setting uiSetting;

	void Awake()
	{
		ani = GetComponentInChildren<Animator> ();
		if (uiSetting.gameObject.activeSelf)
			uiSetting.gameObject.SetActive (false);
	}

	public void ClickSettingEntry()
	{
		if (uiSetting.isShowing) {
			GridBg.instance.Resume();
			uiSetting.Close();
			//ani.SetTrigger (AniEvent.TRIGGER_SETTING_CLOSE);
		} else {
			GridBg.instance.Pause();
			uiSetting.Show();
			//ani.SetTrigger (AniEvent.TRIGGER_SETTING_OPEN);
		}
	}

}
