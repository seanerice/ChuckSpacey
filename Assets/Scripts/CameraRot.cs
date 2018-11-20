using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour {

	public float smoothTime = 0.5f;

	private Vector3 vel;
	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref vel, smoothTime, 100, Time.deltaTime);
		transform.LookAt(target.position + target.forward, target.up);
	}
}
