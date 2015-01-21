using UnityEngine;
using System.Collections;

public class Whip : MonoBehaviour {
	public bool whipping = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if (whipping) {	
			if (other.tag == "Item") {
				print ("hit");
				other.GetComponent<Item>().breakMe();
			} else if(other.tag == "Enemy"){
				
			}
		}

	}
}

