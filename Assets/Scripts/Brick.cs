using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public GameObject smoke;
	public AudioClip Crack;
	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public static int brickCount = 0;
	bool isBreakable;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		isBreakable = (this.tag == "breakable");
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		if (isBreakable) {
			brickCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			AudioSource.PlayClipAtPoint (Crack, transform.position, 100f);
		}
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			brickCount--;
			levelManager.BrickDestroyed ();
			smoke.GetComponent<ParticleSystem> ().startColor = this.GetComponent<SpriteRenderer> ().color;
			GameObject smokeClone =  Instantiate (smoke, this.transform.position, Quaternion.identity) as GameObject;
			Destroy (gameObject);
			Destroy (smokeClone, 2f);
		} else {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
		}
	}

	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}
