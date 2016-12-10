using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.UI.Common;

public class ModeSelectButton : ActionButton {

	public GameMode Mode;

	public override bool IsVisible() {
		return true;
	}

	public override bool IsInteractable() {
		return true;
	}

	public override void OnClick() {
		Game.SelectMode(Mode);
	}
}
