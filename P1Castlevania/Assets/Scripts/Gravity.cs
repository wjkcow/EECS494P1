using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{

		public Vector3 g = new Vector3 (0, -6f, 0);
		public bool still = false;
		public bool landByYourself = false;
		public Vector3 speed = Vector3.zero;
		public Vector3 acc = Vector3.zero;
		public float landDelta = 0.0105f;

	
		// Use this for in =itialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
		}

		public void setAcc (Vector3 newAcc)
		{

				this.acc = newAcc;
		}

		public void setSpeed (Vector3 newSpeed)
		{

				this.speed = newSpeed;
				FixedUpdate ();
		}

		void FixedUpdate ()
		{
				if (still)
						return;
				float dt = Time.fixedDeltaTime;

				Vector3 curPos = this.transform.position;
				Vector3 curAcc = acc + g;
				speed = speed + dt * curAcc;

				Vector3 nextPos = curPos + speed * dt;
				rigidbody2D.MovePosition (nextPos);
			
		
		}

	public void gTrigger(Collider2D other){
		OnTriggerEnter2D (other);
	}
//		void OnTriggerStay2D (Collider2D other)
//		{
//				OnTriggerEnter2D (other);
//		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (still || landByYourself)
						return;

				if (other.tag == "Ground") {
			//print ("delta" + (transform.position.y - other.transform.position.y ));
						if (other.transform.position.y < transform.position.y + 0.07) {
								speed = new Vector3 (0, 0, 0);
								acc = -1 * g;
							if(landDelta > 0){
								Vector3 pos = transform.position;
								pos.y = other.transform.position.y + landDelta; // measured
								transform.position = pos;
							}	
						}
				} 
		}

		void OnTriggerExit2D (Collider2D other)
		{
				if (still || landByYourself) {
						return;
				}
				if (other.tag == "Ground") {
						if (other.transform.position.y < transform.position.y) {
								acc = Vector3.zero;
						}
				} 
		}
	
}
