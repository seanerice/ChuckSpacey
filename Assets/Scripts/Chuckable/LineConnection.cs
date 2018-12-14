using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnection : MonoBehaviour {

	Vector3[] Points = new Vector3[2];
	LineRenderer Line;
	Transform targetStart, targetEnd;

	// Use this for initialization
	void Start () {
		Line = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (targetStart != null && targetEnd != null) {
			SetPositions(targetStart.position, targetEnd.position);
		} else {
			SetPositions(gameObject.transform.position, gameObject.transform.position);
		}
		Line.SetPositions(Points);
	}

	void SetPositions(Vector3 start, Vector3 end) {
		Points[0] = start;
		Points[1] = end;
	}

	public void SetTarget(Transform ts, Transform te) {
		targetStart = ts;
		targetEnd = te;
	}
}
