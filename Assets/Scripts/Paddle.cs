using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoBot = false;
	private Ball ball;
	Vector3 paddlePos;
	// Use this for initialization
	void Start () {
		paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update () {
		if (!autoBot) {
			paddlePos.x = Mathf.Clamp (Input.mousePosition.x / Screen.width * 16, 0.7f, 15.3f);
			this.transform.position = paddlePos;
		} else {
			paddlePos.x = Mathf.Clamp (ball.transform.position.x, 0.7f, 15.3f);
			this.transform.position = paddlePos;
		}
	} 
}
