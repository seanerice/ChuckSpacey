using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : Node {

	public float cutoff = 100;
	public float peak = 1;

	public AudioPath Path;
	Transform outlet;

	// Filter Params
	ChuckFloatSyncer CutoffFreq;
	ChuckFloatSyncer Peak;

	GameObject Obj;

	// Use this for initialization
	new void Start () {
		base.Start();
		Obj = gameObject.GetComponentInChildren<Transform>().gameObject;
		ChuckSub = gameObject.GetComponentInParent<ChuckSubInstance>();
		string uvar = ChuckSub.GetUniqueVariableName("_");
		Name = "lpf" + uvar;
		Debug.Log(ChuckSub);
		ChuckSub.RunCode(string.Format(@"
			5000 => global float cutoff{0};
			1 => global float peak{0};

			LPF lpf;
			lpf @=> AudioPath.nodes[""lpf{0}""];
			dac @=> UGen @ out;
			UGen @ in;

			while(true) {{
				cutoff{0} => lpf.freq;
				peak{0} => lpf.Q;
				100::ms => now;
			}}
		", uvar));

		CutoffFreq = gameObject.AddComponent<ChuckFloatSyncer>();
		CutoffFreq.SyncFloat(ChuckSub, "cutoff"+uvar);

		Peak = gameObject.AddComponent<ChuckFloatSyncer>();
		Peak.SyncFloat(ChuckSub, "peak"+uvar);

		SetCutoff(cutoff);
		SetPeak(peak);
		Debug.Log(cutoff);
	}

	// Update is called once per frame
	void Update () {
		float scale = Mathf.Log10(cutoff);
		Obj.transform.localScale = new Vector3(scale, 1, scale);
		Obj.transform.localEulerAngles = new Vector3(0, (peak-2) * 50, 0);
		//SetCutoff(cutoff);
		//SetPeak(peak);
	}

	public void SetCutoff(float c) {
		cutoff = Mathf.Clamp(c, 100, 3000);
		CutoffFreq.SetNewValue(cutoff);
	}

	public void SetPeak(float p) {
		peak = Mathf.Clamp(p, 0.1f, 5);
		Peak.SetNewValue(p);
	}
}
