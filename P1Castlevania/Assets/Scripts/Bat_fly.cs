using UnityEngine;
using System.Collections;

public class Bat_fly : MonoBehaviour {
	private bool walk_left = true;
	private float height;
	public float range;
	public float max_up;
	public bool up = true;
	public Vector3 speed = new Vector3(-0.015f, 0.0f, 0.0f);
	// Use this for initialization
	void Start () {
		height = transform.position.y;
		if (GameObject.Find ("Hero").transform.position.x > transform.position.x) {
			walk_left = false;		
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!GetComponent<Enemy> ().start) {
			return;		
		}
		if(range < Mathf.Abs (height - transform.position.y) || (range - Mathf.Abs (height - transform.position.y)) < 0.01){
			if (height < transform.position.y){
				up = false;
				
			}
			else {
				up = true;
			}
		} 
		float uspeed = max_up * (range - Mathf.Abs (height - transform.position.y));
		if(!up){
			uspeed *= -1f;
		}
		speed.y = uspeed;
		if (walk_left) {
						transform.position = transform.position + speed;
				} else {
			transform.position = transform.position - speed;

		}
	}

	void Die(){
		Destroy (this.gameObject);
	}
}
