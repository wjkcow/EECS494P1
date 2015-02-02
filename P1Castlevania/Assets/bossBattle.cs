using UnityEngine;
using System.Collections;

public class bossBattle : MonoBehaviour {
	public GameObject wall;
	// Use this for initialization
	void Start () {
		wall.SetActive (false);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		wall.SetActive (true);
	}
}
