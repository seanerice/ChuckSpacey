using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChMetronome : MonoBehaviour {

	ChuckSubInstance myChuck;
	ChuckEventListener BeatEventListener;
	ChuckIntSyncer IsMetOn;
	ChuckIntSyncer Tempo;

	void Start () {
		myChuck = GetComponent<ChuckSubInstance>();
		myChuck.RunCode(@"
			// Global Variables
			0 => global int isMetOn;
			120 => global int Tempo;
			
			// Global Events
			global Event TempoEvent;
			global Event BeatEvent;

			// We can update metronome tempo by changing Tempo and then triggering TempoEvent
			500::ms => dur BeatDur;

			fun void UpdateTempoEvent(Event e) {
				while(true) {
					e => now;
					(60*1000/Tempo $ int)::ms => BeatDur;
					//<<<""Tempo set"", Tempo>>>;
				}
			}

			spork ~ UpdateTempoEvent(TempoEvent);
			
			// Metronome pulses
			BlowBotl bottle => ADSR env => dac;
			while( true )
			{
				BeatEvent.broadcast();
				if (isMetOn) {
					1 => bottle.volume;
					0 => bottle.noiseGain;
					70 => Std.mtof => bottle.freq;
					env.set(100::ms, 250::ms, 0, 50::ms);
					env.keyOn();
					1 => bottle.noteOn;
				}
				
				BeatDur => now;
			}
		");

		// Create event listener
		BeatEventListener = gameObject.AddComponent<ChuckEventListener>();

		// Set even listener handlers
		BeatEventListener.ListenForEvent(myChuck, "BeatEvent", BeatEventCallback);

		// Create value syncers
		IsMetOn = gameObject.AddComponent<ChuckIntSyncer>();
		Tempo = gameObject.AddComponent<ChuckIntSyncer>();

		// Start syncing
		IsMetOn.SyncInt(myChuck, "isMetOn");
		Tempo.SyncInt(myChuck, "Tempo");

		// Set initial params on metronome
		MetOn();
		SetTempo(120);
	}

	// Update is called once per frame
	void Update () {
		MetOn();
		SetTempo(120);
	}

	public void MetOn() {
		IsMetOn.SetNewValue(1);
		Debug.Log(IsMetOn.GetCurrentValue());
	}

	public void MetOff() {
		IsMetOn.SetNewValue(0);
		Debug.Log(IsMetOn.GetCurrentValue());
	}

	public void SetTempo(int tempo) {
		Tempo.SetNewValue(tempo);
		myChuck.BroadcastEvent("TempoEvent");
		Debug.Log(Tempo.GetCurrentValue());
	}

	private void BeatEventCallback() {
		Debug.Log("Beat");
	}
}
