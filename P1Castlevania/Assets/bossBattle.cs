using UnityEngine;
using System.Collections;

public class bossBattle : MonoBehaviour {
	public GameObject wall;
	public GameObject boss;
	private bool once = true;
	// Use this for initialization
	void Start () {
		wall.SetActive (false);
		boss.SetActive (false);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (once){
			wall.SetActive (true);
			boss.SetActive (true);
			boss.GetComponent<bossAI> ().reset ();
			once = false;
		}
	}
}
