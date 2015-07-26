using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyInput {
	
	public const float LONG_TOUCH_TIME = 0.4F;
	public const int STORED_TOUCHED_MAX_NUM = 10;
	public TouchMessage lastMessage;
	public TouchMessage downMessage;
	public TouchMessage upMessage;
	public LinkedList<TouchMessage> moveMessages = new LinkedList<TouchMessage>();
	
	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			upMessage = TouchMessage.EMPTY_MESSAGE;
			moveMessages.Clear();
			lastMessage = downMessage = new TouchMessage(TouchType.Down, GetMousePosScreen());
		}
		else if (Input.GetMouseButtonUp(0))
		{
			lastMessage = upMessage = new TouchMessage(TouchType.Up, GetMousePosScreen());
		}
		else if (Input.GetMouseButton(0))
		{
			lastMessage = new TouchMessage(TouchType.Moving, GetMousePosScreen());
			moveMessages.AddLast(lastMessage);
			if(moveMessages.Count > STORED_TOUCHED_MAX_NUM)
				moveMessages.RemoveFirst();
		}
	}
	
	Vector2 GetMousePosScreen()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	public SlideDirection GetSlideDirection(float slideMinDeltaPos)
	{
		if(downMessage.Equals(TouchMessage.EMPTY_MESSAGE))
			return SlideDirection.None;
		
		Vector2 deltaMousePos = lastMessage.pos - downMessage.pos;
		if (Vector2.SqrMagnitude (deltaMousePos) < slideMinDeltaPos * slideMinDeltaPos)
			return MyInput.SlideDirection.None;
		
		if (deltaMousePos.x * deltaMousePos.x > deltaMousePos.y * deltaMousePos.y) {
			return MyInput.SlideDirection.Horizontal;
		} else {
			return MyInput.SlideDirection.Vetical;
		}
	}

	public struct TouchMessage
	{
		public static TouchMessage EMPTY_MESSAGE = new TouchMessage(TouchType.Down, Vector2.zero);
		public float time;
		public TouchType touchType;
		public Vector2 pos;
		public TouchMessage(TouchType touchType, Vector2 pos, float time = -1f)
		{
			if(time == -1)
				this.time = MyTime.GlobalTimer.realtimeSinceStartup;
			else 
				this.time = time;
			this.touchType = touchType;
			this.pos = pos;
		}
	}
	
	public enum TouchType
	{
		Down,
		Moving,
		Up
	}
	
	public enum SlideDirection
	{
		None,
		Horizontal,
		Vetical
	}
	
}