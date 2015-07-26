using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuoGuoText : GuoGuoTypeP<GuoGuoText.Setting> {

	public Text text;

	public override void Show (Setting setting)
	{
		this.text.text = setting.text;
		this.text.fontSize = setting.fontsize;
		this.text.alignment = setting.anchor;
		gameObject.SetActive (true);
	}

	public void ShowDefault(string text)
	{
		Show (new Setting (text, 25, TextAnchor.UpperLeft));
	}


	public struct Setting{
		public string text;
		public int fontsize;
		public TextAnchor anchor;
		public Setting(string text, int fontsize, TextAnchor anchor)
		{
			this.text = text;
			this.fontsize = fontsize;
			this.anchor = anchor;
		}
	}

}
