using UnityEngine;
using System.Collections;

public class doorTrigger : MonoBehaviour {
	public GameObject door;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Knife") {
			door.GetComponent<greenDoor>().triggering();
			Destroy(other.gameObject);
		}
	}
}
