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

	// Use this for initialization
	void Start () {
		SetScore(0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = transform.forward;
		Vector3 right = transform.right;
		transform.position += dir * Time.deltaTime * Speed;
		IsRotating = false;


		if (Input.GetKey(KeyCode.D)) {
			transform.eulerAngles += new Vector3(0, Time.deltaTime * Speed, 0);
			IsRotating = true;
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.eulerAngles -= new Vector3(0, Time.deltaTime * Speed, 0);
			IsRotating = true;
		}
		if (Input.GetKey(KeyCode.W)) {
			transform.eulerAngles += new Vector3(Time.deltaTime * Speed, 0, 0);
			IsRotating = true;
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.eulerAngles -= new Vector3(Time.deltaTime * Speed, 0, 0);
			IsRotating = true;
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


		if (IsRotating = true) {

		}
	}

	private void SetScore(int i) {
		Score = i;
		ScoreText.text = "Score: " + Score;
		// Send OSC message to PD
	}

	private void AddScore() {
		SetScore(Score + 1);
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
