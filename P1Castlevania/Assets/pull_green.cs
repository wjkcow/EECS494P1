using UnityEngine;
using System.Collections;

public class pull_green : MonoBehaviour {
	public float distance;
	public float time;
	private int phase = 0;

	void Update(){
		if (phase == 1) {
			Vector3 des = transform.position;
			des.y -= distance;
			float step = 1 * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, des, step);	
			if (Mathf.Abs(des.y - transform.position.y) < 0.02f)
				phase = 2;
		} else if (phase == 2){
			Vector3 des = transform.position;
			des.y += distance;
			float step = 1 * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, des, step);	
			if (Mathf.Abs(des.y - transform.position.y) < 0.02f)
				phase = 0;
		}

	
	}

	public void triggering(){
		if (phase == 0)
			phase = 1;
	}
}
