using UnityEngine;
using System.Collections;

public class Hero_OnStair : MonoBehaviour {
	
	public bool downStairL = false;
	public bool downStairR = false;
	public bool upStairL = false;
	public bool upStairR = false;
	public bool onStair = false;
	public bool onCheckPoint = false;
	public bool leaveStair = false;
	public Collider2D startChecker;
	public bool onTheWayToStair = false;
	public float dis = 0f;
	public Vector3 target;
	public Vector3 stairDir;
	public bool up = false;
	private Animator anim;
	public bool leftStair = true;
	public bool goingUp = true;
	public bool goingLeft = true;
	public stairInfo sInfo;
	public GameObject curStair;
	public GameObject nextPos;

	void Start(){
		anim = GetComponent<Animator> ();
		sInfo = GetComponent<stairInfo> ();
	}
	
	void FixedUpdate () {
		Hero h = GetComponent<Hero> ();
		Gravity g = GetComponent<Gravity> ();
		nextPos = nextCheckPoint();

		if (onTheWayToStair) {
			if (getReadyToGoStairs()){
				onStair = true;
				onTheWayToStair = false;
				onCheckPoint = false;
				print ("ready");
				if (up) g.setSpeed(stairDir);
				else g.setSpeed(-1 * stairDir);

				if (up){
					anim.SetTrigger("Up_stair");
					goingUp = true;
					goingLeft = leftStair;
					setFaceLeft(leftStair);
				}
				else {
					goingUp = false;
					goingLeft = !leftStair;
					setFaceLeft(!leftStair);
					anim.SetTrigger("Down_stair");
				}
			}
		}
		else if (onStair) {
			g.setAcc(-1 * g.g);
			g.landByYourself = true;
			if (leaveStair){
				onStair = false;
				print ("back to ground");
				g.setAcc(Vector3.zero);
				onCheckPoint = false;
				leaveStair = false;
				g.setSpeed (new Vector3 (0, 0, 0));
				h.isStairMode = false;
				anim.SetTrigger("BackToIdle");
				g.landByYourself = false;
			} else if (onCheckPoint){
				if (playFirstAnim()){
					if (goingUp){
						setFaceLeft(leftStair);
						print ("go up stair");
						anim.SetTrigger("Up_stair");
						g.setSpeed(stairDir);
					}
					else {
						setFaceLeft(!leftStair);
						print ("go down stair");
						anim.SetTrigger("Down_stair");
						g.setSpeed(-1 * stairDir);
					}
					onCheckPoint = false;
				}
			}
			else if (!onCheckPoint){
				if (hasInput()){
					if (goingUp){
						setFaceLeft(leftStair);
						if (throughCheckPoint()){
							print ("go up stair");
							anim.SetTrigger("Up_stair");
						}
						g.setSpeed(stairDir);
					}
					else {
						setFaceLeft(!leftStair);
						if (throughCheckPoint()){
							print ("go down stair");
							anim.SetTrigger("Down_stair");
						}
						g.setSpeed(-1 * stairDir);
					}
					onCheckPoint = false;
				} 
				else {
					if (!onCheckPoint){
						if(!nextPos){
							return;
						}
						float dis = nextPos.transform.position.x - transform.position.x;
						if (Mathf.Abs(dis) < 0.005f){
							Vector3 temp = transform.position;
							temp = temp + dis * stairDir.normalized;
							transform.position = temp;
							onCheckPoint = true;
							curStair = nextPos;
							print ("get to checkPoihnter");
							g.setSpeed (new Vector3 (0, 0, 0));
						}
					}
				}
			}
		} else if (startChecker){

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				up = true;
				if (upStairL){
					setLStair();
				} else if (upStairR){
					setRStair();
				}
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				up = false;
				if (downStairL){
					setLStair();
				} else if (downStairR){
					setRStair();
				}
			}
			if (onTheWayToStair)
				h.isStairMode = true;
		}
	}

	void setLStair(){
		Gravity g = GetComponent<Gravity> ();
		stairDir = new Vector3 (-0.2f,0.2f,0);
		g.setSpeed (new Vector3 (0, 0, 0));
		onTheWayToStair = true;
		setFaceLeft(up);
		leftStair = true;
	}

	void setRStair(){
		Gravity g = GetComponent<Gravity> ();
		stairDir = new Vector3 (0.2f,0.2f,0);
		g.setSpeed (new Vector3 (0, 0, 0));
		onTheWayToStair = true;
		setFaceLeft(!up);
		leftStair = false;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "StairChecker"){

		} else if (other.tag == "Stair"){
			if (onStair && other.name == "stairS"){
				leaveStair = true;
				return;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "StairChecker" && !onTheWayToStair) {
			if (other.bounds.Contains(transform.position)){
				setFalse();
				if (other.name == "DownL"){
					downStairL = true;
				} else if (other.name == "DownR"){
					downStairR = true;
				} else if (other.name == "UpR"){
					upStairR = true;
				} else if (other.name == "UpL"){
					upStairL = true;
				}
				startChecker = other;
				sInfo = other.transform.parent.gameObject.transform.GetComponent<stairInfo>();
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other == startChecker) {
			startChecker = null;		
		}
	}
	
	public bool getReadyToGoStairs (){
		Gravity g = GetComponent<Gravity> ();
		float speed = 0.2f;
		target = transform.position;
		target.x = startChecker.transform.FindChild("stairP").transform.position.x;
		dis = target.x - transform.position.x;
		if (dis < 0)
			setFaceLeft(true);
		else 
			setFaceLeft(false);
		if (Mathf.Abs (dis) < 0.003f) {
			transform.position = target;
			anim.SetBool ("Walk", false);
			return true;
		}
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
		anim.SetBool ("Walk", true);
		return false;
	}	

	bool hasInput(){
		bool localUp = goingUp;
		bool localLeft = goingLeft;
		if (Input.GetKey (KeyCode.DownArrow)) {
			localUp = false;
			localLeft = !leftStair;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			localUp = true;
			localLeft = leftStair;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			localUp = !leftStair;
			localLeft = false;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			localUp = leftStair;
			localLeft = true;
		} else 
			return false; 

		if (localUp != goingUp || localLeft != goingLeft) {
			print ("cannot change dir");
			return false;		
		}
		return true;
	}
	
	void setFalse(){
		downStairL = false;
		downStairR = false;
		upStairL = false;
		upStairR = false;
	} 

	GameObject nextCheckPoint(){
		if(!sInfo){
			return null;
		}
		if (goingLeft){
			if (!leftStair){
				for (int i = sInfo.stairs.Length; i --> 0; ){
					GameObject g = sInfo.stairs[i];
					if (g.transform.position.x < transform.position.x)
						return g;
				}
			} else {

				foreach (GameObject g in sInfo.stairs ){
					if (g.transform.position.x < transform.position.x)
						return g;
				}
			}
		}
		else if(!goingLeft){
			if (leftStair){
				for (int i = sInfo.stairs.Length; i --> 0; ){
					GameObject g = sInfo.stairs[i];
					if (g.transform.position.x > transform.position.x)
						return g;
				}
			} else {
				foreach (GameObject g in sInfo.stairs ){
					if (g.transform.position.x > transform.position.x)
						return g;
				}
			}
		}
		return null;
	}

	bool throughCheckPoint(){
		foreach (GameObject g in sInfo.stairs){
			if (Mathf.Abs(g.transform.position.x - transform.position.x) < 0.0015f){
				if (g != curStair)
					return true;
			}
		}
		return false;
	}

	void setFaceLeft (bool left)
	{
		GetComponent<Hero> ().setFaceLeft (left);
	}


	bool getToEnd (){
		foreach (GameObject g in sInfo.startPos){
			if (Mathf.Abs(g.transform.position.x - transform.position.x) < 0.01f)
				return true;
		}
		return false;
	}

	bool playFirstAnim(){
		if (Input.GetKey (KeyCode.DownArrow)) {
			goingUp = false;
			goingLeft = !leftStair;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			goingUp = true;
			goingLeft = leftStair;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			goingUp = !leftStair;
			goingLeft = false;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			goingUp = leftStair;
			goingLeft = true;
		} else
			return false;
		return true;
	}


}
