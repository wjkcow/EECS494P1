using UnityEngine;
using System.Collections;

public class UsingItem : MonoBehaviour {

	public  GameObject item;
	public GameObject muzzle;
	private float lastUseTime;
	public float useInterval;
	private Animator anim;
	private Hero h;

	void Start(){
		lastUseTime = Time.time;
		anim = GetComponent<Animator> ();
		h = GetComponent<Hero> ();
	}

	public void getItem(GameObject _item){
		item = _item;
	}

	public void usingItem(){
		Instantiate (item.gameObject, muzzle.transform.position, Quaternion.identity);
	}

	void FixedUpdate(){
		if (item) {
			if (Input.GetKey (KeyCode.UpArrow) && Input.GetKeyDown (KeyCode.Space)) {
				print ("get input");
				if (Time.time > lastUseTime + useInterval){
					if (item.GetComponent<usedItem>().thrownItem){
						shoot ();
					} else {
						use();
					}
					lastUseTime = Time.time;
				}	
			
			}
		}
	}

	void use(){
		//item.GetComponent<use>
	}

	void shoot(){
		print ("start to throw");
		anim.SetBool ("Walk", false);
		anim.SetTrigger("Throw");
		shootHelper ();
	}

	void shootHelper(){
		GameObject newBullet =  (GameObject)Instantiate (item, muzzle.transform.position, Quaternion.identity);
		newBullet.GetComponent<usedItem> ().facingLeft = h.facingLeft;
	}
}
