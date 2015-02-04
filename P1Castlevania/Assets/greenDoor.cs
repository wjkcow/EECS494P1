using UnityEngine;
using System.Collections;

public class greenDoor : MonoBehaviour {
	public float distance;
	private float time;
	public int phase = 0;
	private Vector3 des;
	public bool needTrigger;
	public float speed = 1;
	public float duration;
	// Update is called once per frame
	void Update(){
		if (phase == 1) {
			des = transform.position;
			des.y -= distance;
			phase = 2;
		} else if (phase == 2){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, des, step);
			time = Time.time;
			if (Mathf.Abs(des.y - transform.position.y) < 0.02f)
				phase = 3;
		} else if (phase == 3){
			if (time + duration < Time.time){
				des = transform.position;
				des.y += distance;
				phase = 4;
			}
		} else if (phase == 4){
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, des, step);	
			if (Mathf.Abs(des.y - transform.position.y) < 0.02f){
				if (!needTrigger)
					phase = 1;
				else 
					phase = 0;
			}
		}
		
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Axe_t") {
			Destroy(other.gameObject);		
		} 
	}
	
	public void triggering(){
		if (phase == 0)
			phase = 1;
	}
}
