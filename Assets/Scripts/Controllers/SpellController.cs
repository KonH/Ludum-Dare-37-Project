using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {
	public float Interval;
	[HideInInspector]
	public float NormalizedTime;

	float _timer;

	void Update () {
		if( Game.IsAutoSpellsEnabled() ) {
			_timer += Time.deltaTime;
			NormalizedTime = _timer / Interval;
			if( _timer > Interval ) {
				_timer = 0;
				ApplySpell();
			}
		} else {
			_timer = 0;
			NormalizedTime = 0;
		}
	}

	void ApplySpell() {
		SpellManager.Instance.ApplySpell();
	}
}
