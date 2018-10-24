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

	// Use this for initialization
	void Start () {
		Rot = transform.localEulerAngles;
		RestAngles = transform.localEulerAngles;
		RotTo = transform.localEulerAngles;
	}

	// Update is called once per frame
	void Update () {
		Vector3 RotTo = RestAngles;

		if (Input.GetKey(KeyCode.D)) {
			RotTo += new Vector3(0, RotAmt, 0);
		} else if (Input.GetKey(KeyCode.A)) {
			//transform.eulerAngles -= new Vector3(0, Time.deltaTime * Speed, 0);
			RotTo -= new Vector3(0, RotAmt, 0);
		}
		if (Input.GetKey(KeyCode.W)) {
			//transform.eulerAngles += new Vector3(Time.deltaTime * Speed, 0, 0);
			RotTo += new Vector3(RotAmt, 0, 0);
		} else if (Input.GetKey(KeyCode.S)) {
			//transform.eulerAngles -= new Vector3(Time.deltaTime * Speed, 0, 0);
			RotTo -= new Vector3(RotAmt, 0, 0);
		}

		//RotTo = new Vector3(Mathf.Repeat(RotTo.x, 360), Mathf.Repeat(RotTo.y, 360), Mathf.Repeat(RotTo.z, 360));
		Vector3 diff = (RotTo - Rot) * Time.deltaTime * 2;
		Vector3 RotFin = Rot + diff;
		transform.localEulerAngles = RotFin;
		Rot = RotFin;
	}


	private Vector3 Slerp (Vector3 start, Vector3 end, float t) {
		float x = Mathf.SmoothStep(start.x, end.x, t);
		float y = Mathf.SmoothStep(start.y, end.y, t);
		float z = Mathf.SmoothStep(start.z, end.z, t);
		return new Vector3(x, y, z);
	}
}
