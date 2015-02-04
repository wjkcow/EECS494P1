using UnityEngine;
using System.Collections;

public class bossAI : MonoBehaviour {
	public GameObject middleLine;
	public int state = 0;
	public GameObject player;
	public float goUpSpeed = 1f;
	public float goVerticalSpeed = -1.2f;
	public Vector3 attackingDir;
	public Vector3 downSpeed;
	public Vector3 acc;
	private bool attackphase = true;
	private Vector3 destination;
	public float waitTime;
	private float time;
	private float hitTime;
	public float immuneTime = 0.2f;
	public GameObject area;
	public GameObject Drop_item;

	private GameObject canvas;
	private GlobalV globalV;

	private bool wake = false;
	// Use this for initialization
	void Start () {
		time = Time.time;
		hitTime = Time.time;
		canvas = GameObject.Find("Canvas");
		globalV = canvas.GetComponent<GlobalV> ();
	}

//	void Update () {
//		backToWaiting ();
//	}
	
//	 Update is called once per frame
	void Update () {
		if (wake){

			if (state == 0) {
				if (backToWaiting()){
					state ++;
				}		
			}
			else if (state == 1) {
				if (preparForAck()){
					state ++;
				}		
			}

			else if (state == 2) {
				if (attackphase){
					if (attacking1()){
						attackphase = false;
					}	
				} else {
					if (attacking2()){
						attackphase = true;
						state = 0;
					}
				}
			}

			Vector3 temp = transform.position;
			temp.z = 0;
			transform.position = temp;
			if (!area.collider2D.bounds.Contains(transform.position)){
				print ("stuck");
				state = 0;
				attackphase = true;
				Gravity g = GetComponent<Gravity> ();
				g.setAcc (Vector3.zero);
				g.setSpeed (Vector3.zero);
			}
		}
	}


	bool preparForAck(){
		print ("pa");
		float mx = middleLine.transform.position.x;
		float px = player.transform.position.x;
		float bs = transform.position.x;
		Vector3 pp = player.transform.position;
		Vector3 des = transform.position;
		if (px > mx) {
			des.x = px - 1.2f;
		} else {
			des.x = px + 1.2f;
		}
		float step = goVerticalSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, des, step);	
		if (Mathf.Abs(des.x - bs) < 0.02 && time + waitTime < Time.time){
			destination = pp;
			return true;
		}
		return false;
	
	}


	bool attacking1(){
		Gravity g = GetComponent<Gravity> ();
		if (transform.position.x - middleLine.transform.position.x > 0)
			g.setSpeed (attackingDir + downSpeed);
		else 
			g.setSpeed (-1 * attackingDir + downSpeed);
		g.setAcc (acc);
		return true;
	}

	bool attacking2(){
		if (Mathf.Abs(destination.x - transform.position.x) < 0.02){
			Gravity g = GetComponent<Gravity> ();
			g.setAcc (Vector3.zero);
			g.setSpeed (Vector3.zero);
			return true;;
		}
		return false;
	}



	bool backToWaiting(){
		Vector3 pp = player.transform.position;
		print ("waititng");
		if ( Mathf.Abs(pp.y - transform.position.y) < 0.8) {
			pp.y += 1;
			print ("waititng2");
			float step = goUpSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, pp, step);	
			return false;
		}
		time = Time.time;
		return true;

	}

	public void hitten(){
		print ("boss hitten");
		if (hitTime + immuneTime < Time.time){
			globalV.enemyLife --;
			hitTime = Time.time;
		}
		if (globalV.enemyLife <= 0) {
			GameObject di =  (GameObject)Instantiate (Drop_item, transform.position, Quaternion.identity);
			Destroy(gameObject);		
		}
	}

	void OnTriggerStay2D (Collider2D other){


		if (other.tag == "Hero") {
			print ("hit hero");
			other.GetComponent<Hero_hitten>().hitten(this.transform.position.x);		
		}
	}

	public void reset(){
		wake = true;
	}
}
