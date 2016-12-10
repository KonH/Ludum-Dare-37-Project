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

	void Animate() {
		if( _seq != null ) {
			_seq.Kill();
			_seq = null;
		}
		_seq = DOTween.Sequence();
		_text.text = "";
		for( int i = 0; i < _fullText.Length; i++ ) {
			char ch = _fullText[i];
			_seq.AppendCallback(() => _text.text += ch);
			_seq.AppendInterval(Interval);
		}
		_seq.AppendInterval(HideInterval);
		if( AutoHide ) {
			_seq.Append(transform.DOScale(0, 0.5f).SetEase(Ease.InElastic));
		}
		_seq.AppendCallback(() => OnHide.Invoke());
	}
}
