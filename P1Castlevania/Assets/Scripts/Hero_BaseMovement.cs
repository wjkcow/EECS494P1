using UnityEngine;
using System.Collections;

public class Hero_BaseMovement : MonoBehaviour {
	private Animator anim;
	private bool facingLeft = true;
	public Vector3 jumpSpeed = new Vector3 (0,1.75f,0);
	public Vector3 rightSpeed = new Vector3 (0.8f, 0, 0);
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		bool isOnStair = GetComponent<Hero> ().isStairMode;
		if (isOnStair) {
			return;		
		}
		Gravity g = GetComponent<Gravity> ();		

		if (Input.GetKeyDown (KeyCode.Space)) {
			g.setSpeed (jumpSpeed);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			g.setSpeed (rightSpeed);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			g.setSpeed (new Vector3 (-1.0f, 0, 0));
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			g.setSpeed (rightSpeed);
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			g.setSpeed (new Vector3 (-1.0f, 0, 0));
		} 

	}
	void setFaceLeft(bool left){
		if (left) {
			if (!facingLeft) {
				flip();
				facingLeft = true;
			}	
		} else { 
			if(facingLeft){
				flip();
				facingLeft = false;
			}
			
		}
	}

	void flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
