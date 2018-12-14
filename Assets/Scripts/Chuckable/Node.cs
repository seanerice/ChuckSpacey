using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour {
	protected LineConnection Line;
	public string Name;
	public Node inNode, outNode;
	protected ChuckSubInstance ChuckSub;

	protected void Start () {
		Line = gameObject.GetComponentInChildren<LineConnection>();
	}

	public void Out (Node n) {
		if (n == null) return;
		if (outNode == null) {
			Debug.Log(string.Format(@"AudioPath.SetOut(""{0}"", ""{1}"", ""{2}""); 1::ms => now;", Name, "", n.Name));
			ChuckSub.RunCode(string.Format(@"AudioPath.SetOut(""{0}"", ""{1}"", ""{2}""); 1::ms => now;", Name, "", n.Name));
		} else {
			ChuckSub.RunCode(string.Format(@"AudioPath.SetOut(""{0}"", ""{1}"", ""{2}""); 1::ms => now;", Name, outNode.Name, n.Name));
		}
		outNode = n;

		if (n.inNode != null)
			n.inNode.Line.SetTarget(null, null);
		Line.SetTarget(gameObject.transform, n.transform);
		//gameObject.GetComponentInChildren<LineConnection>().SetTarget(n.transform);
	}

	public void In (Node n) {
		if (n == null) return;
		if (inNode == null) {
			Debug.Log(string.Format(@"AudioPath.SetIn(""{0}"", ""{1}"", ""{2}""); 1::ms => now;", "", n.Name, Name));
			ChuckSub.RunCode(string.Format(@"AudioPath.SetIn(""{0}"", ""{1}"", ""{2}""); 1::ms => now;", "", n.Name, Name));
		} else {
			ChuckSub.RunCode(string.Format(@"AudioPath.SetIn(""{0}"", ""{1}"", ""{2}""); 1::ms => now;", inNode.Name, n.Name, Name));
		}
		inNode = n;
		//gameObject.GetComponentInChildren<LineConnection>().SetTarget(n.transform);
	}
}
