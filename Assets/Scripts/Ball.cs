using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Rigidbody2D rigitbody2D;
	private Paddle paddle;
	private Vector3 paddleToBall;
	private bool hasStarted = false;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBall = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasStarted == false) {
			this.transform.position = paddle.transform.position + paddleToBall;
		}
		if (Input.GetMouseButtonDown (0)) {
			hasStarted = true;
			rigitbody2D.velocity = new Vector2 (2f, 10f);
		}
	}

	void OnCollisionEnter2D (Collision2D collision2D) {
		Vector2 tweak = new Vector2 (Random.Range(0f, 2f), Random.Range(0f, 2f));
		if (hasStarted) {
			this.GetComponent<AudioSource> ().Play ();
			rigitbody2D.velocity += tweak;
		}
	}
}
