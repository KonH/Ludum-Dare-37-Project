using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;

[RequireComponent(typeof(AudioSource))]
public class MusicHelper : MonoBehaviour {
	
	public List<AudioClip> Clips = new List<AudioClip>();

	AudioSource _source;
	AudioClip _current;

	void Start () {
		_source = GetComponent<AudioSource>();
	}

	void Update() {
		if( !_source.isPlaying ) {
			PlayNewTrack();
		}
	}

	void PlayNewTrack() {
		var newTrack = RandomUtils.GetItem(Clips);
		if( newTrack == _current ) {
			PlayNewTrack();
		} else {
			_current = newTrack;
			_source.clip = _current;
			_source.Play();
		}
	}
}
