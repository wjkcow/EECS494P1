using UnityEngine;
using System.Collections;

public class Kirby : MonoBehaviour {

	public bool faceLeft = true;
	public int fireRate = 2;
	public Vector3 jumpSpeed = new Vector3 (0.0f, 3.0f, 0);
	
	public Vector3 rightSpeed = new Vector3 (0.012f, 0, 0);
	public Vector3 bulletSpeed = new Vector3 (0.02f, 0, 0);
	public int  turnRate = 25;
	private Transform hero;
	public bool 	shootDone = true;
	private int turnC = 0;
	public bool turn = false;
	private Animator anim;
	private bool start = false;
	private int fire_c;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		turnC = turnRate;
		hero = GameObject.Find("Hero").transform;
		fire_c = fireRate;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!shootDone) {
			return;		
		}
		if (turn) {
			flip();
			turn = false;		
		}
		turnC --;
		if (turnC == 0) {
			turnC = turnRate;
			if(fire_c-- == 0){
				fire_c = fireRate;
				shootDone = false;
				anim = GetComponent<Animator> ();
				anim.SetTrigger ("Call");
			}
			
			if(faceLeft && hero.position.x > transform.position.x){
				faceLeft = false;
				turn = true;
			}
			if(!faceLeft && hero.position.x < transform.position.x){
				faceLeft = true;
				turn = true;
			}
		} else {
			move();
		}
	}
	
	
	void Call(){

	}
	void move(){
		if (faceLeft) {
			transform.position = transform.position - rightSpeed;
		} else {
			transform.position = transform.position + rightSpeed;
		}
	}
	
	void flip ()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void flipObj(){
		flip ();
		faceLeft = !faceLeft;
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Ground") {
		} else if (other.tag == "Wall"){
			flipObj();
		}
	}

}
