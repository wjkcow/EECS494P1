using UnityEngine;
using System.Collections;

public class UsingItem : MonoBehaviour {

	public  GameObject item;
	public GameObject muzzle;
	private float lastUseTime;
	public float useInterval;
	private Animator anim;
	private Hero h;
	public GameObject canvas;
	private GlobalV globalV;
	public AudioClip useItemSound;

	void Start(){
		lastUseTime = Time.time;
		anim = GetComponent<Animator> ();
		h = GetComponent<Hero> ();
		globalV = canvas.GetComponent<GlobalV> ();

	}

	public void getItem(GameObject _item){
		item = _item;
	}

	public void usingItem(){
		Instantiate (item.gameObject, muzzle.transform.position, Quaternion.identity);
	}

	void Update(){
		if (item) {
			if (Input.GetKey (KeyCode.UpArrow) && Input.GetKeyDown (KeyCode.X)) {
				print ("get input");
				if (globalV.hearts > 0){
					if (Time.time > lastUseTime + useInterval){
						if (item.GetComponent<usedItem>().thrownItem){
							shoot ();
						} else {
							use();
						}
						GameObject.Find("SoundEffect").audio.PlayOneShot (useItemSound, 1.0f);
						lastUseTime = Time.time;
						globalV.hearts --;
					}	
				}
			}
		}
	}

	void use(){

	}

	void shoot(){
		print ("start to throw");
		anim.SetBool ("Walk", false);
		anim.SetTrigger("Throw");
	}

	void shootHelper(){
		print ("throw once");
		GameObject newBullet =  (GameObject)Instantiate (item, muzzle.transform.position, Quaternion.identity);
		newBullet.GetComponent<usedItem> ().facingLeft = h.facingLeft;
	}
}
