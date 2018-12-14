using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : MonoBehaviour {

	int[] Midi;
	int[][] MidiBank;

	int[] Attack;
	int[][] AttackBank;

	Stepper Stepper;
	Instrument Instrument;

	bool IsPlaying = true;

	int Steps = 16;
	int Bars = 4;

	int CurrBar = 0;

	// Use this for initialization
	void Start () {

		Midi = new int[Steps];
		MidiBank = new int[Bars][];
		for (int i = 0; i < MidiBank.Length; i++) {
			MidiBank[i] = new int[Steps];
		}

		Attack = new int[Steps];
		AttackBank = new int[Bars][];
		for (int i = 0; i < AttackBank.Length; i++) {
			AttackBank[i] = new int[Steps];
		}

		Stepper = GameObject.Find("Stepper").GetComponent<Stepper>();
		Instrument = gameObject.GetComponentInChildren<Instrument>();

		Stepper.OnStep += OnStep;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PlayNote(int midi) {
		Instrument.PlayNote(1, midi);
	}

	public void SetMidi(int[] midi) {
		if (midi.Length != Steps) {
			throw new System.Exception("Input array length must match numSteps");
		}

		Midi = midi;
	}

	public void SetAttack(int[] attack) {
		if (attack.Length != Steps) {
			throw new System.Exception("Input array length must match numSteps");
		}

		Attack = attack;
	}

	private void OnStep(int step) {
		if (IsPlaying) {
			if (step == 0) OnDownbeat();
			int a = Attack[step];
			int m = Midi[step];
			Debug.Log("Play Note " + m);
			if (a > 0)
				PlayNote(m);
		}
	}

	private void OnDownbeat() {
		CurrBar++;
		SetAttack(AttackBank[CurrBar % Bars]);
		SetMidi(MidiBank[CurrBar % Bars]);
	}

	public void LoadBank(int bar, int[] midi, int[] attack) {
		MidiBank[bar] = midi;
		AttackBank[bar] = attack;
	}
}
