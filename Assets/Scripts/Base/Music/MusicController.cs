using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.SaveSystem;

public class MusicController : IMusic {

	MusicHelper _helper;

	public void Init() {
		_helper = UnityHelper.LoadPersistant<MusicHelper>("MusicHelper");
	}

	public void PostInit() {}

	public void SwitchState() {
		var node = Save.GetNode<SaveNode>();
		if( node == null ) {
			node = new SaveNode();
		}
		node.MusicEnabled = !node.MusicEnabled;
		Save.SaveNode(node);
		_helper.SetState(node.MusicEnabled);
	}

	public bool IsEnabled() {
		var node = Save.GetNode<SaveNode>();
		if( node != null ) {
			return node.MusicEnabled;
		}
		return true;
	}
}
