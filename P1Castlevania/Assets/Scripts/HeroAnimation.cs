using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HeroAnimation : MonoBehaviour {
	public enum Animation_e{
		stand,
		walk,
		jump,
		squat
	}
	public enum Direction_e{
		left,
		right
	}


	
	public Sprite walk_1;
	public Sprite walk_2;
	public Sprite walk_3;
	public Sprite squat;
	public Sprite downstair;
	public Sprite upstair;

	struct Animation_s {
		public Animation_s(Animation_e n, int fr, Sprite[] Ss, Vector3[] Ds){
			name = n;
			frame_rate = fr;
			frame_c = fr;
			currentFrame = 0;
			Sprites = Ss;
			deltas = Ds;
		}
		public Animation_e name;
		public int    frame_rate;
		public int    frame_c; // count frame 
		public int    currentFrame;
		public Sprite[]  Sprites;
		public Vector3[] deltas;
	}

	public Animation_e curAnimation;
	public Direction_e curDir;
	List<Animation_s> Anis = new List<Animation_s>();
	public void play(Animation_e animation, Direction_e dir){
		curAnimation = animation;
		curDir = dir;
		Anis.ForEach (a => a.frame_c = a.frame_rate);
		Anis.ForEach (a => a.currentFrame = 0);

//		for(int i = 0; i < Anis.Count; ++i) {
//			Anis[i].frame_c = Anis[i].frame_rate;
//			Anis[i].currentFrame = 0;
//		}
	}
	// Use this for initialization
	void Start () {
		Anis.Add(new Animation_s(Animation_e.walk, 5, new Sprite[]{walk_1, walk_2, walk_3}, null));
		print (Anis);
	}
	
	// Update is called once per frame
	void Update () {
		if (curAnimation != Animation_e.stand) {
						for (int i = 0; i < Anis.Count; ++i) {
								if (Anis [i].name == curAnimation) {
										Animation_s a = Anis [i];
										if (a.frame_c-- == 0) {
												a.frame_c = a.frame_rate;
												Vector3 pos = this.transform.position;
												if (a.currentFrame == a.Sprites.Length) {
														curAnimation = Animation_e.stand;
														a.currentFrame = 0;

												} else {
														if (a.deltas != null) {
																this.transform.position = this.transform.position + a.deltas [a.currentFrame];
														}
														this.GetComponent<SpriteRenderer> ().sprite = a.Sprites [a.currentFrame];
														a.currentFrame ++;
												}
										}
										Anis [i] = a;
										return;
								}
						}
				} else {
				
			this.GetComponent<SpriteRenderer> ().sprite = walk_1;

		}


	}
}
