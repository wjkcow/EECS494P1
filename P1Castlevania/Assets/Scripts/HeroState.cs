using UnityEngine;
using System.Collections;

public class HeroState : MonoBehaviour {
	private Animator anim;
	private bool facingLeft = true;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
				anim.SetBool("Walk", true);
		
		}	
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
		//	anim.SetBool("Walk", false);
		}	
		if(Input.GetKeyDown(KeyCode.RightArrow)) {


		}	

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger("Jump");
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
