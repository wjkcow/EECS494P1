using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	public bool hitten = false;
	public bool isStairMode = false;
	public bool facingLeft = true;
	public bool immune = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.I)) {
			immune = !immune;		
		}
		if (transform.position.y < -4) {
			print ("fall");		
			Application.LoadLevel (Application.loadedLevel);
		}
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

	public void die(){
		if (!immune) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	void OnBecameInvisible() {
	}
}
