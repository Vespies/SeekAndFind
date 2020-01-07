/* Copyright (c) 2017 Kuneko. All rights reserved. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurn : MonoBehaviour {

	//----------------------------------------
	// Public Variables
	//----------------------------------------

	public int direction;

	//----------------------------------------
	// On Mouse Down
	//----------------------------------------

	void OnMouseDown () {

		//turn the book pages when this game object is clicked

		SendMessageUpwards("TurnPage", direction);
		
	}

}