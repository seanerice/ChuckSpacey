using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		OSCHandler.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetScore(int i) {
		List<object> l = new List<object>();
		l.Add(i);
		OSCHandler.Instance.SendMessageToClient("PD", "/Spacey/PD/Score", l);
	}
}
