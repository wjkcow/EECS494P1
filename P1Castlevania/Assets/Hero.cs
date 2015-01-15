using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	public Sprite walk_1;
	public Sprite walk_2;
	public Sprite walk_3;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Gravity g = GetComponent<Gravity> ();		

		if (Input.GetKeyDown (KeyCode.Space)) {
						g.setSpeed (new Vector3 (0, 2f, 0));
				} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						print ("leftArrow");
						g.setSpeed (new Vector3 (2.0f, 0, 0));

				} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
						print ("rightArrow");
						g.setSpeed (new Vector3 (-2.0f, 0, 0));
				} else if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			g.setSpeed (new Vector3 (0, 0, 0));

		}

	}


	void FixedUpdate(){


	}

	void OnTriggerEnter2D(Collider2D other){
		print ("run into somethin" + other.tag);

	}
}
