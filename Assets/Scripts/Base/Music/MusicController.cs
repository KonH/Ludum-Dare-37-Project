using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;

public class MusicController : IMusic {

	public void Init() {
		UnityHelper.LoadPersistant<MusicHelper>("MusicHelper");
	}

	public void PostInit() {}
}
