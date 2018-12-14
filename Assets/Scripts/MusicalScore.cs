using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalScore : MonoBehaviour {

	Sequencer BlitSawSeq;
	Sequencer FluteSeq;
	Sequencer BassDrumSeq, SnareSeq;

	// Use this for initialization
	void Start () {
		BlitSawSeq = GameObject.Find("BlitSawSeq").GetComponent<Sequencer>();
		BassDrumSeq = GameObject.Find("BassDrumSeq").GetComponent<Sequencer>();
		SnareSeq = GameObject.Find("SnareSeq").GetComponent<Sequencer>();
		FluteSeq = GameObject.Find("FluteSeq").GetComponent<Sequencer>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Score (int s) {
		switch (s) {
			case 0:
				// Bar 1
				BlitSawSeq.LoadBank(0, new int[16] { 35, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
										new int[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 2
				BlitSawSeq.LoadBank(1, new int[16] { 30, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
										new int[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 3
				BlitSawSeq.LoadBank(2, new int[16] { 28, 0, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
										new int[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 4
				BlitSawSeq.LoadBank(3, new int[16] { 28, 0, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
										new int[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				break;
			case 1:
				// Bar 1
				BlitSawSeq.LoadBank(0,	new int[16] { 35, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
										new int[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				FluteSeq.LoadBank(0,	new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 83, 0, 78, 0, 81, 0, 78, 0 }, 
										new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0 });

				// Bar 2
				BlitSawSeq.LoadBank(1, new int[16] { 30, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
										new int[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 3
				BlitSawSeq.LoadBank(2, new int[16] { 28, 0, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
										new int[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 4
				BlitSawSeq.LoadBank(3, new int[16] { 28, 0, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
										new int[16] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				break;
			case 2:
				// Bar 1
				BlitSawSeq.LoadBank(0, new int[16] { 47, 0, 50, 0, 54, 0, 58, 0, 59, 0, 47, 0, 50, 0, 54, 0 },
										new int[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				BassDrumSeq.LoadBank(0, new int[16], new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SnareSeq.LoadBank(0, new int[16], new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 2
				BlitSawSeq.LoadBank(1, new int[16] { 42, 0, 45, 0, 49, 0, 54, 0, 57, 0, 42, 0, 45, 0, 49, 0 },
										new int[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				BassDrumSeq.LoadBank(1, new int[16], new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
				SnareSeq.LoadBank(1, new int[16], new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 3
				BlitSawSeq.LoadBank(2, new int[16] { 40, 0, 43, 0, 47, 0, 57, 0, 55, 0, 40, 0, 43, 0, 47, 0 },
										new int[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				BassDrumSeq.LoadBank(2, new int[16], new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SnareSeq.LoadBank(2, new int[16], new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });

				// Bar 4
				BlitSawSeq.LoadBank(3, new int[16] { 40, 0, 43, 0, 47, 0, 57, 0, 55, 0, 40, 0, 43, 0, 47, 0 },
										new int[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				BassDrumSeq.LoadBank(3, new int[16], new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SnareSeq.LoadBank(3, new int[16], new int[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				break;
			case 3:
				// Bar 1
				BlitSawSeq.LoadBank(0, new int[16] { 47, 0, 50, 0, 54, 0, 58, 0, 59, 0, 47, 0, 50, 0, 54, 0 },
										new int[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				BassDrumSeq.LoadBank(0, new int[16], new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SnareSeq.LoadBank(0, new int[16], new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 2
				BlitSawSeq.LoadBank(1, new int[16] { 42, 0, 45, 0, 49, 0, 54, 0, 57, 0, 42, 0, 45, 0, 49, 0 },
										new int[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				BassDrumSeq.LoadBank(1, new int[16], new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 });
				SnareSeq.LoadBank(1, new int[16], new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 });

				// Bar 3
				BlitSawSeq.LoadBank(2, new int[16] { 40, 0, 43, 0, 47, 0, 57, 0, 55, 0, 40, 0, 43, 0, 47, 0 },
										new int[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				BassDrumSeq.LoadBank(2, new int[16], new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SnareSeq.LoadBank(2, new int[16], new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });

				// Bar 4
				BlitSawSeq.LoadBank(3, new int[16] { 40, 0, 43, 0, 47, 0, 57, 0, 55, 0, 40, 0, 43, 0, 47, 0 },
										new int[16] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 });
				BassDrumSeq.LoadBank(3, new int[16], new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				SnareSeq.LoadBank(3, new int[16], new int[16] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 });
				break;
		}
	}
}
