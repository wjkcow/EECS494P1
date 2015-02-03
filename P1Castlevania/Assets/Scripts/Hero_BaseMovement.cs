using UnityEngine;
using System.Collections;

public class Hero_BaseMovement : MonoBehaviour
{
	private Animator anim;
	public Vector3 jumpSpeed = new Vector3 (0, 1.75f, 0);
	public Vector3 jumpRightSpeed = new Vector3 (0.75f, 0, 0);
	public Vector3 rightSpeed = new Vector3 (0.015f, 0, 0);
	public Vector3 fallSpeed = new Vector3 (0, -6f, 0);
	private Gravity g;
	private Vector3 jumpHeight = Vector3.zero;
	private bool lastStairState;
	private bool player_control_enable = true;
	
	public enum HeroState
	{
		STAND,
		WALK,
		JUMP,
		SQUAT,
		THROW,
		WHIP,
		FALLING,
		HIT,
		OUTSTAIR
	}
	public HeroState curState = HeroState.STAND;
	HeroState lastState;
	
	public void setPlayerControl (bool b){
		player_control_enable = b;
	}
	
	public void toLastState ()
	{
		curState = lastState;
	}
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		g = GetComponent<Gravity> ();
		lastStairState = GetComponent<Hero> ().isStairMode;
	}
	
	// Update is called once per frame
	bool check ()
	{
		if (GetComponent<Hero> ().hitten) {
			anim.SetBool ("Walk", false);
			anim.SetBool ("Squat", false);
			lastState = curState = HeroState.STAND;
			return true;
		}
		bool isOnStair = GetComponent<Hero> ().isStairMode;
		if (isOnStair) {
			lastStairState = isOnStair;
			anim.SetBool ("Squat", false);
			return true;		
		}
		if (!isOnStair && lastStairState) {
			lastStairState = isOnStair;
			curState = HeroState.OUTSTAIR;
		}
		return false;
	}
	void FixedUpdate(){
		if (player_control_enable) {
						if (check ()) {
								return;		
						}
			if(curState == HeroState.STAND || curState == HeroState.WALK){
			walk ();
			}
				}

	}
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.B)) {
			anim.SetInteger("WhipState", 0);		
		} 
		if (Input.GetKeyDown (KeyCode.N)) {
			anim.SetInteger("WhipState", 1);		
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			anim.SetInteger("WhipState", 2);		
		} 
		if (player_control_enable) {
			if (check ()) {
				return;		
			}
			
			
			if (curState == HeroState.STAND) {
				jump ();
		//		walk ();
				squat ();
			}
			if (curState == HeroState.WALK) {
		//		walk ();
				jump ();
				squat ();		
				
			}
			if (curState == HeroState.SQUAT) {
				squat ();		
				face ();
			}
			whip ();
			walk_release ();
			squat_release ();
		}
	}
	
	void whip ()
	{
		if (curState == HeroState.STAND || curState == HeroState.WALK || 
		    curState == HeroState.JUMP || curState == HeroState.SQUAT) {
			if (Input.GetKeyDown (KeyCode.X)) {
				anim.SetBool ("Walk", false);
				anim.SetTrigger ("Whip");
				lastState = curState;
				curState = HeroState.WHIP;
				
			}
			
		}
		
	}
	
	void face ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			setFaceLeft (true);
		} 
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			setFaceLeft (false);
		}
		
	}
	
	void squat ()
	{
		if (Input.GetKey (KeyCode.DownArrow)) {
			anim.SetBool ("Walk", false);
			
			anim.SetBool ("Squat", true);
			curState = HeroState.SQUAT;
		} //else if (Input.GetKeyUp (KeyCode.DownArrow)) {
		//						anim.SetBool ("Squat", false);
		//						curState = HeroState.STAND;
		//				}
		
	}
	
	void squat_release ()
	{
		if (!Input.GetKey (KeyCode.DownArrow)) {
			anim.SetBool ("Squat", false);
			if (curState == HeroState.SQUAT) {
				curState = HeroState.STAND;
			}
		}
	}
	
	void walk_release ()
	{
		if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
			anim.SetBool ("Walk", false);
			if (curState == HeroState.WALK) {
				curState = HeroState.STAND;
				
			}
		}
	}
	
	void walk ()
	{	
		if (Input.GetKey (KeyCode.LeftArrow)) {
			setFaceLeft (true);
			anim.SetBool ("Walk", true);
			//rigidbody2D.MovePosition(transform.position - rightSpeed);
			transform.position = transform.position - rightSpeed;
			
			curState = HeroState.WALK;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			setFaceLeft (false);
			anim.SetBool ("Walk", true);
			//rigidbody2D.MovePosition(transform.position + rightSpeed);
			transform.position = transform.position + rightSpeed;
			
			curState = HeroState.WALK;
		}
	}
	
	void jump ()
	{
		if (Input.GetKeyDown (KeyCode.Z)) {
			anim.SetBool ("Walk", false);
			jumpHeight = transform.position;
			anim.SetTrigger ("Jump"); 
			Vector3 speed = jumpSpeed;
			if (Input.GetKey (KeyCode.LeftArrow)) {
				speed -= jumpRightSpeed;
				setFaceLeft (true);				
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				speed += jumpRightSpeed;
				setFaceLeft (false);
				
			}
			g.setSpeed (speed);		
			g.setAcc(Vector3.zero);
			curState = HeroState.JUMP;
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (check ()) {
			return;		
		}
		
		g.gTrigger (other);
		if (other.tag == "Ground") {
			if (other.transform.position.y < transform.position.y) {
				if (curState == HeroState.FALLING) {
					anim.SetTrigger ("Landing");
					curState = HeroState.STAND;
					
				}
				if (curState == HeroState.OUTSTAIR) {
					curState = HeroState.STAND;
					
				}
				if (curState == HeroState.JUMP || curState == HeroState.WHIP) {
					lastState = curState = HeroState.STAND;
					if (transform.position.y < jumpHeight.y - 0.001) {
						anim.SetTrigger ("Landing");
					}
				}
				
			}
			
		} 
	}
	
	void OnTriggerStay2D (Collider2D other)
	{
		
		if (check ()) {
			return;		
		}
		
		if (other.tag == "Bottom") {
			g.speed.x = 0;
		}
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		
		if (check ()) {
			return;		
		}
		
		if (other.tag == "Ground") {
			if (g.speed.y == 0 && other.transform.position.y < transform.position.y) {
				anim.SetBool ("Walk", false);
				curState = HeroState.FALLING;
				g.setSpeed (fallSpeed);
			}
			
		}
		
	}
	
	void setFaceLeft (bool left)
	{
		GetComponent<Hero> ().setFaceLeft (left);
	}
	
	
}
