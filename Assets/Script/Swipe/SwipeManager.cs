using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour 
{
	private bool swipeLeft, swipeRight;
	private Vector2 startTouch, swipeDelta;

	private void Update()
	{
		swipeLeft = swipeRight = false;

		//standalone inputs
			if (Input.GetMouseButtonDown(0)) 
			{startTouch = Input.mousePosition;}

			else if(Input.GetMouseButtonUp(0)) 
			{Reset ();}

		//mobile inputs
		if (Input.touches.Length > 0) 
		{
			if (Input.touches[0].phase == TouchPhase.Began) 
			{startTouch = Input.touches [0].position;}

			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) 
			{Reset ();}
		}

		//calculate the distance
		swipeDelta = Vector2.zero;
		if (startTouch != Vector2.zero) 
		{
			if (Input.touches.Length > 0)swipeDelta = Input.touches [0].position - startTouch;
			else if (Input.GetMouseButton(0))swipeDelta = (Vector2)Input.mousePosition - startTouch;
		}
		//cross the deadzone
		if (swipeDelta.magnitude > 80) 
		{
			//which direction
			float x = swipeDelta.x;
			float y = swipeDelta.y;

			if (Mathf.Abs(x) > Mathf.Abs(y))
			{
				//left or right
				if (x < 0)
					swipeLeft = true;
				else
				swipeRight = true;
			} 
			Reset ();
		}
	}

	private void Reset()
	{
		startTouch = swipeDelta = Vector2.zero;
	}

	public Vector2 SwipeDelta {get{ return swipeDelta; } }
	public bool SwipeLeft {get { return swipeLeft; } }
	public bool SwipeRight {get {return swipeRight; } }
}
