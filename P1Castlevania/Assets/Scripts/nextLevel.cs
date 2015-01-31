using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {
	public GameObject camera;
	public GameObject playerDes;
	public GameObject player;
	public GameObject carmeraDes;
	public bool begin = false;
	public bool movePlayer = false;
	public bool end = false;
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Hero") {
			print ("start move!!!!!!");
			Hero_BaseMovement h = other.GetComponent<Hero_BaseMovement>();	
			h.setPlayerControl(false);
			CameraFollow c = camera.GetComponent<CameraFollow>();
			c.setCameraStop(true);
			begin = true;
		}
	}

	void FixedUpdate(){
		if (begin) {
				CameraFollow c = camera.GetComponent<CameraFollow> ();
				if (c.move (transform.position)) {
						begin = false;
						movePlayer = true;
				}
		
		} else if (movePlayer) {
			control_camera h = player.GetComponent<control_camera> ();
				if (h.moveLeft (playerDes.transform.position)) {
						movePlayer = false;
						end = true;
				}
		} else if (end) {
			CameraFollow c = camera.GetComponent<CameraFollow> ();
			if (c.move (carmeraDes.transform.position)) {
				end =  false;
				Hero_BaseMovement h = player.GetComponent<Hero_BaseMovement> ();
				h.setPlayerControl(true);
			}
		
		}


	}
}
