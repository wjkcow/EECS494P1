using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject die_effect;
	public bool start = false;
	public int score;
	public GameObject spawner; 
	public AudioClip brokenSound;
	private Gravity g;
//	public AudioSource brokenSound;
	// Use this for initialization
	void Start () {
		start = false;
		g = GetComponent<Gravity> ();
//		brokenSound = GetComponent<AudioSource> ();
	}

	
	// Update is called once per frame
	void Update () {
	
	}
	public void hitten(){
		GameObject de =  (GameObject)Instantiate (die_effect, transform.position, Quaternion.identity);
		if (spawner) {
			spawner.GetComponent<EnemySpawner>().count --;
		}
		print ("hitten");
	 	GameObject.Find("SoundEffect").audio.PlayOneShot (brokenSound, 1.0f);
		Destroy(this.gameObject);

	}

	void OnBecameInvisible() {
		enabled = false;
		if (spawner) {
			spawner.GetComponent<EnemySpawner>().count --;
		}		Destroy (this.gameObject);
	}
	void OnBecameVisible(){
		start = true;
	}
	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "Hero") {
			print ("hit hero");
			other.GetComponent<Hero_hitten>().hitten(this.transform.position.x);		
		}
	}
		
}
