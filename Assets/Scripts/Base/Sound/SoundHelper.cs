using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;

[RequireComponent(typeof(AudioSource))]
public class SoundHelper : MonoBehaviour {

	[System.Serializable]
	public class SoundHolder {
		public SoundType Type;
		public AudioClip Clip;
	}

	public List<SoundHolder> Clips = new List<SoundHolder>();

	AudioSource _source;
	AudioClip _current;

	void Start () {
		_source = GetComponent<AudioSource>();
	}

	AudioClip GetClip(SoundType type) {
		for( int i = 0; i < Clips.Count; i++ ) {
			if( Clips[i].Type == type ) {
				return Clips[i].Clip;
			}
		}	
		return null;
	}

	public void Play(SoundType type) {
		var clip = GetClip(type);
		if( clip != null ) {
			_source.clip = clip;
			_source.Play();
		}
	}
}
