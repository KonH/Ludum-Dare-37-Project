using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellTimeView : MonoBehaviour {
	public SpellController Controller;

	Image _img;

	void Start() {
		_img = GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
		var value = Controller.NormalizedTime;
		_img.fillAmount = value;
	}
}
