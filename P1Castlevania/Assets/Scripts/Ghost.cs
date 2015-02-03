using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
	public bool walk_left = true;
	public Vector3 rightSpeed = new Vector3 (0.005f, 0, 0);

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Hero").transform.position.x > transform.position.x) {
			walk_left = false;		
		}
		if (!walk_left) {
			flip ();
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<Enemy> ().start) {
			return;		
		}
		if (walk_left) {
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
}
