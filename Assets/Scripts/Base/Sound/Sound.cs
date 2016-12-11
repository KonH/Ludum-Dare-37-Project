using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers;

public class Sound: ControllerHelper<ISound> {

	public static void Play(SoundType type) {
		if( Instance != null ) {
			Instance.Play(type);
		}
	}

	public static void SwitchState() {
		if ( Instance != null ) {
			Instance.SwitchState();
		}
	}

	public static bool IsEnabled() {
		if( Instance != null ) {
			return Instance.IsEnabled();
		}
		return false;
	}
}
