using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Modify the given vertices so they follow a sin curve
 */
public class VertBend : BaseVertexEffect
{
	public float scale = 10f;
	public float amplitude = 35f;
	public float phase = 0f;

	public Color32[] colors;

	Vector3 v1;
	Vector3 v2;

	bool isV1;

	protected override void Awake()
	{
		v1 = this.transform.position;
		v2 = v1 + Vector3.left * 0.001f;
		isV1 = true;
	}

	void Updates()
	{
		isV1 = !isV1;
		if(isV1)
			this.transform.position = v1;
		else 
			this.transform.position = v2;
	}

	public override void ModifyVertices(List<UIVertex> verts)
	{
		if (!IsActive ())
			return;
		
		for (int index = 0; index < verts.Count; index++)
		{
			var uiVertex = verts[index];
			
			uiVertex.color = colors[Random.Range(0, colors.Length)];
			Debug.Log(index);
			verts[index] = uiVertex;
		}
	}
}