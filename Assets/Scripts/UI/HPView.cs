using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HPView : MonoBehaviour {

	Slider _slider;
	float  _prevValue;

	void Start() {
		_slider = GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update () {
		var value = PlayerManager.Instance.PlayerDestroyable.NormalizedHP;
		if( value < _prevValue ) {
			transform.localScale = Vector3.one;
			transform.DOShakeScale(0.25f, 0.5f, 5);
		}
		_slider.value = value;
		_prevValue = value;
	}
}
