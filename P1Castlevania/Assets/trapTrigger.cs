using UnityEngine;
using System.Collections;

public class trapTrigger : MonoBehaviour {
	public GameObject pull_green;	
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Hero") {
			pull_green.GetComponent<pull_green>().triggering();
		}
	}
}
