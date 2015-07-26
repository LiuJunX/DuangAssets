using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Record : MonoBehaviour {

	public Text text;

	void Awake(){
		if (text == null)
			text = GetComponent<Text> ();

		NewRecord (PersistentData.instance.Record ());

		PersistentData.instance.newRecord = NewRecord;
	}

	void NewRecord(int newScore)
	{
		if (newScore == -1) {
			text.text = "记录：无记录";
		} else {
			text.text = "记录：" + newScore;
		}
	}

}
