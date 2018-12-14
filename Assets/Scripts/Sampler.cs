using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sampler : Instrument {
	public string Filename = "BassDrum.wav";

	// Use this for initialization
	void Start () {
		SetCode(@"
			class Instrument {
				fun void playNote(float attack, int midiNote) {
				}
			}

			class Sampler extends Instrument {
				SndBuf buf => dac;

				" + string.Format(@"
				me.dir() + ""{0}"" => buf.read;
				", Filename) + @"

				fun void playNote(float atk, int midi) {
					0 => buf.pos;
					1 => buf.rate;
					.9 => buf.gain;
				}
			}

			Sampler s;

			fun void playNote(Event e) {
				while (true) {
					e => now; 
					spork ~ s.playNote(1, 1);
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
		myChuck.BroadcastEvent("notePlayEvent");
	}
}
