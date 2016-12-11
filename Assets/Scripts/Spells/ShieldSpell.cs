using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShieldSpell : MonoBehaviour {

	public GameObject Indicator;

	Sequence _seq = null;

	public void Setup(float time) {
		if( _seq != null ) {
			_seq.Kill();
			_seq = null;
		}
		_seq = DOTween.Sequence();
		StartEffect();
		_seq.AppendInterval(time);
		_seq.AppendCallback(EndEffect);
	}

	void StartEffect() {
		GetComponent<Destroyable>().CanDamage = false;
		Indicator.SetActive(true);
	}

	void EndEffect() {
		GetComponent<Destroyable>().CanDamage = true;
		Indicator.SetActive(false);
	}
}
