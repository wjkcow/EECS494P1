using UnityEngine;
using System.Collections;

public class Hero_Attack: MonoBehaviour {

//	private bool whipping = false;
//	private float length = 0.1f;
	public GameObject whip;

	public void whipStart(){

		whip.GetComponent<Whip> ().whipping = true;;
	//	whipping = true;
	}

	public void whipDone(){
		whip.GetComponent<Whip> ().whipping = false ;

	//	whipping = false;
	}

	public void throwItem(){

	}
	// Use this for initialization
	void Start () {
		print (Vector2.up);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
//		bool facingLeft = GetComponent<Hero> ().facingLeft;
//		Vector2 direction;
//		if (facingLeft) {
//						direction = new Vector2 (1.0f, 0);		
//		} else {
//			direction = new Vector2 (-1.0f, 0);		
//
//		}
//		if (whipping) {
//			RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, length);
//			if (hit.collider != null) {
//				print(hit.collider.tag );
//			}
//			
//		}

	}
}
