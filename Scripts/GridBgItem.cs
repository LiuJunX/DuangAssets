using UnityEngine;
using System.Collections;

public class GridBgItem : GridItem<GridBgItem> {

	bool isFlaged = false;
	GridBgItem[] aroundItems;

	public bool hasShowed = false;
	public SpriteNumber number;
	public bool isMine = false;
	public Color initColor = Color.black;
	public Color showColor = Color.gray;
	public GameObject flag;

	GridBgItem leftUp
	{
		get{
			if (left && up)
				return left.up as GridBgItem;
			return null;
		}
	}
	GridBgItem leftDown
	{
		get{
			if(left && down)
				return left.down as GridBgItem;
			return null;
		}
	}
	GridBgItem rightUp
	{
		get{
			if (right && up)
				return right.up as GridBgItem;
			return null;
		}
	}
	GridBgItem rightDown
	{
		get{
			if (right && down)
				return right.down as GridBgItem;
			return null;
		}
	}

	public override void Init()
	{
		base.Init ();
		isMine = false;
		hasShowed = false;
		isFlaged = false;
		flag.SetActive (isFlaged);
		this.GetComponent<SpriteRenderer> ().color = initColor;
	}


	public void Show(bool isClickShow = false)
	{
		if (hasShowed) {
			if(! isClickShow || isMine || number.number == 0)
				return;

			int flagNum = 0;
			//int notShowedNum = 0;
			foreach(GridBgItem i in aroundItems)
			{
				if(! i)
					continue;
				if(i.isFlaged)
					flagNum++;
				//if(! i.hasShowed)
					//notShowedNum ++;
			}
			if(flagNum == number.number)
			{
				foreach(GridBgItem i in aroundItems)
				{
					if(i && ! i.isFlaged && ! i.hasShowed)
					{
						i.Show();
					}
				}
			} else {
				Lady.instance.ggText.ShowDefault("该位置显示的雷的数量与周围扫出的与标记的雷的数量和不一致！");
			}
			return;
		}

		(this.grid as GridBg).showedNums ++;
		hasShowed = true;
		
		if(this.isFlaged)
		{
			GridBg.instance.flagNum --;
			isFlaged = false;
			flag.SetActive(isFlaged);
		}

		if (isMine) {
			this.GetComponent<SpriteRenderer> ().color = this.showColor	;
			number.SetMine (isClickShow);
			if(isClickShow)
				(grid as GridBg).ShowAllMines();
		} else {

			GetComponent<SpriteRenderer>().color = showColor;

			int showNum = 0;

			aroundItems = new GridBgItem[8];
			aroundItems[0] = left;
			aroundItems[1] = up;
			aroundItems[2] = right;
			aroundItems[3] = down;
			aroundItems[4] = leftUp;
			aroundItems[5] = leftDown;
			aroundItems[6] = rightUp;
			aroundItems[7] = rightDown;

			foreach(GridBgItem item in aroundItems)
			{
				if(item && item.isMine)
					++showNum;
			}

			number.SetNumber(showNum);
			if(showNum == 0)
			{
				foreach(GridBgItem item in aroundItems)
				{
					if(item)
						item.Show();
				}
			}

		}
	}

	public void Flag()
	{
		if (hasShowed)
			return;
		isFlaged = ! isFlaged;
		flag.SetActive (isFlaged);
		if (isFlaged)
			GridBg.instance.flagNum ++;
		else 
			GridBg.instance.flagNum --;
	}

	public override void ResetState()
	{
		base.ResetState();
		this.Init ();
		number.Hide ();
	}

}
