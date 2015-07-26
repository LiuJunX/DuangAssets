using UnityEngine;
using System.Collections;

public class UI_ItemScreenAdapter : MonoBehaviour {

	public RectTransform trans;
	public AdaptType type;

	void Awake()
	{
		if (trans == null)
			trans = GetComponent<RectTransform> ();

		switch (type) {
		case AdaptType.Lady:
			trans.anchorMax = new Vector2(trans.anchorMax.x, GridBg.instance.buttomPercentage);
			break;
		case AdaptType.TopGroup:
			trans.anchorMin = new Vector2(trans.anchorMin.x, 1 - GridBg.instance.topPercentage);
			break;
		case AdaptType.Setting:
			trans.anchorMax = new Vector2(trans.anchorMax.x, 1 - GridBg.instance.topPercentage);
			trans.anchorMin = new Vector2(trans.anchorMin.x, GridBg.instance.buttomPercentage);
			break;
		}
	}

	public enum AdaptType{
		Lady,
		TopGroup,
		Setting
	}

}
