using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	Process pdProcess = new Process();

	// Use this for initialization
	void Start () {
		OSCHandler.Instance.Init();

		pdProcess = new Process();
		pdProcess.StartInfo.FileName = @"C:\Program Files\Pd\bin\pd";
		pdProcess.StartInfo.Arguments = @"-open ""C:\Users\Sean Rice\Source\Repos\PDWorkspace\Main.pd"""; //argument
		pdProcess.StartInfo.UseShellExecute = false;
		pdProcess.StartInfo.RedirectStandardOutput = true;
		pdProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		pdProcess.StartInfo.CreateNoWindow = false; //not diplay a windows
		pdProcess.Start();
		//pdProcess.Exited = System.EventHandler(Application.Quit(), null);
		//pdProcess.WaitForInputIdle(1000);
	}

	// Update is called once per frame
	void Update () {
		if (pdProcess.HasExited) {
			QuitGame();
		}
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
