using UnityEngine;
using System.Collections;

public class SpriteNumber : MonoBehaviour {

	public GameObject mine;
	public GameObject duang;
	//The last one is mine
	public Sprite[] sprites = new Sprite[11];
	public int number = 0;

	SpriteRenderer sprite;

	// Use this for initialization
	void Awake () {
		sprite = GetComponentInChildren<SpriteRenderer> ();
		mine.SetActive (false);
		duang.SetActive (false);
	}

	public void SetNumber(int number)
	{
		this.number = number;
		if(number != 0)
			this.sprite.sprite = sprites [number];
		this.sprite.color = Color.white;
	}

	public void SetMine(bool isClickSet = false)
	{
		this.number = 10;
		this.sprite.sprite = null;
		mine.SetActive (true);
		if (isClickSet)
			duang.SetActive (true);
	}

	public void Hide()
	{
		this.number = -1;
		this.sprite.sprite = null;
		mine.SetActive (false);
		duang.SetActive (false);
	}
	
}
