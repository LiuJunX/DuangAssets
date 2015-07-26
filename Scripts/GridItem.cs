using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridItem<T> : MonoBehaviour
    where T : GridItem<T>
{


    public Grid<T> grid;
	public int row;
	public int col;

	/// <summary>
	/// Խ�磬����null
	/// </summary>
    public virtual T left
    {
        get
        {
            if ( leftMost )
                return null;
            return grid[ row, col - 1 ];
        }
    }
	/// <summary>
	/// Խ�磬����null
	/// </summary>
    public virtual T up
    {
        get
        {
            if ( upMost )
                return null;
            return grid[ row + 1, col ];
        }
    }
	/// <summary>
	/// Խ�磬����null
	/// </summary>
    public virtual T right
    {
        get
        {
            if ( rightMost )
                return null;
            return grid[ row, col + 1 ];
        }
    }
	/// <summary>
	/// Խ�磬����null
	/// </summary>
    public virtual T down
    {
        get
        {
            if ( downMost )
                return null;
            return grid[ row - 1, col ];
        }
    }
	/// <summary>
	/// Խ�磬����null
	/// </summary>

	public bool leftMost{ get { return col == 0; } }
	public bool upMost { get {  return row == grid.rCount - 1; } }
	public bool rightMost { get { return col == grid.cCount - 1; } }
	public bool downMost { get { return row == 0; } }

	public void Exchange(int r, int c)
	{ 
		
	}

	public virtual void Init()
	{

	}

	public virtual void ResetState()
	{

	}


}