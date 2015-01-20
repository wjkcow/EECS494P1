using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
//	public Sprite walk_1;
//	public Sprite walk_2;
//	public Sprite walk_3;
	private Vector3 stairDir;
	public bool onTheWayToStair = false;
	private bool up = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Gravity g = GetComponent<Gravity> ();		
		stair s = GetComponent<stair> ();
		if (onTheWayToStair) {
			if (s.getReadyToGoStairs()){
				onTheWayToStair = false;
				s.onStair = true;
				s.keepWalking = true;
				print ("ready");
				if (up) g.setSpeed(stairDir);
				else g.setSpeed(-1 * stairDir);
			}
		}
		else if (s.onStair) {
			g.setAcc(-1 * g.g);
			if (s.leaveStair){
				s.onStair = false;
				print ("back to ground");
				g.setAcc(Vector3.zero);
				s.onCheckPoint = false;
				s.leaveStair = false;
				s.keepWalking = false;
				g.setSpeed (new Vector3 (0, 0, 0));
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				print ("downArrow");
				g.setSpeed (-1 * stairDir);
				s.onCheckPoint = false;
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				print ("upArrow");
				g.setSpeed(stairDir);
				s.onCheckPoint = false;
			} else {
				if (s.onCheckPoint){
					g.setSpeed (new Vector3 (0, 0, 0));
					s.keepWalking = false;
				}
				if (s.onCheckPoint == false)
					s.keepWalking = true;
			}
		}
		else {
			if (Input.GetKeyDown (KeyCode.Space)) {
					g.setSpeed (new Vector3 (0, 2f, 0));
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					print ("leftArrow");
					g.setSpeed (new Vector3 (2.0f, 0, 0));

			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
					print ("rightArrow");
					g.setSpeed (new Vector3 (-2.0f, 0, 0));
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
//					
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
