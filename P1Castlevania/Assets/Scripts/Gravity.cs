using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public Vector3 g = new Vector3(0,-6f,0);
	public bool still  	 = false;
	public Vector3 speed = Vector3.zero;
	public Vector3 acc = Vector3.zero;

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
	}

	void FixedUpdate(){
		if (still) return;
		float dt = Time.fixedDeltaTime;

		Vector3 curPos = this.transform.position;
		Vector3 curAcc = acc + g;
		speed = speed + dt * curAcc;

		Vector3 nextPos = curPos + speed * dt;
//		print (speed);
//		print (curAcc);
		transform.position = nextPos;

		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Ground") {
			print ("hit ground");
			if(other.transform.position.y < transform.position.y){
				speed = new Vector3(0,0,0);
				acc = -1 * g;
				Vector3 tempPos = transform.position;

				transform.position = tempPos;
			}
		} 
	}

	void OnTriggerExit2D(Collider2D other){
		print (other.tag);
		if (other.tag == "Ground") {
			if(other.transform.position.y < transform.position.y){
				acc =  Vector3.zero;
			}
		} 
	}


}
