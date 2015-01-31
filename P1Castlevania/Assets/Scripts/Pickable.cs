using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {
	public string kind = "Heart";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Hero") {
			other.GetComponent<Hero_pickitem>().pick(kind);
			Destroy(this.gameObject);
		}
	}


}
