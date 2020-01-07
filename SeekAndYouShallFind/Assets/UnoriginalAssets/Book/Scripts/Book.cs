/* Copyright (c) 2017 Kuneko. All rights reserved. */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {
	
	//----------------------------------------
	// Public Variables 
	//----------------------------------------

	public bool controlWithKeys;
	public bool controlWithClick;
	public bool controlWithSwipe;
	
	[Space(10)]
	
	public Transform[] pageLeaf;
	public AudioClip openCloseSound;
	public AudioClip pageTurnSound;

	//----------------------------------------
	// Private Variables
	//----------------------------------------

	private Transform[] pageAnim;
	private float[] pageAngle;
	private float[] pageAngleMin;
	private float[] pageAngleMax;
	private float speed = 150.0f;
	private float xPos;
	private int page = -1;
	private int totalPages;
	private AudioSource myAudio;

	//----------------------------------------
	// Start
	//----------------------------------------

	void Start () {
	
		//cache the audio source

		myAudio = GetComponent<AudioSource>();

		//setup the pages

		totalPages = pageLeaf.Length;
		pageAnim = new Transform[totalPages];
		pageAngle = new float[totalPages];
		pageAngleMin = new float[totalPages];
		pageAngleMax = new float[totalPages];

		//loop through all of the pages
		//set minimum and maximum angles and setup animations

		for (int i = 0 ; i < totalPages ; i++) {
			pageAngleMin[i] = pageLeaf[i].localEulerAngles.y;
			pageAngleMax[i] = pageLeaf[i].localEulerAngles.y + 170;
			pageAnim[i] = pageLeaf[i].Find("Page");
			if (pageAnim[i] != null) {
				pageAnim[i].GetComponent<Animation>()["RL"].speed = 2.0f;
				pageAnim[i].GetComponent<Animation>()["LR"].speed = 2.0f;
			}
		}

		//remove the click controls if clicking to turn pages is not allowed

		if (!controlWithClick)
			Destroy(transform.Find("ClickControls").gameObject);

	}

	//----------------------------------------
	// Update
	//----------------------------------------

	void Update () {

		//cycle pages left and right using the keyboard and swipes

		if (((Input.GetKeyDown("left")) && controlWithKeys) || (Swipe.lastSwipeDirection == Swipe.Direction.Left && controlWithSwipe))
			TurnPage(-1);

		if (((Input.GetKeyDown("right")) && controlWithKeys) || (Swipe.lastSwipeDirection == Swipe.Direction.Right && controlWithSwipe) || (Input.GetMouseButtonDown(1) && controlWithClick))
			TurnPage(+1);

		//loop through all of the pages
		//turn the page if necessary and play animations

		for (int i = 0 ; i < totalPages ; i++) {
			if (page >= i) {
				pageAngle[i] += Time.deltaTime * speed;
				if (pageAnim[i] != null)
					pageAnim[i].GetComponent<Animation>().Play("RL");
			} else {
				pageAngle[i] -= Time.deltaTime * speed;
				if (pageAnim[i] != null)
					pageAnim[i].GetComponent<Animation>().Play("LR");
			}
			pageAngle[i] = Mathf.Clamp(pageAngle[i], pageAngleMin[i], pageAngleMax[i]);
			pageLeaf[i].localEulerAngles = new Vector3(0.0f, pageAngle[i], 0.0f);
		}

	}

	//----------------------------------------
	// Turn Page
	//----------------------------------------

	public void TurnPage (int direction) {

		//turn the pages if possible
		//play sound effects for page turning and book opening and closing

		switch (direction) {
			case -1 :
				if (page < totalPages-1) {
					page++;
					if (page == 0 || page == totalPages-1)
						myAudio.PlayOneShot(openCloseSound);
					else
						myAudio.PlayOneShot(pageTurnSound);
				}
				break;
			case 1 :
				if (page > -1) {
					page--;
					if (page == -1 || page == totalPages-2)
						myAudio.PlayOneShot(openCloseSound);
					else
						myAudio.PlayOneShot(pageTurnSound);
				}
				break;
		}

	}

}