using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluteSynth : Instrument {

	// Use this for initialization
	void Start () {
		SetCode(@"
			class Instrument {
				fun void playNote(float attack, int midiNote) {
				}
			}
			
			class FluteSynth extends Instrument {
				BlowHole hole => ADSR env => dac;

				0.3 => hole.reed;
				0.5 => hole.noiseGain;
				1 => hole.tonehole;
				0 => hole.vent;
				1 => hole.pressure;

				.8 => hole.noteOn;

				fun void playNote(float atk, int midi) {
					env.set(100::ms, 250::ms, 0, 0::ms);
					midi => Std.mtof => hole.freq;
					env.keyOn();
				}
			}

			50 => global int midi;
			FluteSynth s;
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
		MidiNote.SetNewValue(midi-12);
		myChuck.BroadcastEvent("notePlayEvent");
	}
}
