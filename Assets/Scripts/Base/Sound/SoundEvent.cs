using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEvent : MonoBehaviour {
	public bool PlayOnStart;

	AudioSource _source;
	float _lastTime;

	void Start() {
		_source = GetComponent<AudioSource>();
		if( PlayOnStart ) {
			Play();
		}
	}

	public void Play() {
		if( !Sound.IsEnabled() ) {
			return;
		}
		if( !_source.isPlaying && (_lastTime + _source.clip.length < Time.time) ) {
			_source.Play();
			_lastTime = Time.time;
		}
	}
}
