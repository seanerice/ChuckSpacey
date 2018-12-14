using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChInstrument : MonoBehaviour {

	public delegate void LoadAction ();
	public event LoadAction OnLoad;

	protected ChuckMainInstance main;

	protected ChuckSubInstance myChuck;
	protected ChuckEventListener BeatEventListener;
	protected ChuckIntSyncer Tempo;
	protected ChuckIntSyncer PatternIndex;
	protected ChuckIntSyncer IsPlaying;
	protected ChuckEventListener LoadEventListener;

	public string[] Filenames;

	private bool PlayRequest = false;

	//protected void Start () {
	//	myChuck = GetComponent<ChuckSubInstance>();
	//	myChuck.RunCode(@"
	//		// Global Variables
	//		120 => global int Tempo;

	//		// Global Events
	//		global Event TempoEvent;
	//		global Event DownbeatEvent;

	//		// We can update metronome tempo by changing Tempo and then triggering TempoEvent
	//		125::ms => dur StepDur;

	//		//
	//		fun void UpdateTempoEvent(Event e) {
	//			while(true) {
	//				e => now;
	//				(1000*60/Tempo/4 $ int)::ms => StepDur;
	//				//<<<""Tempo set"", Tempo>>>;
	//			}
	//		}
			
	//		// Get the downbeat from ChMetronome and do something
	//		fun void DownBeatEvent(Event e) {
	//			while (true) {
	//				e => now;
	//				// something here
	//			}
	//		}
			
	//		// Spork event handling threads
	//		spork ~ UpdateTempoEvent(TempoEvent);
	//		spork ~ DownBeatEvent(DownbeatEvent);

	//		// Set properties of the buffers
	//		for (0 => int i; i < 12; i++) {
	//			0 => buffers[i].pos;
	//			1 => buffers[i].rate;
	//			.9 => buffers[i].gain;
	//			buffers[i] => dac;
	//		}
			
	//		0 => global int isPlaying;
	//		16 => int steps;
	//		0 => int currStep;

	//		// Loop forever
	//		while(true)
	//		{
	//			if (isPlaying) {
	//				Attack[currStep] => int atk;
	//				if (atk > 0) {
						
	//				}
			
	//				(currStep + 1) % steps => currStep;
	//				StepDur => now;
	//			} else {
	//				1::ms => now;
	//			}
	//		}
	//	");

	//	Init();
	//}

	protected void Init() {
		// Create value syncers
		Tempo = gameObject.AddComponent<ChuckIntSyncer>();
		IsPlaying = gameObject.AddComponent<ChuckIntSyncer>();
		LoadEventListener = gameObject.AddComponent<ChuckEventListener>();

		// Start syncing
		Tempo.SyncInt(myChuck, "Tempo");
		IsPlaying.SyncInt(myChuck, "isPlaying");
		LoadEventListener.ListenForEvent(myChuck, "LoadEvent", OnLoadEvent);

		// Subscribe the PlayOnBeat method to OnBeat event of ChMetronome
		ChMetronome.OnBeat += PlayOnBeat;
	}

	// Update is called once per frame
	void Update () {
		//SetAttackPattern(0, new long[] { 1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0 });
		SetTempo(120);
	}

	public void Play () {
		IsPlaying.SetNewValue(1);
	}

	public void Stop () {
		PlayRequest = false;
		IsPlaying.SetNewValue(0);
	}

	void OnLoadEvent() {
		OnLoad();
	}

	public void SetTempo (int tempo) {
		Tempo.SetNewValue(tempo);
		myChuck.BroadcastEvent("TempoEvent");
		//Debug.Log(Tempo.GetCurrentValue());
	}

	public void SetAttackPattern (int index, long[] AttackPattern) {
		//PatternIndex.SetNewValue(index);
		myChuck.SetIntArray("pattern" + index, AttackPattern);
		/*Debug.Log("Pattern = " + index + String.Join("",
			new List<long>(AttackPattern)
			.ConvertAll(j => j.ToString())
			.ToArray()));*/
		myChuck.BroadcastEvent("SetAttackPatternEvent");
	}

	public void SetMidiNotes (int index, long[] MidiNotes) {
		myChuck.SetIntArray("midi"+index, MidiNotes);
		myChuck.BroadcastEvent("SetMidiNotesEvent");
	}

	private void PlayOnBeat (int i) {
		if (PlayRequest) {
			//Debug.Log("Playing Drums " + i);
			IsPlaying.SetNewValue(1);
			PlayRequest = false;
		}
	}
}
