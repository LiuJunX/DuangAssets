using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Modify the given vertices so they follow a sin curve
 */
public class FontUVAdder : BaseVertexEffect
{

	Material mat;
	public float scrollSpeed = 0.5F;

	protected override void Awake ()
	{
		mat = GetComponent<Text> ().material;
	}

	void Updateddd()
	{
		float offset = Time.time * scrollSpeed;
		mat.SetTextureOffset("_ColorTex", new Vector2(offset, 0));
	}

	public override void ModifyVertices(List<UIVertex> verts)
	{
		if (!IsActive ())
			return;

		//Bounds bounds = GetComponent<CanvasRenderer>().;
		int count = verts.Count;
		float bottom = verts[0].position.y;
		float top = bottom;
		float right = verts[0].position.x;
		float left = right;
		
		float width = 0;
		float height = 0;
		
		for (int i = 1; i < count; i++) {
			float x = verts[i].position.x;
			float y = verts[i].position.y;
			if (y > top) {
				top = y;
			}
			else if (y < bottom) {
				bottom = y;
			}
			if(x > right){
				right = x;
			} else if(x < left){
				left = x;
			}
		}

		width = right - left;
		height = top - bottom;

		for (int index = 0; index < verts.Count; index++)
		{

			var uiVertex = verts[index];
			//Debug.Log(uiVertex.position);
			uiVertex.uv1 = new Vector2((uiVertex.position.x - left) / width, (uiVertex.position.y - bottom) / height);
			//Debug.Log(index + "_uv:" + uiVertex.uv1);
			verts[index] = uiVertex;
		}
	}
}