using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.UI.Common;

public class MusicToggle : ActionButton {

	public override bool IsVisible() {
		return true;
	}

	public override bool IsInteractable() {
		return true;
	}

	public override void OnClick() {
		Music.SwitchState();
	}
}
