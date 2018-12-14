using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPath : MonoBehaviour {

	public GameObject[] Path;
	ChuckSubInstance ChuckSub;

	// Use this for initialization
	void Start () {
		ChuckSub = gameObject.GetComponent<ChuckSubInstance>();
		ChuckSub.RunCode(@"
			public class AudioPath {
				static UGen @ nodes[];

				fun static void SetIn(string prevIn, string in, string n) {
					if (prevIn != """") {
						nodes[prevIn] =< nodes[n];
					}
					nodes[in] => nodes[n];
				}

				fun static void SetOut(string n, string prevOut, string out) {
					if (prevOut != """") {
						nodes[n] =< nodes[prevOut];
					}
					nodes[n] => nodes[out];
				}
			}
			UGen nodes[0] @=> AudioPath.nodes;
			while (true) {
				1::second => now;
			}
		");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			BuildGraph();
		}
	}

	public void BuildGraph() {
		for (int i = 0; i < Path.Length; i++) {
			Node n = Path[i].GetComponent<Node>();
			if (i < Path.Length - 1) {
				Node next = Path[i + 1].GetComponent<Node>();
				n.Out(next);
			}
			if (i > 0) {
				Node prev = Path[i - 1].GetComponent<Node>();
				n.In(prev);
				Debug.Log(prev);
			}
		}
	}
}
