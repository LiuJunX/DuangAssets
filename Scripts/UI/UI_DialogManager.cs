using UnityEngine;
using System.Collections;

public class UI_DialogManager : MonoBehaviour {

	public static UI_DialogManager instance;

	public GameObject grayBg;
	public GameObject centerContent;

	public GameObject objWin;
	public GameObject objLose;
	public GameObject objNewRecord;

	void Awake()
	{
		instance = this;
		if (grayBg.activeSelf)
			grayBg.SetActive (false);
		if (centerContent.activeSelf)
			centerContent.SetActive (false);
	}

	public void Close()
	{
		if (objWin.activeSelf)
			objWin.SetActive (false);
		if (objLose.activeSelf)
			objLose.SetActive (false);
		if (objNewRecord.activeSelf)
			objNewRecord.SetActive (false);
	}


}
