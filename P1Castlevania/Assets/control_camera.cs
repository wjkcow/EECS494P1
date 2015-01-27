using UnityEngine;
using System.Collections;

public class control_camera : MonoBehaviour {
	public GameObject camera;
	private Animator anim;
	public float speed = 1f;
	void Start(){
		anim = GetComponent<Animator> ();
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "camera_wall") {
			wall_v wall_value = other.GetComponent<wall_v>();
			CameraFollow script =	camera.GetComponent<CameraFollow>();	
			if ((transform.position.x - other.transform.position.x) * wall_value.dir_left > 0)
				script.setCameraStop(false);
			else 
				script.setCameraStop(true);
		}
	}

	public bool moveLeft(Vector3 des){
		print ("moveLeft");
		anim.SetBool ("Walk", true);
		float step = speed * Time.deltaTime;
		des.z = transform.position.z;
		des.y = transform.position.y;
		transform.position = Vector3.MoveTowards(transform.position, des, step);
		if (Mathf.Abs(transform.position.x - des.x) < 0.005f) {
			anim.SetBool ("Walk", false);
			return true;
		}
		return false;
	}
}
