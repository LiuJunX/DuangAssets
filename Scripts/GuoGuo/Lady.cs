using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lady : MonoBehaviour {

	public static Lady instance;

	public GuoGuoText ggText;

	void Awake()
	{
		instance = this;
	}

}
