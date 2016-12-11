using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class PrintText : MonoBehaviour {

	public UnityEvent OnHide;

	public float Interval;
	public float HideInterval;
	public bool AutoHide;

	Text _text;
	string _fullText;
	string _tempText;
	Sequence _seq;

	string[] _names = {
		"Ben", 
		"The Wizard",
		"Mr. Wizard", 
		"The Big Boss"
	};
	string[] _replaces = {
		"<color=green>Ben</color>",
		"<color=blue>The Wizard</color>",
		"<color=blue>Mr. Wizard</color>",
		"<color=red>The Big Boss</color>"
	};

	void Awake() {
		_text = GetComponent<Text>();
		_fullText = _text.text;
	}

	public void SetText(string text) {
		_fullText = text;
		transform.localScale = Vector3.one;
		Animate();
	}

	void OnEnable() {
		Animate();
	}

	void OnDisable() {
		if( _seq != null ) {
			_seq.Kill();
			_seq = null;
		}
	}

	void Animate() {
		if( _seq != null ) {
			_seq.Kill();
			_seq = null;
		}
		_seq = DOTween.Sequence();
		_text.text = "";
		_tempText = "";
		for( int i = 0; i < _fullText.Length; i++ ) {
			char ch = _fullText[i];
			_seq.AppendCallback(() => { OnTextUpdate(ch); });
			_seq.AppendInterval(Interval);
		}
		_seq.AppendInterval(HideInterval);
		if( AutoHide ) {
			_seq.Append(transform.DOScale(0, 0.5f).SetEase(Ease.InElastic));
		}
		_seq.AppendCallback(() => OnHide.Invoke());
	}

	void OnTextUpdate(char ch) {
		_tempText += ch;
		var current = _tempText;
		for( int i = 0; i < _names.Length; i++ ) {
			current = current.Replace(_names[i], _replaces[i]);
		}
		_text.text = current;
	}
}
