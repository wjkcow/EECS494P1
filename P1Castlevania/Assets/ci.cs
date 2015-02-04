using UnityEngine;
using System.Collections;

public class ci : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other){
		
		if (other.tag == "Hero") {
			print ("hit hero");
			other.GetComponent<Hero_hitten>().hitten(this.transform.position.x);		
		}
	}
}
