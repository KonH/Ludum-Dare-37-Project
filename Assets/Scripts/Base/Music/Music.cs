using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers;

public class Music: ControllerHelper<IMusic> {

	public static void SwitchState() {
		if( Instance != null ) {
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
