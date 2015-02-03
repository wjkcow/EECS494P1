using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GlobalV : MonoBehaviour {
	public int score = 0;
	public int time = 270;
	public int stage = 1;
	public int playerLife = 16;
	public int enemyLife = 16;
	public int hearts = 0;
	public int P = 1;
	public GameObject heartT;
	public GameObject PT;
	public GameObject scoreT;
	public GameObject timeT;
	public GameObject stageT;
	public GameObject playerImage;
	public GameObject enemyImage;
	public float mytime;
	public Sprite[] Phealth;
	public Sprite[] Ehealth;
	public Sprite[] items;
	public GameObject Item;
	public int itemNum;
	public AudioClip lostLife;
	public GameObject H;

	// Use this for initialization
	void Start () {
		mytime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerLife < 0) {
			P --;
			H.GetComponent<Hero>().die();
			print ("start over");
			GameObject.Find("SoundEffect").audio.PlayOneShot (lostLife, 1.0f);
		}
		if (P == 0) {
			print ("Game Over");		
		}
		PT.GetComponent<Text> ().text = String.Concat("" , P);
		heartT.GetComponent<Text> ().text = String.Concat("" , hearts);
		scoreT.GetComponent<Text> ().text = String.Concat("" , score);
		timeT.GetComponent<Text> ().text = String.Concat("" , time);
		stageT.GetComponent<Text> ().text = String.Concat("" , stage);
		playerImage.GetComponent<Image> ().sprite = Phealth [playerLife];
		enemyImage.GetComponent<Image> ().sprite = Ehealth [enemyLife];
		Item.GetComponent<Image> ().sprite = items [itemNum];
 		if (mytime + 1 < Time.time) {
			mytime = Time.time;	
			time --;
		}
	}

	void updatePlayer(){



	}
}
