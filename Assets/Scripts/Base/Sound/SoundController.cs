using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;

public enum SoundType {
	Click
}

public class SoundController : ISound {

	SoundHelper _helper;

	public void Init() {
		_helper = UnityHelper.LoadPersistant<SoundHelper>("SoundHelper");
	}

	public void PostInit() {}

	public void Play(SoundType type) {
		_helper.Play(type);
	}
}
