using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UniformGrid<T> : Grid<T>
    where T : GridItem<T>
{
	//该grid的位置与anchor所定义的位置重合
	public GridAnchor anchor;

	public float gridItemW = 1;
	public float gridItemH = 1;

	Vector3 itemScale;

	public float width
	{
		get
		{
			return gridItemW * cCount;
		}
	}

	public float height
	{
		get
		{
			return gridItemH * rCount;
		}
	}



	protected override void Awake ()
	{
		Vector3 itemLocalScale = gridItemsPrefb.transform.localScale;
		itemScale = new Vector3 (itemLocalScale.x * gridItemW, itemLocalScale.y * gridItemW, itemLocalScale.z);
        leftEdge = transform. position. x - ( anchor. width + 0.5f ) * width;
        bottomEdge = transform. position. y - ( anchor. height + 0.5f ) * height;
        rightEdge = leftEdge + width;
        topEdge = bottomEdge + height;

        left = leftEdge + gridItemW / 2;
        bottom = bottomEdge + gridItemH / 2;
        right = rightEdge - gridItemH / 2;
        top = topEdge - gridItemH / 2;

		center = new Vector2 ((left + right) * 0.5f, (top + bottom) * 0.5f);

		base.Awake ();

	}

    //Edge items center
	public Vector2 center;
	public float left,bottom,right,top;
    public float leftEdge, bottomEdge, rightEdge, topEdge;
	protected override void DoAfterEachItemInit (int indexR,int indexC,T gi)
	{
		base.DoAfterEachItemInit (indexR,indexC,gi);
		gi.transform.position = new Vector2 (left + gridItemW * indexC,bottom + gridItemH * indexR);
		gi.transform.localScale = itemScale;
	}

}
