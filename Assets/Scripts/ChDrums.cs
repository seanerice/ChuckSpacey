using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChDrums : ChInstrument {

	void Start () {
		main = GetComponent<ChuckMainInstance>();
		myChuck = GetComponent<ChuckSubInstance>();
		myChuck.RunCode(@"
			// Global Variables
			120 => global int Tempo;
			0 => global int PatternIndex;
			global int pattern0[16];
			global int pattern1[16];
			global int pattern2[16];
			global int pattern3[16];
			global int pattern4[16];
			global int pattern5[16];
			global int pattern6[16];
			global int pattern7[16];
			global int pattern8[16];
			global int pattern9[16];
			global int pattern10[16];
			global int pattern11[16];

			// Global Events
			global Event TempoEvent;
			global Event DownbeatEvent;
			global Event SetAttackPatternEvent;

			// We can update metronome tempo by changing Tempo and then triggering TempoEvent
			125::ms => dur StepDur;

			//
			fun void UpdateTempoEvent(Event e) {
				while(true) {
					e => now;
					(1000*60/Tempo/4 $ int)::ms => StepDur;
					//<<<""Tempo set"", Tempo>>>;
				}
			}
			
			// Get the downbeat from ChMetronome and do something
			fun void DownBeatEvent(Event e) {
				while (true) {
					e => now;
					// something here
				}
			}

			int NoteOn[12][16];
			// Copy pattern data from the TempoEvent variable into the appropriate track using PatternIndex
			fun void SetAttackPattern(Event e) {
				while (true) {
					e => now;
					pattern0 @=> NoteOn[0];
					pattern1 @=> NoteOn[1];
					pattern2 @=> NoteOn[2];
					pattern3 @=> NoteOn[3];
					pattern4 @=> NoteOn[4];
					pattern5 @=> NoteOn[5];
					pattern6 @=> NoteOn[6];
					pattern7 @=> NoteOn[7];
					pattern8 @=> NoteOn[8];
					pattern9 @=> NoteOn[9];
					pattern10 @=> NoteOn[10];
					pattern11 @=> NoteOn[11];
				}
			}
			
			// Spork event handling threads
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
			
			0 => global int isPlaying;
			16 => int steps;
			0 => int currStep;

			// Loop forever
			while(true)
			{
				if (isPlaying) {
					<<<NoteOn[0][currStep], NoteOn[1][currStep], NoteOn[2][currStep], NoteOn[3][currStep]>>>;
					for (0 => int i; i < 12; i++) {
						NoteOn[i][currStep] => int atk;
						if (atk > 0) {
							0 => buffers[i].pos;
						}
					}
					
					(currStep + 1) % steps => currStep;
					StepDur => now;
				} else {
					1::ms => now;
				}
			}
		");

		Init();
		//base.Start();
	}

	new void Init() {
		base.Init();
	}

	// Update is called once per frame
	void Update () {
		// SetAttackPattern(0, new long[] { 1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0 });
		// SetTempo(120);
	}
}
