using UnityEngine;
using System.Collections;

public class Hero_backup : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				Gravity g = GetComponent<Gravity> ();		
				HeroAnimation a = GetComponent<HeroAnimation> ();
				if (Input.GetKeyDown (KeyCode.Space)) {
						g.setSpeed (new Vector3 (0, 2f, 0));
				} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
						g.setSpeed (new Vector3 (2.0f, 0, 0));
				} else if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
						a.play (HeroAnimation.Animation_e.stand, HeroAnimation.Direction_e.left);
						g.setSpeed (new Vector3 (0, 0, 0));
				} else if (Input.GetKey (KeyCode.LeftArrow)) {
						g.setSpeed (new Vector3 (-0.3f, 0, 0));
						a.play (HeroAnimation.Animation_e.walk, HeroAnimation.Direction_e.left);
				} 

		}

		void FixedUpdate ()
		{


		}

		void OnTriggerEnter2D (Collider2D other)
		{
				print ("run into somethin" + other.tag);

		}
}
