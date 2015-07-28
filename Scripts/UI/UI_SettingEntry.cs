using UnityEngine;
using System.Collections;

public class UI_SettingEntry : MonoBehaviour {

	Animator ani;

	public UI_Setting uiSetting;

	void Awake()
	{
		ani = GetComponentInChildren<Animator> ();
	}

	public void ClickSettingEntry()
	{
		uiSetting.ClickSettingEntry ();
	}

}
