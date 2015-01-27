using UnityEngine;
using System.Collections;

public class Item_Swing : MonoBehaviour {
	private float pos_x;
	public float range;
	public float max_left;
	public bool left = true;
	public Vector3 speed = new Vector3(0.0f, -0.01f, 0.0f);
	// Use this for initialization
	void Start () {
		pos_x = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(range < Mathf.Abs (pos_x - transform.position.x) || (range - Mathf.Abs (pos_x - transform.position.x)) < 0.1){
			if (pos_x < transform.position.x){
				left = false;
			}
			else {
				left = true;
			}
		} 
		float lspeed = max_left * (range - Mathf.Abs (pos_x - transform.position.x));
		if (left) {
			lspeed = -1.0f * Mathf.Abs (lspeed);
		} else {
			lspeed =  Mathf.Abs (lspeed);

		}
		speed.x = lspeed;
		print (lspeed);
		transform.position = transform.position + speed;
	}
	
	void Die(){
		Destroy (this.gameObject);
	}
}
