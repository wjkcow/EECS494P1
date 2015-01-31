using UnityEngine;
using System.Collections;

public class Leopard : MonoBehaviour
{
		public Vector3 rightSpeed = new Vector3 (0.012f, 0, 0);
		public Vector3 jump = new Vector3 (-0.01f, 1.8f, 0);
		public bool walk_left = true;
		private Gravity g;
		private Animator anim;
		private bool jumping = false;

		// Use this for initialization
		void Start ()
		{
				if (!walk_left) {
						flip ();
				}
				g = GetComponent<Gravity> ();
				anim = GetComponent<Animator> ();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
		if (!GetComponent<Enemy> ().start) {
			return;		
		}
				if (jumping) {
						return;		
				}
				if (walk_left) {
						transform.position = transform.position - rightSpeed;
				} else {
						transform.position = transform.position + rightSpeed;
				}
		}

		void flip ()
		{
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (jumping) {
						if (other.tag == "Ground" && other.transform.position.y + 0.08 < transform.position.y) {
								flip ();
								walk_left = !walk_left;
								anim.SetTrigger ("Run");
								jumping = false;
						}
				}

		}

		void OnTriggerExit2D (Collider2D other)
		{
				if (jumping) {
						return;		
				}
				if (other.tag == "Ground") {
						if (walk_left) {
								jump.x = - Mathf.Abs (jump.x);
						} else {
								jump.x = Mathf.Abs (jump.x);

						}
						g.setSpeed (jump);
						anim.SetTrigger ("Jump");
						jumping = true;
				}

		}
}
