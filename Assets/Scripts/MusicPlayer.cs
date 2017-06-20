using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer mbox = null;
	// Use this for initialization
	void Awake () {
		if (mbox != null) {
			GameObject.Destroy (gameObject);
			print ("delduplicated");
		} else {
			mbox = this;
			GameObject.DontDestroyOnLoad(gameObject);	
		}
	}

	void Start () {
		print ("error");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
