using UnityEngine;
using System.Collections;

public class Hero_pickitem : MonoBehaviour {
	public GameObject canvas;
	private GlobalV globalV;
	public GameObject[] items;
	private UsingItem u;
	private int whipNum = 0;
	private Animator anim;
	public AudioClip pickHeart;
	public AudioClip pickItem;
	// Use this for initialization
	void Start () {
		globalV = canvas.GetComponent<GlobalV> ();
		u = GetComponent<UsingItem> ();
		anim = GetComponent<Animator> ();
	}

	public void pick(string name){
		if (name == "Heart"){
			globalV.hearts ++;
			GameObject.Find("SoundEffect").audio.PlayOneShot (pickHeart, 1.0f);
		}
		else if (name == "Whip"){
			whipNum ++;
			print("whip");
			GameObject.Find("SoundEffect").audio.PlayOneShot (pickItem, 1.0f);
			if (whipNum <= 2)
				anim.SetInteger("WhipState", whipNum);		
		} else if (name == "Money"){
			globalV.score += 100;
		} else if (name == "BigMoney"){
			globalV.score += 700;
		} 
		else {
			foreach(GameObject g in items){
				print (g.tag + "   " + name);
				GameObject.Find("SoundEffect").audio.PlayOneShot (pickItem, 1.0f);
				if (g.tag == name){
					u.item = g;
					globalV.itemNum = g.GetComponent<usedItem>().num;
					break;
				}
			}
		}
	}
}
