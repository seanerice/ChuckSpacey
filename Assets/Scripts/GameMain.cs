using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour {

	public float Speed = 5;
	public float TurnSpeed = 10;

	private Text ScoreText;

	private int Score = 0;

	public Vector3 LowerBounds = new Vector3(-50, -50, -50);
	public Vector3 UpperBounds = new Vector3(50, 50, 50);

	private bool IsRotating = false;

	public ParticleSystem WarpParticles;

	private SoundManager SoundMan;

	private Vector3 curr;

	// Use this for initialization
	void Start () {
		ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		SoundMan = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		SetScore(0);
		curr = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = transform.forward;
		//Vector3 right = transform.right;
		transform.position += dir * Time.deltaTime * Speed;

		if (Input.GetKey(KeyCode.D)) {
			transform.RotateAround(transform.position, transform.up, Time.deltaTime * TurnSpeed * 2);
		}
		else if (Input.GetKey(KeyCode.A)) {
			transform.RotateAround(transform.position, transform.up, -Time.deltaTime * TurnSpeed * 2);
		}

		if (Input.GetKey(KeyCode.S)) {
			transform.RotateAround(transform.position, transform.right, -Time.deltaTime * TurnSpeed);
		}
		else if (Input.GetKey(KeyCode.W)) {
			transform.RotateAround(transform.position, transform.right, Time.deltaTime * TurnSpeed);
		}

		if (Input.GetKey(KeyCode.Q)) {
			transform.RotateAround(transform.position, transform.forward, Time.deltaTime * TurnSpeed);
		}
		else if (Input.GetKey(KeyCode.E)) {
			transform.RotateAround(transform.position, transform.forward, -Time.deltaTime * TurnSpeed);
		}

		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		if (x > UpperBounds.x) x = LowerBounds.x;
		if (x < LowerBounds.x) x = UpperBounds.x;
		if (y > UpperBounds.y) y = LowerBounds.y;
		if (y < LowerBounds.y) y = UpperBounds.y;
		if (z > UpperBounds.z) z = LowerBounds.z;
		if (z < LowerBounds.z) z = UpperBounds.z;
		transform.position = new Vector3(x, y, z);
	}

	private void SetScore(int i) {
		Score = i;
		ScoreText.text = "Score: " + Score;
		// Send OSC message to PD
		SoundMan.SetScore(Score);
	}

	private void AddScore() {
		SetScore(Score + 1);
		OSCHandler.Instance.SendMessageToClient("PD", "/Spacey/PD/pickup", "bang");
		switch (Score){
			default:
				break;
			case 1:
				break;
			case 2:
				break;
		}
	}

	private void OnCollisionEnter (Collision collision) {
		AddScore();
	}
}
