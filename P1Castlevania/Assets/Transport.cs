﻿using UnityEngine;
using System.Collections;

public class Transport : MonoBehaviour {
	public Vector3 delta;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		print ("HHHHHIT");
		if (other.tag == "TransportSurface") {
			Vector3 pos = transform.position + delta;
			pos.z = 0;
			print (pos);
			GameObject.Find("Hero").transform.position = pos;
			GameObject.Find("Hero").transform.GetComponent<Gravity>().setAcc(Vector3.zero);
			Destroy(this.gameObject);
		}
	}
}
