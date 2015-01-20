﻿using UnityEngine;
using System.Collections;

public class Hero_OnStair : MonoBehaviour {
	
	public bool downStairL = false;
	public bool downStairR = false;
	public bool upStairL = false;
	public bool upStairR = false;
	public bool onStair = false;
	public bool onCheckPoint = false;
	public bool keepWalking = false;
	public bool leaveStair = false;
	public Collider2D startChecker;
	public bool onTheWayToStair = false;
	public float dis = 0f;
	public Vector3 target;
	public Vector3 stairDir;
	public bool up = false;
	
	void FixedUpdate () {
		Gravity g = GetComponent<Gravity> ();
		Hero h = GetComponent<Hero> ();
		if (onTheWayToStair) {
			if (getReadyToGoStairs()){
				onStair = true;
				onTheWayToStair = false;
				keepWalking = true;
				print ("ready");
				if (up) g.setSpeed(stairDir);
				else g.setSpeed(-1 * stairDir);
			}
		}
		else if (onStair) {
			g.setAcc(-1 * g.g);
			if (leaveStair){
				onStair = false;
				print ("back to ground");
				g.setAcc(Vector3.zero);
				onCheckPoint = false;
				leaveStair = false;
				keepWalking = false;
				g.setSpeed (new Vector3 (0, 0, 0));
				h.isStairMode = false;
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				g.setSpeed (-1 * stairDir);
				onCheckPoint = false;
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				g.setSpeed(stairDir);
				onCheckPoint = false;
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				if (stairDir.x > 0)
					g.setSpeed(stairDir);
				else 
					g.setSpeed(-1 * stairDir);
				onCheckPoint = false;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				if (stairDir.x < 0)
					g.setSpeed(stairDir);
				else 
					g.setSpeed(-1 * stairDir);
				onCheckPoint = false;
			} else {
				if (onCheckPoint){
					g.setSpeed (new Vector3 (0, 0, 0));
					keepWalking = false;
				}
				if (onCheckPoint == false)
					keepWalking = true;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				up = true;
				if (upStairL){
					stairDir = new Vector3 (-0.5f,0.5f,0);
					g.setSpeed (new Vector3 (0, 0, 0));
					onTheWayToStair = true;
				} else if (upStairR){
					stairDir = new Vector3 (0.5f,0.5f,0);
					g.setSpeed (new Vector3 (0, 0, 0));
					onTheWayToStair = true;
				}
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				up = false;
				if (downStairL){
					onTheWayToStair = true;
					stairDir = new Vector3 (-0.5f,0.5f,0);
					g.setSpeed (new Vector3 (0, 0, 0));
				} else if (downStairR){
					onTheWayToStair = true;
					stairDir = new Vector3 (0.5f,0.5f,0);
					g.setSpeed (new Vector3 (0, 0, 0));
				} else {
					print ("sit");
				}
			}

			if (onTheWayToStair)
				h.isStairMode = true;
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "StairChecker"){
			
		} else if (other.tag == "Stair"){
			if (onStair && other.name == "stairS"){
				leaveStair = true;
				return;
			}
			if (onStair && keepWalking){
				onCheckPoint = true;
				keepWalking = false;
			}
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "StairChecker" && !onTheWayToStair) {
			if (other.bounds.Contains(transform.position)){
				setFalse();
				if (other.name == "DownL"){
					downStairL = true;
				} else if (other.name == "DownR"){
					downStairR = true;
				} else if (other.name == "UpR"){
					upStairR = true;
				} else if (other.name == "UpL"){
					upStairL = true;
				}
				startChecker = other;
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		
	}
	
	public bool getReadyToGoStairs (){
		Gravity g = GetComponent<Gravity> ();
		float speed = 0.2f;
		target = transform.position;
		target.x = startChecker.transform.FindChild("stairP").transform.position.x;
		dis = target.x - transform.position.x;
		if (Mathf.Abs (dis) < 0.003f) {
			transform.position = target;
			return true;
		}
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
		return false;
	}	
	
	void setFalse(){
		downStairL = false;
		downStairR = false;
		upStairL = false;
		upStairR = false;
	} 
}
