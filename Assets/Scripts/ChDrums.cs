using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChDrums : MonoBehaviour {

	ChuckSubInstance myChuck;
	ChuckEventListener BeatEventListener;
	ChuckIntSyncer Tempo;
	ChuckIntSyncer PatternIndex;

	public string[] Filenames;

	void Start () {
		myChuck = GetComponent<ChuckSubInstance>();
		myChuck.RunCode(@"
			// Global Variables
			120 => global int Tempo;
			0 => int PatternIndex;
			global int TempPattern[16];
			
			// Global Events
			global Event TempoEvent;
			global Event DownbeatEvent;
			global Event SetAttackPatternEvent;

			// We can update metronome tempo by changing Tempo and then triggering TempoEvent
			125::ms => dur StepDur;

			fun void UpdateTempoEvent(Event e) {
				while(true) {
					e => now;
					(1000*60/Tempo/4 $ int)::ms => StepDur;
					//<<<""Tempo set"", Tempo>>>;
				}
			}

			fun void DownBeatEvent(Event e) {
				while (true) {
					e => now;
					// something here
				}
			}

			int NoteOn[12][16];
			fun void SetAttackPattern(Event e) {
				while (true) {
					e => now;
					TempPattern @=> NoteOn[PatternIndex];
					<<<NoteOn[0][0]>>>;
				}
			}

			spork ~ UpdateTempoEvent(TempoEvent);
			spork ~ DownBeatEvent(DownbeatEvent);
			spork ~ SetAttackPattern(SetAttackPatternEvent);
			
			// Sampler
			SndBuf buffers[12];

			// Read samples from file
			" + string.Format(@"
			me.dir() + ""{0}.wav""	=> buffers[0].read;
			me.dir() + ""{1}.wav""	=> buffers[1].read;
			me.dir() + ""{2}.wav""	=> buffers[2].read;
			me.dir() + ""{3}.wav""	=> buffers[3].read;
			me.dir() + ""{4}.wav""	=> buffers[4].read;
			me.dir() + ""{5}.wav""	=> buffers[5].read;
			me.dir() + ""{6}.wav""	=> buffers[6].read;
			me.dir() + ""{7}.wav""	=> buffers[7].read;
			me.dir() + ""{8}.wav""	=> buffers[8].read;
			me.dir() + ""{9}.wav""	=> buffers[9].read;
			me.dir() + ""{10}.wav""	=> buffers[10].read;
			me.dir() + ""{11}.wav""	=> buffers[11].read;
			", Filenames) + @"

			// Set properties of the buffers
			for (0 => int i; i < 12; i++) {
				0 => buffers[i].pos;
				1 => buffers[i].rate;
				.9 => buffers[i].gain;
				buffers[i] => dac;
			}

			1 => int isPlaying;
			16 => int steps;
			0 => int currStep;
			while(true)
			{
				if (isPlaying) {
					for (0 => int i; i < 12; i++) {
						NoteOn[i][currStep] => int atk;
						if (atk > 0) {
							0 => buffers[i].pos;
						}
					}

					(currStep + 1) % steps => currStep;
					StepDur => now;
				} else {
					1000::ms => now;
				}
			}
		");

		// Create value syncers
		Tempo = gameObject.AddComponent<ChuckIntSyncer>();
		PatternIndex = gameObject.AddComponent<ChuckIntSyncer>();

		// Start syncing
		Tempo.SyncInt(myChuck, "Tempo");
		PatternIndex.SyncInt(myChuck, "PatternIndex");

		// Set initial params
		SetTempo(120);
	}

	// Update is called once per frame
	void Update () {
		SetAttackPattern(0, new long[] { 1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0 });
		SetTempo(120);
	}

	public void SetTempo (int tempo) {
		Tempo.SetNewValue(tempo);
		myChuck.BroadcastEvent("TempoEvent");
		Debug.Log(Tempo.GetCurrentValue());
	}

	public void SetAttackPattern(int index, long[] AttackPattern) {
		PatternIndex.SetNewValue(index);
		myChuck.SetIntArray("TempPattern", AttackPattern);
		myChuck.BroadcastEvent("SetAttackPatternEvent");
	}
}
