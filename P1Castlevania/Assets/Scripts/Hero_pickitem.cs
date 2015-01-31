using UnityEngine;
using System.Collections;

public class Hero_pickitem : MonoBehaviour {
	public GameObject canvas;
	private GlobalV globalV;
	// Use this for initialization
	void Start () {
		globalV = canvas.GetComponent<GlobalV> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void pick(string kind){
		if (kind == "Heart")
			globalV.hearts ++;
	}
}
