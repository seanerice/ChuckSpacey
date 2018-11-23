using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MusicScore is a state machine which takes in a score and outputs a 
public class MusicScore : MonoBehaviour {
	ChMetronome Metronome;
	MultiBarTrack SamplerATrack;
	// MultiBarTrack SamplerBTrack;
	MultiBarTrack MoogTrack;

	// Use this for initialization
	void Start () {
		// Grab our sequencer instances
		Metronome = GameObject.Find("Metronome").GetComponent<ChMetronome>();
		SamplerATrack = GameObject.Find("SamplerATrack").GetComponent<MultiBarTrack>();
		MoogTrack = GameObject.Find("MoogTrack").GetComponent<MultiBarTrack>();

		// 
		Metronome.MetOff();

		Score(0);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Score(int s) {
		switch(s) {
			case 0:
				//MoogTrack.PlayOnDownbeat();
				//SamplerATrack.PlayOnDownbeat();
				// Load temp patterns into bank

				// Bar 1
				MoogTrack.SetMidiNotes(0, 0, new long[16]	{ 47, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				MoogTrack.SetPattern(0, 0, new long[16]		{ 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SamplerATrack.SetPattern(0, 0, new long[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SamplerATrack.SetPattern(0, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });
				//SamplerATrack.SetPattern(0, 2, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 });
				//SamplerATrack.SetPattern(0, 3, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				//SamplerATrack.SetPattern(0, 4, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });

				// Bar 2
				MoogTrack.SetMidiNotes(1, 0, new long[16] { 42, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				MoogTrack.SetPattern(1, 0, new long[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SamplerATrack.SetPattern(1, 0, new long[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
				SamplerATrack.SetPattern(1, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });
				//SamplerATrack.SetPattern(1, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				//SamplerATrack.SetPattern(1, 3, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				//SetPattern(1, 2, new long[16] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });

				// Bar 3
				MoogTrack.SetMidiNotes(2, 0, new long[16] { 40, 0, 43, 0, 47, 0, 57, 0, 55, 0, 40, 0, 43, 0, 47, 0 });
				MoogTrack.SetPattern(2, 0, new long[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				SamplerATrack.SetPattern(2, 0, new long[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SamplerATrack.SetPattern(2, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				//SamplerATrack.SetPattern(2, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				//SetPattern(2, 2, new long[16] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
				//SamplerATrack.SetPattern(2, 3, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });

				// Bar 4
				MoogTrack.SetMidiNotes(3, 0, new long[16] { 40, 0, 43, 0, 47, 0, 57, 0, 55, 0, 40, 0, 43, 0, 47, 0 });
				MoogTrack.SetPattern(3, 0, new long[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				SamplerATrack.SetPattern(3, 0, new long[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SamplerATrack.SetPattern(3, 1, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				//SamplerATrack.SetPattern(3, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				//SetPattern(3, 2, new long[16] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
				//SamplerATrack.SetPattern(3, 3, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				break;
			case 1:
				break;
			case 2:
				break;
			case 3:
				// Bar 1
				MoogTrack.SetMidiNotes(0, 0, new long[16] { 47, 0, 50, 0, 54, 0, 58, 0, 59, 0, 47, 0, 50, 0, 54, 0 });
				MoogTrack.SetPattern(0, 0, new long[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				SamplerATrack.SetPattern(0, 0, new long[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SamplerATrack.SetPattern(0, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });
				//SamplerATrack.SetPattern(0, 2, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 });
				//SamplerATrack.SetPattern(0, 3, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				//SamplerATrack.SetPattern(0, 4, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });

				// Bar 2
				MoogTrack.SetMidiNotes(1, 0, new long[16] { 42, 0, 45, 0, 49, 0, 54, 0, 57, 0, 42, 0, 45, 0, 49, 0 });
				MoogTrack.SetPattern(1, 0, new long[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				SamplerATrack.SetPattern(1, 0, new long[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
				SamplerATrack.SetPattern(1, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });
				//SamplerATrack.SetPattern(1, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				//SamplerATrack.SetPattern(1, 3, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				//SetPattern(1, 2, new long[16] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });

				// Bar 3
				MoogTrack.SetMidiNotes(2, 0, new long[16] { 40, 0, 43, 0, 47, 0, 57, 0, 55, 0, 40, 0, 43, 0, 47, 0 });
				MoogTrack.SetPattern(2, 0, new long[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				SamplerATrack.SetPattern(2, 0, new long[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SamplerATrack.SetPattern(2, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				//SamplerATrack.SetPattern(2, 1, new long[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				//SetPattern(2, 2, new long[16] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
				//SamplerATrack.SetPattern(2, 3, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });

				// Bar 4
				MoogTrack.SetMidiNotes(3, 0, new long[16] { 40, 0, 43, 0, 47, 0, 57, 0, 55, 0, 40, 0, 43, 0, 47, 0 });
				MoogTrack.SetPattern(3, 0, new long[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				SamplerATrack.SetPattern(3, 0, new long[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SamplerATrack.SetPattern(3, 1, new long[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				break;
		}
	}
}
