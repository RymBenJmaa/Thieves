using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour {

	public AudioClip sound;
	private Button button{get { return GetComponent<Button> (); }}
	private AudioSource source{get { return GetComponent<AudioSource> (); }}
    public AudioMixer mixer;

	void Start () {
		gameObject.AddComponent<AudioSource> ();
        string _OutputMixer = "Buttons SFX";
        source.outputAudioMixerGroup = mixer.FindMatchingGroups(_OutputMixer)[0];
		source.clip = sound;
		source.playOnAwake = false;
		button.onClick.AddListener(() => PlaySound());
	}
	void PlaySound () {
		source.PlayOneShot(sound);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
