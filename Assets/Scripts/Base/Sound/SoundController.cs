using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.SaveSystem;

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
		if( IsEnabled() ) {
			_helper.Play(type);
		}
	}

	public void SwitchState() {
		var node = Save.GetNode<SaveNode>();
		if( node == null ) {
			node = new SaveNode();
		}
		node.SoundEnabled = !node.SoundEnabled;
		Save.SaveNode(node);
	}

	public bool IsEnabled() {
		var node = Save.GetNode<SaveNode>();
		if( node != null ) {
			return node.SoundEnabled;
		}
		return true;
	}
}
