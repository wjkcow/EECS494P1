using UnityEngine;
using System.Collections;

public class leopard_trap : MonoBehaviour {
	public GameObject l;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.tag == "Hero") {
			if(l)
				l.GetComponent<Leopard>().start = true;
		} 
	}
}
