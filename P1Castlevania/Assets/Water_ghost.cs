using UnityEngine;
using System.Collections;

public class Water_ghost : MonoBehaviour {

	public bool faceLeft = true;
	public Vector3 rightSpeed = new Vector3 (0.012f, 0, 0);
	public Vector3 bulletSpeed = new Vector3 (0.02f, 0, 0);
	public int  turnRate = 100;
	public Transform hero;
	public Transform muzzle;
	public GameObject bullet;
	private int turnC = 0;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<Enemy> ().start) {
			return;		
		}
		if (faceLeft) {
			transform.position = transform.position - rightSpeed;
		} else {
			transform.position = transform.position + rightSpeed;
		}
	}

	void FixedUpdate(){

	}
	void fire(){

	}
	
	void flip ()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
