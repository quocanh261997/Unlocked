using UnityEngine;
using System.Collections;

public class PlayButtonSound : MonoBehaviour {
	AudioSource buttonSound;
	void Awake(){
		buttonSound = GameObject.Find ("ButtonSound").GetComponent<AudioSource> ();
	}
	public void Play(){
		buttonSound.Play ();
	}
}
