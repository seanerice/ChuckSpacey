using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		OSCHandler.Instance.Init();
	}

	// Update is called once per frame
	void Update () {

	}

	public void QuitGame () {
		// save any game data here
		#if UNITY_EDITOR
			// Application.Quit() does not work in the editor so
			// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			UnityEngine.Application.Quit();
		#endif
	}

	public void SetScore(int i) {
		List<object> l = new List<object>();
		l.Add(i);
		OSCHandler.Instance.SendMessageToClient("PD", "/Spacey/PD/Score", l);
	}
}
