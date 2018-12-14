using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepper : MonoBehaviour {

	public delegate void StepAction (int step);
	public event StepAction OnStep;

	ChuckEventListener StepEventListener;
	ChuckSubInstance myChuck;
	ChuckIntSyncer IsMetOn;
	ChuckIntSyncer Tempo;
	ChuckIntSyncer Step;

	int CurrStep = 0;

	public int Beats = 4;
	public int Bars = 4;

	void Start () {
		myChuck = GetComponent<ChuckSubInstance>();
		myChuck.RunCode(@"
			// Global Variables
			0 => global int isMetOn;
			120 => global int Tempo;
			0 => global int Step;
			
			// Global Events
			global Event StepEvent;
			global Event TempoEvent;

			// We can update metronome tempo by changing Tempo and then triggering TempoEvent
			125::ms => dur StepDur;

			fun void UpdateTempoEvent(Event e) {
				while(true) {
					e => now;
					(15*1000/Tempo $ int)::ms => StepDur;
					//<<<""Tempo set"", Tempo>> >;
				}
			}

			spork ~ UpdateTempoEvent(TempoEvent);
			
			// Metronome pulses
			BlowBotl bottle => ADSR env => dac;

			while( true )
			{
				StepEvent.broadcast();
				if (isMetOn) {
					1 => bottle.volume;
					0 => bottle.noiseGain;
					70 => Std.mtof => bottle.freq;
					env.set(100::ms, 250::ms, 0, 50::ms);
					env.keyOn();
					1 => bottle.noteOn;
				}
				StepDur => now;
			}
		");

		// Create event listener
		StepEventListener = gameObject.AddComponent<ChuckEventListener>();

		// Set even listener handlers
		StepEventListener.ListenForEvent(myChuck, "StepEvent", StepCallback);

		// Create value syncers
		IsMetOn = gameObject.AddComponent<ChuckIntSyncer>();
		Tempo = gameObject.AddComponent<ChuckIntSyncer>();
		Step = gameObject.AddComponent<ChuckIntSyncer>();

		// Start syncing
		IsMetOn.SyncInt(myChuck, "isMetOn");
		Tempo.SyncInt(myChuck, "Tempo");
		Step.SyncInt(myChuck, "Step");

		// Set initial params on metronome
		//MetOn();
		SetTempo(120);
	}

	// Update is called once per frame
	void Update () {
		//MetOn();
		//SetTempo(120);
	}

	public void MetOn () {
		IsMetOn.SetNewValue(1);
		//Debug.Log(IsMetOn.GetCurrentValue());
	}

	public void MetOff () {
		IsMetOn.SetNewValue(0);
		//Debug.Log(IsMetOn.GetCurrentValue());
	}

	public void SetTempo (int tempo) {
		Tempo.SetNewValue(tempo);
		myChuck.BroadcastEvent("TempoEvent");
		//Debug.Log(Tempo.GetCurrentValue());
	}

	private void StepCallback() {
		Debug.Log(CurrStep);
		OnStep(CurrStep);
		CurrStep = (CurrStep + 1) % 16;
	}
}
