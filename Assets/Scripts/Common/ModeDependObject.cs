using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeDependObject : MonoBehaviour {

	public GameMode ForMode;

	void Awake () {
		var currentMode = Game.GetCurrentMode();
		gameObject.SetActive(currentMode == ForMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
