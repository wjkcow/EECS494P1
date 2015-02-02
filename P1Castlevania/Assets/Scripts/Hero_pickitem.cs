using UnityEngine;
using System.Collections;

public class Hero_pickitem : MonoBehaviour {
	public GameObject canvas;
	private GlobalV globalV;
	public GameObject[] items;
	private UsingItem u;
	// Use this for initialization
	void Start () {
		globalV = canvas.GetComponent<GlobalV> ();
		u = GetComponent<UsingItem> ();
	}

	public void pick(string name){
		if (name == "Heart")
			globalV.hearts ++;
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
