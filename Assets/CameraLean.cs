using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLean : MonoBehaviour {
	public float RotAmt = 5;

	public Vector3 StartRot;
	
	private float TimeX = 0, TimeY = 0, TimeZ = 0;
	private bool countX = false, countY = false, countZ = false;

	// Use this for initialization
	void Start () {
		StartRot = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (countX) {
			TimeX += Time.deltaTime;
		} else {
			TimeX -= Time.deltaTime;
		}

		if (countY) {
			TimeY += Time.deltaTime;
		} else {
			TimeY -= Time.deltaTime;
		}

		if (countZ) {
			TimeZ += Time.deltaTime;
		} else {
			TimeZ -= Time.deltaTime;
		}

		TimeX = Mathf.Clamp01(TimeX);
		TimeY = Mathf.Clamp01(TimeY);
		TimeZ = Mathf.Clamp01(TimeZ);


	}

	private Vector3 Slerp(Vector3 start, Vector3 end, float t) {
		float x = Mathf.SmoothStep(start.x, end.x, t);
		float y = Mathf.SmoothStep(start.y, end.y, t);
		float z = Mathf.SmoothStep(start.z, end.z, t);
		return new Vector3(x, y, z);
	}
}
