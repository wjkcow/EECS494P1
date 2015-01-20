﻿using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
//	public Sprite walk_1;
//	public Sprite walk_2;
//	public Sprite walk_3;
	private Vector3 stairDir;
	public bool onTheWayToStair = false;
	public Vector3 jumpSpeed = new Vector3 (0,1.75f,0);
	public Vector3 rightSpeed = new Vector3 (0.8f, 0, 0);
	private bool up = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Gravity g = GetComponent<Gravity> ();		
		stair s = GetComponent<stair> ();
		if (!s.onStair && !s.onTheWayToStair){
			if (Input.GetKeyDown (KeyCode.Space)) {
					g.setSpeed (jumpSpeed);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
					print ("leftArrow");
					g.setSpeed ();
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					print ("rightArrow");
					g.setSpeed (new Vector3 (-1.0f, 0, 0));
			} else if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
				g.setSpeed (new Vector3 (0, 0, 0));
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				print ("upArrow");
				up = true;
				if (s.upStairL){
					stairDir = new Vector3 (-0.5f,0.5f,0);
					onTheWayToStair = true;
				} else if (s.upStairR){
					stairDir = new Vector3 (0.5f,0.5f,0);
					onTheWayToStair = true;
				}
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				up = false;
				if (s.downStairL){
					onTheWayToStair = true;
					stairDir = new Vector3 (-0.5f,0.5f,0);
				} else if (s.downStairR){
					onTheWayToStair = true;
					stairDir = new Vector3 (0.5f,0.5f,0);		
				} else {
					print ("sit");
				}
			}
		}
	}


	
	void OnTriggerEnter2D(Collider2D other){
		print ("run into somethin" + other.tag);

	}
}
