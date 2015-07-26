using UnityEngine;
using System.Collections;

/// <summary>
/// 将grid的宽和高表示为[-1, 1]的范围。
/// 左下角为[-0.5, -0.5]；中心为[0, 0]，右上角为[0.5, 0.5]...
/// </summary>
[System.Serializable]
public class GridAnchor {

	[Range(-0.5f, 0.5f)]
	public float width = 0;
	[Range (-0.5f,0.5f)]
	public float height = 0;

}
