using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChMoog : ChInstrument {

	// Use this for initialization
	void Start () {
		myChuck = GetComponent<ChuckSubInstance>();
		myChuck.RunCode(@"
			class Instrument {
				fun void playNote(float attack, int midiNote) {
				}
			}

			class MoogSynth extends Instrument {
				Moog moog => dac;
    
				fun void playNote(float attack, int midiNote) {
					64 => float filterQ;
					128 => float filterSweep;
					//Math.random2f( 0, 128 ) => float vol;
					//Math.random2f( 0, 128 ) => float vibratoFreq;
					//Math.random2f( 0, 128 ) => float vibratoGain;

					moog.controlChange( 2, filterQ);
					moog.controlChange( 4, filterSweep);
					//moog.controlChange( 11, vibratoFreq);
					//moog.controlChange( 1, vibratoGain);
					moog.controlChange( 128, 128);

					midiNote => Std.mtof => moog.freq;

					attack => moog.noteOn;
				}
			}

			// Global Variables
			120 => global int Tempo;
			global int midi0[16];
			global int pattern0[16];

			// Global Events
			global Event TempoEvent;
			global Event DownbeatEvent;
			global Event SetAttackPatternEvent;
			global Event SetMidiNotesEvent;

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

			int NoteOn[1][16];
			// Copy pattern data from the TempoEvent variable into the appropriate track using PatternIndex
			fun void SetAttackPattern(Event e) {
				while (true) {
					e => now;
					pattern0 @=> NoteOn[0];
				}
			}

			int Midi[1][16];
			// Copy pattern data from the TempoEvent variable into the appropriate track using PatternIndex
			fun void SetMidiNotes(Event e) {
				while (true) {
					e => now;
					midi0 @=> Midi[0];
				}
			}
			
			// Spork event handling threads
			spork ~ UpdateTempoEvent(TempoEvent);
			spork ~ DownBeatEvent(DownbeatEvent);
			spork ~ SetAttackPattern(SetAttackPatternEvent);
			spork ~ SetMidiNotes(SetMidiNotesEvent);

			0 => global int isPlaying;
			16 => int steps;
			0 => int currStep;

			MoogSynth ms1;

			// Loop forever
			while(true)
			{
				if (isPlaying) {
					NoteOn[0][currStep] => int atk;
					Midi[0][currStep] - 12 => int midi;
					if (atk > 0) {
						ms1.playNote(1, midi);
					}
					
					(currStep + 1) % steps => currStep;
					StepDur => now;
				} else {
					1::ms => now;
				}
			}
		");

		base.Init();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
