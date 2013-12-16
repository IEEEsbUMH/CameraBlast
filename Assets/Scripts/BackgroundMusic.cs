//Coded by Luis Fletcher
using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

	public AudioSource backgroundMusic;

	// Update is called once per frame
	void FixedUpdate () {
	
		if (!backgroundMusic.isPlaying) {
						backgroundMusic.Play ();
				}

	}
}
