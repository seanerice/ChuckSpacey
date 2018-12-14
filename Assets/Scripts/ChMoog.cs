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
					0 => float filterQ;
					0 => float filterSweep;
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

			class Synth extends Instrument {

				BlitSaw osc1, osc2, osc3;

				// Envelope Generator
				250 => int attack;
				250 => int decay;
				1 => int sustain;
				ADSR env1, env2, env3;
				env1.set(attack::ms, decay::ms, 1, decay::ms);
				env2.set(attack::ms, decay::ms, 1, decay::ms);
				env3.set(attack::ms, decay::ms, 1, decay::ms);

				// Filter
				LPF lpf1, lpf2, lpf3;
				1 => float q;
				2500 => float cutoff;
				q => lpf1.Q;
				q => lpf2.Q;
				q => lpf3.Q;
				cutoff => lpf1.freq;
				cutoff => lpf2.freq;
				cutoff => lpf3.freq;
				0.5 => float egInt;

				osc1 => env1 => lpf1 => dac;
				osc2 => env2 => lpf2 => dac;
				osc3 => env3 => lpf3 => dac;

				fun void playNote(float atk, int midi) {
					 // Update filter values
					q => lpf1.Q;
					q => lpf2.Q;
					q => lpf3.Q;
					cutoff => lpf1.freq;
					cutoff => lpf2.freq;
					cutoff => lpf3.freq;
        
					// Update envelope generator values
					env1.set(attack::ms, decay::ms, 1, decay::ms);
					env2.set(attack::ms, decay::ms, 1, decay::ms);
					env3.set(attack::ms, decay::ms, 1, decay::ms);
        
					Std.mtof(midi) => osc1.freq;
        
					env1.keyOn();
					//env2.keyOn();
					//env3.keyOn();
					256 => int subintervals;
					if (subintervals > attack) {
						attack => subintervals;
					}
					for(0 => int i; i < subintervals; i++) {
						(attack/subintervals)::ms => now;
						10000*egInt*(i/(subintervals-1)$float)*egInt + cutoff => float f;
						f => lpf1.freq;
						f => lpf2.freq;
						f => lpf3.freq;
					}
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
			global Event LoadEvent;

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

			Synth ms1;

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

					if (currStep == steps - 1) {
						LoadEvent.broadcast();
					}

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
