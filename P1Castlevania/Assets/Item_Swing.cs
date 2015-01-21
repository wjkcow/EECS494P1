using UnityEngine;
using System.Collections;

public class Item_Swing : MonoBehaviour {
	public float swingSpeed = 0.3f;
	public float swingR = 0.3f;
	private Gravity g;
	private float initX;

	// Use this for initialization
	void Start () {
		g = GetComponent<Gravity> ();
		initX = transform.position.x;
		g.setSpeed (new Vector3 (swingSpeed, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > initX + swingR) {
			g.setSpeed (new Vector3 (-swingSpeed, 0, 0));
		}
		if ((transform.position.x < initX - swingR)) {
			g.setSpeed (new Vector3 (swingSpeed, 0, 0));
		}
	}
}
