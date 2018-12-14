using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Instrument : MonoBehaviour {
	protected ChuckSubInstance myChuck;
	protected ChuckIntSyncer MidiNote;

	protected string Code = "";

	public void Init() {
		myChuck = gameObject.GetComponent<ChuckSubInstance>();

		// Add code to vm
		myChuck.RunCode(Code);

		// Create value syncers
		MidiNote = gameObject.AddComponent<ChuckIntSyncer>();

		// Start syncing
		MidiNote.SyncInt(myChuck, "midi");
	}

	public void SetCode(string code) {
		Code = code;
	}

	public abstract void PlayNote (float attack, int midi);
}
