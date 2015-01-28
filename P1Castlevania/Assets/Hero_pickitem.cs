using UnityEngine;
using System.Collections;

public class Hero_pickitem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Pickable") {
			string k = other.gameObject.GetComponent<Pickable>().kind;
			print (k + " is picked");
		}
	}
}
