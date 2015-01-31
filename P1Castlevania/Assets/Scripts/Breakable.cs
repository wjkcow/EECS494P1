using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {

	public GameObject die_effect;
	public GameObject Drop_item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void breakMe(){
		GameObject de =  (GameObject)Instantiate (die_effect, transform.position, Quaternion.identity);
		GameObject di =  (GameObject)Instantiate (Drop_item, transform.position, Quaternion.identity);

		Destroy(this.gameObject);
	}
}
