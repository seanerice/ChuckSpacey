using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGen : Node {

	public float Freq	{
		get { return Freq; }
		set { Freq = value; } 
	}

	public string Filename = "ArpLoop3_128_Cmin.wav";

	public float mult = 0.25f;
	string uvar;

	public long[] Pattern = new long[16];

	// Use this for initialization
	new void Start () {
		base.Start();
		ChuckSub = gameObject.GetComponentInParent<ChuckSubInstance>();
		uvar = ChuckSub.GetUniqueVariableName("_");
		Name = "buf" + uvar;
		ChuckSub.RunCode(string.Format(@"
			SndBuf buf;
			me.dir()+""{0}"" => buf.read;
			buf @=> AudioPath.nodes[""buf{1}""];
			16 => int steps;
			global int attackPattern{1}[steps];

			fun void start () {{
				0 => buf.pos;
				1 => buf.rate;
			}}

			fun void stop () {{
				0 => buf.rate;
				0 => buf.pos;
			}}

			stop();

			// Synchronize time to period
			1::second => dur T;
			T - (now % T) => now;

			0 => int currStep;  

			while(true) {{
				if (attackPattern{1}[currStep] > 0) {{
					start();
				}}
				({2})::T => now;
				(currStep+1) % steps => currStep;
			}}

		", Filename, uvar, mult));
		SetAttackPattern(Pattern);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SetAttackPattern (long[] AttackPattern) {
		ChuckSub.SetIntArray("attackPattern" + uvar, AttackPattern);
	}
}
