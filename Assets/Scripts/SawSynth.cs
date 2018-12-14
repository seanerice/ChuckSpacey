using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSynth : Instrument {

	// Use this for initialization
	void Start () {
		SetCode(@"
			class Instrument {
				fun void playNote(float attack, int midiNote) {
				}
			}

			class Synth extends Instrument {
				BlitSaw osc1, osc2, osc3;

				// Envelope Generator
				250 => int attack;
				250 => int decay;
				0 => int sustain;
				ADSR env1, env2, env3;
				env1.set(attack::ms, decay::ms, sustain, decay::ms);
				env2.set(attack::ms, decay::ms, sustain, decay::ms);
				env3.set(attack::ms, decay::ms, sustain, decay::ms);

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

					cutoff => lpf1.freq;

					
					// Update envelope generator values
					env1.set(100::ms, 500::ms, 0, 0::ms);

					Std.mtof(midi) => osc1.freq;

					env1.keyOn();

					1000::ms => now;
				}
			}

			50 => global int midi;
			Synth s;
			Shred notePlay;
			
			fun void playNote(Event e) {
				while (true) {
					e => now; 
					notePlay.exit();
					spork ~ s.playNote(1, midi) @=> notePlay;
				}
			}

			global Event notePlayEvent;

			spork ~ playNote(notePlayEvent);

			while(true) {
				1::second => now;
			}
		");

		Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void PlayNote (float attack, int midi) {
		MidiNote.SetNewValue(midi);
		myChuck.BroadcastEvent("notePlayEvent");
	}
}
