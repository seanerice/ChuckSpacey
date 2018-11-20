using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpLean : MonoBehaviour {

	public float RotAmt = 5;

	//public Vector3 MaxRotAbs = new Vector3(10, 10, 10);
	//public Vector3 RotTo;

	public Vector3 RestAngles = Vector3.zero;
	public Vector3 RotTo = Vector3.zero;


	private float TimeX = 0, TimeY = 0, TimeZ = 0;
	private bool countX = false, countY = false, countZ = false;
	private Vector3 Rot;

	public float smoothTime = 0.5f;

	private Vector3 vel;
	private Transform target;

	// Use this for initialization
	void Start () {
		Rot = transform.localEulerAngles;
		RestAngles = transform.localEulerAngles;
		RotTo = transform.localEulerAngles;
		target = GameObject.Find("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref vel, smoothTime, 100, Time.deltaTime);
		transform.LookAt(target.position + target.forward);
	}


	private Vector3 Slerp (Vector3 start, Vector3 end, float t) {
		float x = Mathf.SmoothStep(start.x, end.x, t);
		float y = Mathf.SmoothStep(start.y, end.y, t);
		float z = Mathf.SmoothStep(start.z, end.z, t);
		return new Vector3(x, y, z);
	}
}
