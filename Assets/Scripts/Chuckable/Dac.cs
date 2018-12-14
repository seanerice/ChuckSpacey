using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dac : Node {

	new void Start () {
		base.Start();
		ChuckSub = gameObject.GetComponentInParent<ChuckSubInstance>();
		string uvar = ChuckSub.GetUniqueVariableName("_");
		Name = "dac" + uvar;
		ChuckSub.RunCode(string.Format(@"
			dac @=> AudioPath.nodes[""dac{0}""];
			1::second => now;
		", uvar));
	}
}
