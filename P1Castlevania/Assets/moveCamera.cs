using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {
	public Vector3 pos;
	public Camera camera;
	private int oldCamera;
	public float duration;
	private float timing;
	private bool moving = false;
	public GameObject otherChecker;

	void FixedUpdate(){
		if (timing + duration < Time.time  && moving) {
			camera.cullingMask = oldCamera;
			moving = false;
			otherChecker.SetActive(true);
		}
	}


	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other){
		oldCamera = camera.cullingMask;
		if (other.tag == "Hero") {
			otherChecker.SetActive(false);
			camera.cullingMask = 1 << 0;
			timing = Time.time;
			moving = true;
			camera.transform.position = pos;
		}
	}
	
}
