using UnityEngine;
using System.Collections;

public class Kirby : MonoBehaviour {

	public bool faceLeft = true;
	public int fireRate = 2;
	public Vector3 rightSpeed = new Vector3 (0.012f, 0, 0);
	public int  turnRate = 25;
	private Transform hero;

	public bool 	shootDone = true;
	private int turnC = 0;
	public bool turn = false;
	private Animator anim;
	private bool start = false;
	private int fire_c;
	public GameObject ghostPrefab;
	public Transform[] ghostsPos;
	
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
		for(int i = 0; i < ghostsPos.Length; i++){
			Transform pos = ghostsPos[i];
			if(Mathf.Abs( pos.position.x - GameObject.Find ("Hero").transform.position.x) > 0.2){
				GameObject e =  (GameObject)Instantiate (ghostPrefab, pos.position, Quaternion.identity);
			}
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
