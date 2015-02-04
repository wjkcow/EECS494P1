using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public Transform[] ghostsPos;
	public int  threshold;
	public int  coolDownTime = 70;
	public GameObject ghostPrefab;
	public int count;

	private bool active = false;
	private int coolDown_c;
	// Use this for initialization
	void Start () {
		coolDown_c = coolDownTime;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (!active) {
			return;		
		}
		coolDown_c --;
		if (coolDown_c == 0) {
			coolDown_c = coolDownTime;
			if(count == 0){
				for(int i = 0; i < ghostsPos.Length; i++){
					Transform pos = ghostsPos[i];
					if(Mathf.Abs( pos.position.x - GameObject.Find ("Hero").transform.position.x) > 0.2){
						GameObject e =  (GameObject)Instantiate (ghostPrefab, pos.position, Quaternion.identity);
						count ++;
						e.GetComponent<Enemy>().spawner = this.gameObject;
					}
				}
			}
			if(count < threshold){
				int idx = (int)Random.Range(0.0f, ghostsPos.Length - 1.0f);
				Transform pos = ghostsPos[idx];
				if(Mathf.Abs( pos.position.x - GameObject.Find ("Hero").transform.position.x) > 0.8){
					GameObject e =  (GameObject)Instantiate (ghostPrefab, pos.position, Quaternion.identity);
					count ++;
					e.GetComponent<Enemy>().spawner = this.gameObject;
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Hero") {
			coolDown_c = 10;
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Hero") {
			active = true;
		}
	}
	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Hero") {
			active = false;
		}
	}
}
