using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GlobalV : MonoBehaviour {
	public int score = 0;
	public int time = 270;
	public int stage = 1;
	public int playerLife = 15;
	public int enemyLife = 15;
	public int hearts = 0;
	public int P = 1;
	public GameObject heartT;
	public GameObject PT;
	public GameObject scoreT;
	public GameObject timeT;
	public GameObject stageT;
	public GameObject playerT;
	public GameObject enemyT;
	public float mytime;


	// Use this for initialization
	void Start () {
		mytime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerLife <= 0) {
			P --;
			print ("start over");
		}
		if (P == 0) {
			print ("Game Over");		
		}
		PT.GetComponent<Text> ().text = String.Concat("--- " , P);
		heartT.GetComponent<Text> ().text = String.Concat("--- " , hearts);
		scoreT.GetComponent<Text> ().text = String.Concat("SCORE --- " , score);
		timeT.GetComponent<Text> ().text = String.Concat("TIME   " , time);
		stageT.GetComponent<Text> ().text = String.Concat("STAGE   " , stage);
		playerT.GetComponent<Text> ().text = String.Concat("PLAYER    " , playerLife);
		enemyT.GetComponent<Text> ().text = String.Concat("ENEMY    " , enemyLife);
		if (mytime + 1 < Time.time) {
			mytime = Time.time;	
			time --;
		}
	}
}
