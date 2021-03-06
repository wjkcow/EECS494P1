﻿using UnityEngine;
using System.Collections;

public class Hero_hitten : MonoBehaviour
{
		public int immune_time = 70;
		public int blink_time = 5;
	public int invisible_Time = 2;
	    public Vector3 up_speed = new Vector3 (0, 1, 0);
		public Vector3 left_speed = new Vector3 (-1, 0, 0);
		private int immune_c = 0;
		private int blink_c = 0;
		private Gravity g;
		private Animator anim;
		public GameObject canvas;
		private GlobalV globalV;
		private float emptyZ = 100;
		public float visibleZ = 0;
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
				g = GetComponent<Gravity> ();
				globalV = canvas.GetComponent<GlobalV> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{
				if (immune_c > 0) {
						if (blink_c == 0) {
								print ("blink");
								//	GetComponent<SpriteRenderer> ().enabled = !GetComponent<SpriteRenderer> ().enabled ;
								if (transform.position.z == emptyZ) {
										Vector3 pos = transform.position;
										pos.z = visibleZ;
										transform.position = pos;
										blink_c = blink_time;

								} else {
										Vector3 pos = transform.position;
										pos.z = emptyZ;
										transform.position = pos;
										blink_c = invisible_Time;

								}
				

						}
						blink_c --;	
						immune_c --;
			if(immune_c == 0){
				Vector3 pos = transform.position;
				pos.z = visibleZ;
				transform.position = pos;
			}
				}	
				
		}

		public void hitten (float x)
		{
				if (immune_c > 0) {
						return;
				}
				globalV.playerLife --;
				immune_c = immune_time;
				if (!GetComponent<Hero> ().isStairMode) {
						if (transform.position.x < x) {
								GetComponent<Hero> ().setFaceLeft (false);
								g.setSpeed (up_speed + left_speed);
						} else {
								GetComponent<Hero> ().setFaceLeft (true);
								g.setSpeed (up_speed - left_speed);
						}
						anim.SetTrigger ("Hit");	
						GetComponent<Hero> ().hitten = true;
				}

		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag == "Ground") {
						GetComponent<Hero> ().hitten = false;
				}

		}
}
