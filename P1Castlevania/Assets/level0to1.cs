using UnityEngine;
using System.Collections;

public class level0to1 : MonoBehaviour {
	public Camera camera;
	public GameObject hero;
	public GameObject camPos;
	public GameObject heroPos;
	private int oldCamera;
	public float duration;
	private float timing;
	private bool moving = false;
	// Use this for initialization
	void FixedUpdate(){
		if (timing + duration < Time.time  && moving) {
			camera.cullingMask = oldCamera;
			moving = false;
		}
	}
	
	
	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other){
		oldCamera = camera.cullingMask;
		if (other.tag == "Hero") {
			camera.cullingMask = 0;
			timing = Time.time;
			moving = true;
			camera.transform.position = camPos.transform.position;
			hero.transform.position = heroPos.transform.position;
			CameraFollow script =	camera.GetComponent<CameraFollow>();	
			script.setCameraStop(true);
		}
	}
}
