using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasSizeChanger : MonoBehaviour {

	Canvas canvas;

	public float scaleFactor;

	void Awake()
	{
		canvas = GetComponent<Canvas> ();
		scaleFactor = canvas.scaleFactor;
	}

	void Update()
	{
		canvas.scaleFactor = scaleFactor;
	}

}
