using UnityEngine;
using System.Collections;

public class elevator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	
	}
	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Hero") {
			print ("in");
			Vector3 pos = other.transform.position;
			pos.y = transform.position.y;
			other.transform.position = pos;
		}
	}
}
