using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	public bool isStairMode = false;
	public bool facingLeft = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}


	
	void OnTriggerEnter2D(Collider2D other){

	}
	public void setFaceLeft (bool left)
	{
		if (left) {
			if (!facingLeft) {
				flip ();
				facingLeft = true;
			}	
		} else { 
			if (facingLeft) {
				flip ();
				facingLeft = false;
			}
			
		}
	}
	
	void flip ()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
