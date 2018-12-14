using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	ChuckMainInstance ChuckMain;
	ChuckSubInstance ChuckSub;

	Camera camera;
	Vector3 PlanePoint;
	Transform target, dragTarget, paramTarget;
	Transform targetS, targetE;

	RaycastHit hit;
	RaycastHit hit2;

	int PlaneMask;
	int TargetMask;

	public GameObject AudioGenObj;
	public GameObject FiltObj;
	public GameObject Output;

	// Use this for initialization
	void Start () {
		ChuckMain = GetComponent<ChuckMainInstance>();
		ChuckSub = GetComponent<ChuckSubInstance>();

		camera = Camera.main;

		PlaneMask = LayerMask.GetMask("plane");
		TargetMask = LayerMask.GetMask("chuckable");
	}

	// Update is called once per frame
	void Update () {
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100f, PlaneMask)) {
			PlanePoint = hit.point;
		}

		Ray ray2 = camera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray2, out hit2, 100f, TargetMask)) {
			target = hit2.transform;
		} else {
			target = null;
		}

		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Mouse0)) {
			paramTarget = target;
		} else if (Input.GetKey(KeyCode.LeftControl)) {
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				targetS = target;
			}
			if (Input.GetKeyUp(KeyCode.Mouse0)) {
				targetE = target;
				ConnectTargets();
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				dragTarget = target;
			}
		}

		if (Input.GetKeyUp(KeyCode.Mouse0)) {
			dragTarget = null;
			paramTarget = null;
		}

		if (dragTarget != null) {
			dragTarget.position = PlanePoint;
		}
		if (paramTarget != null) {
			float dx = Input.GetAxis("Mouse X");
			float dy = Input.GetAxis("Mouse Y");

			Filter f = paramTarget.GetComponentInParent<Filter>();
			if (f != null) {
				f.SetCutoff(f.cutoff + dx * 100);
				f.SetPeak(f.peak + dy * .1f);
			}
		}

		// Spawn an audio generator, which is a path
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			GameObject obj = Instantiate(AudioGenObj, PlanePoint, Quaternion.identity);
			//obj.GetComponent<AudioPath>().SetOutlet(Output.transform);
		}

		// Spawn a filter node
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			GameObject obj = Instantiate(FiltObj, PlanePoint, Quaternion.identity);
		}
	}

	void ConnectTargets() {
		Debug.Log(targetS);
		Debug.Log(targetE);
		if (targetS != null && targetE != null && targetS != targetE) {
			Node ns = targetS.GetComponent<Node>();
			Node ne = targetE.GetComponent<Node>();
			if (ns != null && ne != null) {
				ns.Out(ne);
			}
		}
	}
}
