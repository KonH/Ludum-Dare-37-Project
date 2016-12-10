using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.E)) {
			ApplySpell();
		}
	}

	void ApplySpell() {
		SpellManager.Instance.ApplySpell();
	}
}
