using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public GameObject die_effect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void breakMe(){
		GameObject de =  (GameObject)Instantiate (die_effect, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
