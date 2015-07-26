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
		Close ();
	}

	public void Close()
	{
		if (centerContent.activeSelf)
			centerContent.SetActive (false);
		if (grayBg.activeSelf)
			grayBg.SetActive (false);
		if (objWin.activeSelf)
			objWin.SetActive (false);
		if (objLose.activeSelf)
			objLose.SetActive (false);
		if (objNewRecord.activeSelf)
			objNewRecord.SetActive (false);
	}

	public void Show(Type type)
	{
		grayBg.SetActive (true);
		centerContent.SetActive (true);
		switch (type) {
		case Type.Loss:
			objLose.SetActive(true);
			break;
		case Type.Win:
			objWin.SetActive(true);
			break;
		case Type.NewRecord:
			objNewRecord.SetActive(true);
			break;
		}
	}

	public enum Type{
		Win,
		Loss,
		NewRecord
	}

}
