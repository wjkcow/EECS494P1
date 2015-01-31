using UnityEngine;
using System.Collections;

public class Whip : MonoBehaviour {
	public bool whipping = false;
	public GameObject canvas;
	private GlobalV globalV;

	// Use this for initialization
	void Start () {
		globalV = canvas.GetComponent<GlobalV> ();
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
				Enemy otherScript = other.GetComponent<Enemy>();
				otherScript.hitten();
				globalV.score += otherScript.score;
				print(globalV.score +"  " + otherScript.score);
			}
		}

	}
}

