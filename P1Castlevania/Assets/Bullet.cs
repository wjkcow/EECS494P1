using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Vector3 speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + speed;
	}
}
