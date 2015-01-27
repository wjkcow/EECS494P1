using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject die_effect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void hitten(){
		GameObject de =  (GameObject)Instantiate (die_effect, transform.position, Quaternion.identity);
		Destroy(this.gameObject);

	}
	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "Hero") {
			print ("hit hero");
			other.GetComponent<Hero_hitten>().hitten(this.transform.position.x);		
		}
	}
		
}
