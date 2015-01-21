using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public Vector3 g = new Vector3(0,-6f,0);
	public bool still  	 = false;
	public Vector3 speed = Vector3.zero;
	public Vector3 acc = Vector3.zero;

	public void setStill(){
		still = true;
	}
	public void resetStill(){
		still = false;
	}
	// Use this for in =itialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setAcc(Vector3 newAcc){
		this.acc = newAcc;
	}
	public void setSpeed(Vector3 newSpeed){
		this.speed = newSpeed;
		FixedUpdate ();
	}

	void FixedUpdate(){
		if (still) return;
		float dt = Time.fixedDeltaTime;

		Vector3 curPos = this.transform.position;
		Vector3 curAcc = acc + g;
		speed = speed + dt * curAcc;

		Vector3 nextPos = curPos + speed * dt;
		rigidbody2D.MovePosition (nextPos);
			
		
	}
	void OnTriggerStay2D(Collider2D other){
		OnTriggerEnter2D (other);
	}
	void OnTriggerEnter2D(Collider2D other){
		//print (other.name);
		Hero h = GetComponent<Hero> ();
		if (other.tag == "Ground") {
			print ("hit ground");
			if(other.transform.position.y < transform.position.y && !h.isStairMode){
				speed = new Vector3(0,0,0);
				acc = -1 * g;
			}
		} 
	}

	void OnTriggerExit2D(Collider2D other){
		Hero h = GetComponent<Hero> ();
		if (other.tag == "Ground") {
			if(other.transform.position.y < transform.position.y  + 0.006 && !h.isStairMode){
				acc =  Vector3.zero;
			}
		} 
	}


}
