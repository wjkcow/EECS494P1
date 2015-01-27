using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {
	public int dir;
	public float reflect;

	// Use this for initialization
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Hero") {
			print ("wall!!");
			if ((transform.position.x - other.transform.position.x) * dir > 0){
				Vector3 temp = other.transform.position;
				temp.x = temp.x + reflect * dir;
				other.transform.position = temp;
			}
		}
	}
}
