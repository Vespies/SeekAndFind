/* Copyright (c) 2017 Kuneko. All rights reserved. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	//----------------------------------------
	// Enumerable Variables
	//----------------------------------------

	public enum Direction {None = 0, Up, Down, Left, Right};

	//----------------------------------------
	// Public Static Variables
	//----------------------------------------

	public static Direction lastSwipeDirection;

	//----------------------------------------
	// Private Variables
	//----------------------------------------

	private Vector2 startPosition;
	private Vector2 lastPosition;
	private Vector2 currentSwipe;

	//----------------------------------------
	// Update
	//----------------------------------------

	void Update () {
	
		//reset the swipe direction

		lastSwipeDirection = Direction.None;

		//start the swipe when the mouse button has been pressed

		if (Input.GetMouseButtonDown(0))
			startPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		
		//calculate the swipe direction when the mouse button is released

		if (Input.GetMouseButtonUp(0)) {
			currentSwipe = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - startPosition).normalized;
			if (currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				if (currentSwipe.y > 0.0f)
					lastSwipeDirection = Direction.Up;
				else if (currentSwipe.y < 0.0f)
					lastSwipeDirection = Direction.Down;
			}
			if (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				if (currentSwipe.x < 0)
					lastSwipeDirection = Direction.Left;
				else if (currentSwipe.x > 0)
					lastSwipeDirection = Direction.Right;
			}
		}

	}

}