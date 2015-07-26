using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_DifficultyItem : MonoBehaviour {

	public static DifficultyType curDifficulty;

	public DifficultyType diffType;

	public const int ALL_GRIDS_NUM = 140;

	public void Yes(){
		GetComponent<Button> ().interactable = false;
		GetComponent<Image> ().color = UI_DifficultyItemGroup.instance.disableColor;
	}

	public void No()
	{
		GetComponent<Button> ().interactable = true;
		GetComponent<Image> ().color = UI_DifficultyItemGroup.instance.enableColor;
	}

	public void Click()
	{
		UI_DifficultyItemGroup.instance.RefreshDiff (this.diffType);
		Lady.instance.ggText.ShowDefault ("难度设置将在全新的一局中应用");
	}

}

public enum DifficultyType{
	Easy,
	Normal,
	Hard
}
