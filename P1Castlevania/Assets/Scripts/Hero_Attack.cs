using UnityEngine;
using System.Collections;

public class Hero_Attack: MonoBehaviour {

//	private bool whipping = false;
//	private float length = 0.1f;
	public GameObject whip;


	void whipStart(){
		whip.GetComponent<Whip> ().whipping = true;;
		//	whipping = true;
	}
	void whipDone(){
		whip.GetComponent<Whip> ().whipping = false ;

	//	whipping = false;
	}

	public void throwItem(){

	}
	// Use this for initialization
	void Start () {
		print (Vector2.up);
		whipStart ();
		whipDone ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	}
}
