using UnityEngine;
using System.Collections;

public class usedItem : MonoBehaviour {
	public bool thrownItem = true;
	public bool facingLeft;
	public Vector3 vel;
	public Vector3 acc;
	private Gravity g;
	private bool hasSet = false;
	public GameObject canvas;
	private GlobalV globalV;
	// Use this for initialization
	void start(){
		g = GetComponent<Gravity> ();
		globalV = canvas.GetComponent<GlobalV> ();
	}

	void FixedUpdate(){
		g = GetComponent<Gravity> ();
		if (!hasSet) {
			if (facingLeft)
				g.setSpeed(-1 * vel);
			else 
				g.setSpeed(vel);
			g.setAcc(acc);
			hasSet = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Item") {
			print ("hit");
			other.GetComponent<Item>().breakMe();
		} else if(other.tag == "Enemy"){
			Enemy otherScript = other.GetComponent<Enemy>();
			otherScript.hitten();
			globalV.score += otherScript.score;
			print(globalV.score +"  " + otherScript.score);
		}
		
	}


}
