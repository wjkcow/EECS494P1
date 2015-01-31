using UnityEngine;
using System.Collections;

public class Hero_pickitem : MonoBehaviour {
	public GameObject canvas;
	private GlobalV globalV;
	// Use this for initialization
	void Start () {
		globalV = canvas.GetComponent<GlobalV> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Pickable") {
			string k = other.gameObject.GetComponent<Pickable>().kind;
			print (k + " is picked   " + this.tag + this.name);
			if (other.name == "Heart(Clone)")
				globalV.hearts ++;

		}
	}
}
