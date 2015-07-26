using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GridBg : UniformGrid<GridBgItem>
{

	public static GridBg instance;

	int mouseRow; 
	int mouseCol;
	bool isGameOver;
	bool paused = false;
	Vector2 mousePosWorld;
	bool isTouchWork = true;
	GridBgItem[] mines;

	public int mineNum = 0;
	public SpriteRenderer outlineStencil;
	public MyInput myInput = new MyInput();

	public float topPixels;
	public float buttomPixels;
	public float topPercentage;
	public float buttomPercentage;

	protected override void Awake ()
	{
		instance = this;
		if (ScreenAdapter.instance.screenRatio > 1.7f) {				//iphone5, 5s, 6, 6p, new touch
			rCount = ConfigData.ITEMS_RON_NUM_177;
			cCount = ConfigData.ITEMS_COL_NUM_177;
		} else if (ScreenAdapter.instance.screenRatio > 1.45f) {		//iphone4, 4s, old touch
			rCount = ConfigData.ITEMS_ROW_NUM_150;
			cCount = ConfigData.ITEMS_COL_NUM_150;
		} else if (ScreenAdapter.instance.screenRatio > 1.3f) {			//ipad
			rCount = ConfigData.ITEMS_ROW_NUM_150;
			cCount = ConfigData.ITEMS_COL_NUM_133;
		} else {
			Debug.LogError("ERROR!");
			return;
		}


		gridItemW = gridItemH = (ScreenAdapter.instance.screenWidthUnit - 0.1f) / cCount;
		base.Awake ();
		showedNums = 0;
		isGameOver = false;
		outlineStencil.transform.localPosition = new Vector3 (this.center.x, this.center.y, 0);
		outlineStencil.transform.localScale = new Vector3 (this.width, this.height, 1);
		outlineStencil.gameObject.SetActive (true);
		mineNum = ConfigData.GetCurMineNum((DifficultyType)PersistentData.instance.CurDiff());
		int[] mineIndexes = MyUtility.RandNumsWithoutRepetitionRange (0, buffer.Length, mineNum);
		mines = new GridBgItem[mineIndexes.Length];
		for (int i = 0; i < mineIndexes.Length; ++i) {
			mines[i] = buffer[mineIndexes[i] / cCount, mineIndexes[i] % cCount];
			mines[i].isMine = true;
		}

		topPercentage = (ScreenAdapter.instance.screenHeightUnitHalf - this.topEdge) / Camera.main.orthographicSize * 0.5f;
		buttomPercentage = (ScreenAdapter.instance.screenHeightUnitHalf + this.bottomEdge) / Camera.main.orthographicSize * 0.5f;

		topPixels = topPercentage * Screen.height;
		buttomPixels = buttomPercentage * Screen.height;

	}

    void Update()
    {
		if (paused) 
			return;
		if (isGameOver)
			return;
		myInput.Update ();
		mousePosWorld = myInput.lastMessage.pos;
		if (myInput.lastMessage.touchType == MyInput.TouchType.Down) {
			mouseRow = (int)((mousePosWorld.y - bottomEdge) / gridItemH);
			mouseCol = (int)((mousePosWorld.x - leftEdge) / gridItemW);
			if (mouseRow < 0 || mouseRow >= rCount || mouseCol < 0 || mouseCol >= cCount)
				isTouchWork = false;
			else 
				isTouchWork = true;
		} 
		if (isTouchWork) {
			if(myInput.lastMessage.touchType == MyInput.TouchType.Up)
			{
				int releaseMouseRow = (int)((mousePosWorld.y - bottomEdge) / gridItemH);
				int releaseMouseCol = (int)((mousePosWorld.x - leftEdge) / gridItemW);
				if(releaseMouseRow == mouseRow && releaseMouseCol == mouseCol)
				{
					Click();
				}
			} else if(myInput.lastMessage.touchType == MyInput.TouchType.Moving)
			{
				int releaseMouseRow = (int)((mousePosWorld.y - bottomEdge) / gridItemH);
				int releaseMouseCol = (int)((mousePosWorld.x - leftEdge) / gridItemW);
				if(releaseMouseRow == mouseRow && releaseMouseCol == mouseCol)
				{
					if(myInput.lastMessage.time - myInput.downMessage.time >= MyInput.LONG_TOUCH_TIME)
						Flag();
				} else {
					Flag();
				}
			}
		}

	}
	public int showedNums = 0;
	void Click()
	{
		if (showedNums == 0) {
			GameManager.instance.SetState(GameManager.State.Playing);
			Clock.instance.ClockStart ();
		}
		isTouchWork = false;
		buffer [mouseRow, mouseCol].Show (true);
		if (! isGameOver) {
			Debug.Log("showedNums:" + showedNums);
			Debug.Log("buffer.Length - mineNum:" + (buffer.Length - mineNum));
			if(showedNums == buffer.Length - mineNum)
			{
				isGameOver = true;
				Clock.instance.ClockStop();
				PersistentData.instance.NewScore(Clock.instance.secends);
				Debug.LogWarning("GAME WIN!!!");
				Lady.instance.ggText.ShowDefault("恭喜你取得胜利。快点击时间，挑战新的速度极限吧。");
			}
		}
	}

	void Flag()
	{
		buffer [mouseRow, mouseCol].Flag ();
		isTouchWork = false;
	}

	public void ResetState()
	{
		Clock.instance.Clear ();
		paused = false;
		isGameOver = false;
		showedNums = 0;
		mineNum = ConfigData.GetCurMineNum((DifficultyType)PersistentData.instance.CurDiff());
		int[] mineIndexes = MyUtility.RandNumsWithoutRepetitionRange (0, buffer.Length, mineNum);

		for(int i = 0; i < rCount; ++i)
		{
			for(int j = 0; j < cCount; ++j)
			{
				buffer[i, j].ResetState();
			}
		}
		mines = new GridBgItem[mineIndexes.Length];
		for (int i = 0; i < mineIndexes.Length; ++i) {
			mines[i] = buffer[mineIndexes[i] / cCount, mineIndexes[i] % cCount];
			mines[i].isMine = true;
		}
		Lady.instance.ggText.ShowDefault ("长按标记为雷；再次长按，取消标记。");
	}


	public void ShowAllMines()
	{
		isGameOver = true;
		Clock.instance.ClockStop ();
		if ((buffer [mouseRow, mouseCol] as GridBgItem).isMine) {
			for(int i = 0; i < mines.Length; ++i)
			{
				mines[i].Show();
			}
		}
		Lady.instance.ggText.ShowDefault ("你触雷了！！！点击时间再次挑战吧");	
	}

	public void Pause()
	{
		paused = true;
		MyTime.GlobalTimer.Pause ();
	}

	public void Resume()
	{
		paused = false;
		MyTime.GlobalTimer.Start ();
	}



}
