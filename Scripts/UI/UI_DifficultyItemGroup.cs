using UnityEngine;
using System.Collections;

public class UI_DifficultyItemGroup : MonoBehaviour {

	public static UI_DifficultyItemGroup instance;
	
	public UI_DifficultyItem[] settingItems;
	
	public DifficultyType curDiffType;

	public Color disableColor;
	public Color enableColor;

	void Awake()
	{
		instance = this;
		curDiffType = (DifficultyType)(PersistentData.instance.CurDiff());
		RefreshDiff (curDiffType);
	}

	public void RefreshDiff(DifficultyType type)
	{
		curDiffType = type;
		foreach (UI_DifficultyItem item in settingItems) {
			if(item.diffType == curDiffType)
				item.Yes();
			else 
				item.No();
		}
		int curDiffInt = (int)curDiffType;
		if (curDiffInt != PersistentData.instance.CurDiff ()) {
			PersistentData.instance.StoreDiff(curDiffInt);
			Clock.instance.ClockStop();
			Clock.instance.Clear();
			UI_DiffAndMineShower.instance.Refresh();
		}
	}

	public UI_DifficultyItem CurDiffItem()
	{
		return settingItems[(int) curDiffType];
	}

}
