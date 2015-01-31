using UnityEngine;
using System.Collections;

public class Hero_hitten : MonoBehaviour {
	public int immune_time = 100;
	public int blink_time = 10;
	public Vector3 up_speed = new Vector3 (0, 1, 0);
	public Vector3 left_speed = new Vector3 (-1, 0, 0);

	private int immune_c = 0;
	private int blink_c = 0;
	private Gravity g;
	private Animator anim;
	public GameObject canvas;
	private GlobalV globalV;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		g = GetComponent<Gravity> ();
		globalV = canvas.GetComponent<GlobalV> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (immune_c  > 0) {
			if (blink_c == 0) {
				GetComponent<SpriteRenderer> ().enabled = !GetComponent<SpriteRenderer> ().enabled ;
				blink_c = blink_time;
				
			}
			blink_c --;	
			immune_c --;
		}

	}
	public void hitten(float x){
		if (immune_c > 0) {
			return;
		}
		globalV.playerLife --;
			immune_c = immune_time;
		if (!GetComponent<Hero> ().isStairMode) {
			if(transform.position.x < x){
				GetComponent<Hero> ().setFaceLeft (false);
				g.setSpeed(up_speed + left_speed);
			} else {
				GetComponent<Hero> ().setFaceLeft (true);
				g.setSpeed(up_speed - left_speed);
			}
			anim.SetTrigger("Hit");	
			GetComponent<Hero> ().hitten = true;

		}


	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Ground") {
			print ("land");
			GetComponent<Hero> ().hitten = false;
		}

	}
}
