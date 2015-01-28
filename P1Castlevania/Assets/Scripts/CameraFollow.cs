using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public bool stop = false;
	public Vector3 delta;
	public float speed = 1f;

	public bool move(Vector3 des){
		print ("moving!!!!!camera");
		float step = speed * Time.deltaTime;
		des.z = transform.position.z;
		des.y = transform.position.y;
		transform.position = Vector3.MoveTowards(transform.position, des, step);
		if (Mathf.Abs(transform.position.x - des.x) < 0.0005f)
						return true;
		return false;
	}

	public void setCameraStop(bool v){
		stop = v;
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			destination.y = transform.position.y;
			if (!stop)
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		} 
	}

}
