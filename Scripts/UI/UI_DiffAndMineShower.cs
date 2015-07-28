using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_DiffAndMineShower : MonoBehaviour {

	public static UI_DiffAndMineShower instance;

	public Text diffText;
	public Text minText;
	public Text flagText;

	void Awake()
	{
		instance = this;
		RefreshFlagNum (0);
		Refresh ();
	}

	public void Refresh()
	{
		switch ((DifficultyType)PersistentData.instance.CurDiff()) {
		case DifficultyType.Easy:
			diffText.text = "初级";
			break;
		case DifficultyType.Normal:
			diffText.text = "中级";
			break;
		case DifficultyType.Hard:
			diffText.text = "高级";
			break;
		}
		minText.text = ConfigData.GetCurMineNum ((DifficultyType)PersistentData.instance.CurDiff()).ToString();
	}

	public void RefreshFlagNum(int num)
	{
		this.flagText.text = num.ToString ();
	}

}
