using UnityEngine;
using System.Collections;

public class HeroState : MonoBehaviour {
	const int walk_frame = 10;
	const float walk_speed = 0.07f;
	enum State_e{
		stand,
		walk,
		jump,
		squat,
		drop,
	}
	enum Direction_e{
		left,
		right
	}
	private int  walk_c = walk_frame;
	State_e curState;
	Direction_e curDir;

	// Use this for initialization
	void Start () {
	
	}
	// transfer sprite to walk
	void walk(Direction_e dir){
		curState = State_e.walk;
	}
	// transfer sprite to stop
	void stand(Direction_e dir){
		curState = State_e.walk;
	}
	// transfer sprite to jump
	void jump(Direction_e dir){
		
	}
	// transfer sprite to whip	
	void whip(Direction_e dir){
		
	}

	void hit(Direction_e dir){

	}
	// Update is called once per frame
	void Update () {
		//		Vector3 pos = this.transform.position;
		//		pos.x = pos.x - walk_speed / 50;
		//		this.transform.position = pos;
		//		if (walk_c-- == 0) {
		//
		//			if (this.GetComponent<SpriteRenderer> ().sprite == walk_1) {
		//				this.GetComponent<SpriteRenderer> ().sprite = walk_2;
		//			} else if (this.GetComponent<SpriteRenderer> ().sprite == walk_2) {
		//				this.GetComponent<SpriteRenderer> ().sprite = walk_3;
		//			} else {
		//				this.GetComponent<SpriteRenderer> ().sprite = walk_1;
		//			}
		//			walk_c = walk_frame;
		//		}
	}
}
