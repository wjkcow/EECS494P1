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
			if (other.tag == "Breakable") {
				print ("hit");
				other.GetComponent<Breakable>().breakMe();
			} else if(other.tag == "Enemy"){
				other.GetComponent<Enemy>().hitten();
			}
		}

	}
}

