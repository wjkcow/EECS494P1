using UnityEngine;
using System.Collections;

public class Water_ghost : MonoBehaviour {
	public bool faceLeft = true;
	public int fireRate = 2;
	public Vector3 jumpSpeed = new Vector3 (0.0f, 3.0f, 0);

	public Vector3 rightSpeed = new Vector3 (0.012f, 0, 0);
	public Vector3 bulletSpeed = new Vector3 (0.02f, 0, 0);
	public int  turnRate = 25;
	public Transform hero;
	public Transform muzzle;
	public GameObject bullet;
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
		GetComponent<Gravity> ().setSpeed (jumpSpeed);
		hero = GameObject.Find("Hero").transform;
		fire_c = fireRate;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!start) {
						return;		
				} else {
			anim.SetTrigger("Start");		
		}
		if (!GetComponent<Enemy> ().start) {
			return;		
		}
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
				anim.SetTrigger ("Shoot");
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


	void fire(){
		GameObject b =  (GameObject)Instantiate (bullet, muzzle.position, Quaternion.identity);
		if (faceLeft) {
			b.GetComponent<Bullet> ().speed  = -bulletSpeed;


		} else {
			b.GetComponent<Bullet> ().speed  = bulletSpeed;
			Vector3 theScale = b.transform.localScale;
			theScale.x *= -1;
			b.transform.localScale = theScale;
		}

	}
	void move(){
		print ("moving");
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
			//print ("delta" + (transform.position.y - other.transform.position.y ));
			if (other.transform.position.y < transform.position.y + 0.07) {
				start = true;
			}
		} else if (other.tag == "Wall"){
			flipObj();
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{

		if (other.tag == "Ground") {
			if (other.transform.position.y < transform.position.y) {
				start = false;
			}
		} 
	}


}
