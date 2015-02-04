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
	public int num;
	public bool breakable;
	private float time;
	// Use this for initialization
	void start(){
		g = GetComponent<Gravity> ();
		time = Time.time;
	}

	void Update(){
		g = GetComponent<Gravity> ();
		if (!hasSet) {
			if (facingLeft){
				Vector3 tmp = vel;
				tmp.x = vel.x * -1;
				g.setSpeed(tmp);
				flip ();
			}
			else {
				g.setSpeed(vel);
			}
			g.setAcc(acc);
			hasSet = true;
		}
		if (transform.position.y < -5) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		canvas = GameObject.Find("Canvas");
		globalV = canvas.GetComponent<GlobalV> ();
		if (other.tag == "Breakable") {
						print ("hit");
						other.GetComponent<Breakable> ().breakMe ();
						if (breakable)
								Destroy (gameObject);
				} else if (other.tag == "Enemy") {
						Enemy otherScript = other.GetComponent<Enemy> ();
						if (other.name != "Boss")
								otherScript.hitten ();
						else {
								bossAI script = other.GetComponent<bossAI> ();
								script.hitten ();
						}
						globalV.score += otherScript.score;
						print (globalV.score + "  " + otherScript.score);
						if (breakable)
								Destroy (gameObject);

		} else if(other.tag == "Wall"){
			print (other.tag);
			if (breakable)
				Destroy(gameObject);
		}
	}

	void flip ()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	

}
