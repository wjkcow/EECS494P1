using UnityEngine;
using System.Collections;

public class Hero_pickitem : MonoBehaviour {
	public GameObject canvas;
	private GlobalV globalV;
	public GameObject[] items;
	private UsingItem u;
	private int whipNum = 0;
	private Animator anim;
	// Use this for initialization
	void Start () {
		globalV = canvas.GetComponent<GlobalV> ();
		u = GetComponent<UsingItem> ();
		anim = GetComponent<Animator> ();
	}

	public void pick(string name){
		if (name == "Heart")
			globalV.hearts ++;
		else if (name == "Whip"){
			whipNum ++;
			print("whip");
			if (whipNum <= 2)
				anim.SetInteger("WhipState", whipNum);		
		}
		else {
			foreach(GameObject g in items){
				print (g.tag + "   " + name);
				if (g.tag == name){
					u.item = g;
					globalV.itemNum = g.GetComponent<usedItem>().num;
					break;
				}
			}
		}
	}
}
