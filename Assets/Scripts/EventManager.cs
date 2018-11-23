using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
	public delegate void BeatAction ();
	public static event BeatAction OnBeat;

	public delegate void DownBeatAction ();
	public static event DownBeatAction OnDownbeat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
