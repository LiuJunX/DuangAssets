using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 矩阵式宫格
/// </summary>
public class Grid<T> : MonoBehaviour
    where T : GridItem<T>
{

	[HideInInspector]
	public Transform trans;

    public T gridItemsPrefb;


	public int rCount;
	public int cCount;

    public T[,] buffer;

    public T this[int i, int j]
	{
		get { return buffer[i,j]; }
		set { buffer[i,j] = value; }
	}

    public T[] ThisRow(int rowIndex)
    {
        T[] row = new T[cCount];
        for(int i = 0; i < cCount; ++i)
        {
            row[ i ] = buffer[ rowIndex, i ];
		}
        return row;
    }

    public T[] ThisCol(int colIndex)
    {
        T[] col = new T[rCount];
        for(int i = 0; i < rCount; ++i)
        {
            col[ i ] = buffer[ i, colIndex ];
        }
        return col;
    }

	public Grid (int row = 10,int col = 10)
	{
		this.rCount = 0;
		this.cCount = 0;
        buffer = new T[10, 10];
	}

	protected virtual void Awake ()
	{
		trans = transform;
		Init ();
	}

	private void Init ()
	{
        buffer = new T[rCount, cCount];
		for(int i = 0; i < rCount; i ++)
		{
			for(int j = 0; j < cCount; j ++)
			{
                T t = GameObject.Instantiate(gridItemsPrefb) as T;
				t.Init();
				buffer[i,j] = t;
				t.row = i;
				t.col = j;
				t.grid = this;
				t.transform.parent = this.trans;
				t.transform.localScale = Vector3.one;
				DoAfterEachItemInit (i, j, this[i, j]);
			}
		}

	}

    protected virtual void DoAfterEachItemInit(int indexR, int indexC, T gi)
	{ 
		
	}

    public T LeftMost(int row)
	{
		return buffer[row, 0];
	}
    public T RightMost(int row)
	{
		return buffer[row,cCount - 1];
	}
    public T UpMost(int col)
	{
		return buffer[rCount - 1, col];
	}
    public T DownMost(int col)
	{
		return buffer[0, col];
	}

	

}