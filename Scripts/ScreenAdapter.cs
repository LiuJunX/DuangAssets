using UnityEngine;
using System.Collections;

public class ScreenAdapter : MonoBehaviour {

	public static ScreenAdapter instance;

	public float screenRatio;
	public float screenRatioReverse;
	public float screenWidthUnit;
	public float screenHeightUnit;
	public float screenWidthUnitHalf;
	public float screenHeightUnitHalf;


	void Awake()
	{
		instance = this;
		screenRatio = ((float) Screen.height) / Screen.width;
		screenRatioReverse = ((float) Screen.width) / Screen.height;
		screenHeightUnit = 2 * Camera.main.orthographicSize;
		screenWidthUnit = screenHeightUnit * screenRatioReverse;
		screenWidthUnitHalf = screenWidthUnit * 0.5f;
		screenHeightUnitHalf = screenHeightUnit * 0.5f;
	}



}
