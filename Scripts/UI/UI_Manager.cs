using UnityEngine;
using System.Collections;

public class UI_Manager : MonoBehaviour {

	public static UI_Manager instance;

	void Awake()
	{
		instance = this;
	}

}
