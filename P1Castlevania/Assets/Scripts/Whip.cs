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
			print (other.tag + " sfsdfsdf");
			if (other.tag == "Breakable") {
				other.GetComponent<Breakable>().breakMe();
			} else if(other.tag == "Enemy"){
				if (other.name != "Boss"){
					Enemy otherScript = other.GetComponent<Enemy>();
					otherScript.hitten();
					globalV.score += otherScript.score;
				} else {
					bossAI script = other.GetComponent<bossAI>();
					script.hitten();
				}
			} else if (other.tag == "Kirby"){
				print ("hit kirby");
				Kirby scriptK = other.GetComponent<Kirby>();
				if (scriptK)
					scriptK.hitten();
			}
		}

	}
}

