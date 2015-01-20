using UnityEngine;
using System.Collections;

public class Hero_BaseMovement : MonoBehaviour {
	public Vector3 jumpSpeed = new Vector3 (0,1.75f,0);
	public Vector3 rightSpeed = new Vector3 (0.8f, 0, 0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Gravity g = GetComponent<Gravity> ();		

		if (Input.GetKeyDown (KeyCode.Space)) {
			g.setSpeed (jumpSpeed);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			g.setSpeed (rightSpeed);
			
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			g.setSpeed (new Vector3 (-1.0f, 0, 0));
		} 

	}
}
