using UnityEngine;
using System.Collections;

public class stair : MonoBehaviour {
	
	public bool downStairL = false;
	public bool downStairR = false;
	public bool upStairL = false;
	public bool upStairR = false;
	public bool onStair = false;
	public bool onCheckPoint = false;
	public bool keepWalking = false;
	public bool leaveStair = false;
	public Collider2D startChecker;
	public float dis = 0f;
	public Vector3 target;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "StairChecker"){
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
		} else if (other.tag == "Stair"){
			if (onStair && other.name == "stairS"){
				leaveStair = true;
				return;
			}
			if (onStair && keepWalking){
				onCheckPoint = true;
				keepWalking = false;
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "StairChecker"){
			if (other.name == "DownL"){
				downStairL = false;
			} else if (other.name == "DownR"){
				downStairR = false;
			} else if (other.name == "UpR"){
				upStairR = false;
			} else if (other.name == "UpL"){
				upStairL = false;
			}
		}
	}

	public bool getReadyToGoStairs (){
		Gravity g = GetComponent<Gravity> ();
		float speed = 0.2f;
		target = transform.position;
		target.x = startChecker.transform.position.x;
		dis = startChecker.transform.position.x - transform.position.x;
		if (Mathf.Abs (dis) < 0.005f) {
			return true;
		}
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
		return false;
	}	
}
