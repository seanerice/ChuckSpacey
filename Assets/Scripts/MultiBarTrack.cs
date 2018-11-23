using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBarTrack : MonoBehaviour {

	ChMetronome Metronome;
	ChInstrument Instrument;

	public long[][][] PatternBank;
	public long[][][] MidiNotes;

	private int Bars = 4;
	private int Voices = 12;
	private int StepsPerBar = 16;

	private int CurrBar = 0;

	public bool PlayReqDb = false, PlayReqB = false, IsPlaying = false;

	// Use this for initialization
	void Start () {
		// Grab our sequencer instances
		Metronome = GameObject.Find("Metronome").GetComponent<ChMetronome>();
		Instrument = gameObject.GetComponentInChildren<ChInstrument>();
		
		// Add our downbeat event trigger to the metronome object
		ChMetronome.OnDownBeat += this.OnDownBeat;

		// Create pattern bank
		InitPatternBank(Bars, Voices, StepsPerBar);
		InitMidiNotes(Bars, Voices, StepsPerBar);
	}

	// Update is called once per frame
	void Update () {
		//Instrument.SetAttackPattern(0, new long[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 });
		//LoadBar(0);
	}

	// Syntactic sugar
	private void InitPatternBank(int bars, int voices, int stepsPerBar) {
		Bars = bars;
		Voices = voices;
		StepsPerBar = stepsPerBar;

		PatternBank = new long[bars][][];
		for (int i = 0; i < bars; i++) {
			PatternBank[i] = new long[voices][];
			for (int j = 0; j < voices; j++) {
				PatternBank[i][j] = new long[stepsPerBar];
			}
		}
	}

	private void InitMidiNotes (int bars, int voices, int stepsPerBar) {
		Bars = bars;
		Voices = voices;
		StepsPerBar = stepsPerBar;

		MidiNotes = new long[bars][][];
		for (int i = 0; i < bars; i++) {
			MidiNotes[i] = new long[voices][];
			for (int j = 0; j < voices; j++) {
				MidiNotes[i][j] = new long[stepsPerBar];
			}
		}
	}

	public void LoadBar(int barIndex) {
		for (int i = 0; i < Voices; i++) {
			LoadVoice(barIndex, i);
		}
	}

	public void LoadVoice (int bar, int voice) {
		Instrument.SetAttackPattern(voice, PatternBank[bar][voice]);
		Instrument.SetMidiNotes(voice, MidiNotes[bar][voice]);
	}

	public void SetPattern(int bar, int voice, long[] pattern) {
		PatternBank[bar][voice] = pattern;
	}

	public void SetMidiNotes (int bar, int voice, long[] pattern) {
		MidiNotes[bar][voice] = pattern;
	}

	void OnDownBeat(int bar) {
		if (PlayReqDb) {
			PlayReqDb = false;
			IsPlaying = true;
			LoadBar(0);
			Instrument.Play();
		} else if (IsPlaying) {
			CurrBar = (CurrBar + 1) % Bars;
			LoadBar(CurrBar);
		}
		Debug.Log(CurrBar);
	}

	public void PlayOnDownbeat () {
		PlayReqDb = true;
	}
}
