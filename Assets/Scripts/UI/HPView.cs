using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HPView : MonoBehaviour {

	Slider _slider;

	void Start() {
		_slider = GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update () {
		var value = PlayerManager.Instance.PlayerDestroyable.NormalizedHP;
		_slider.value = value;
	}
}
