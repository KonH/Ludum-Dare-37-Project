using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class SpellView : MonoBehaviour {

	public float Duration;

	Text _text;
	Sequence _seq;

	void Awake() {
		_text = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		SpellManager.Instance.OnSpellCast.AddListener(ShowSpellName);
	}
	
	public void ShowSpellName(string name) {
		if( _seq != null ) {
			_seq.Kill();
			_seq = null;
		}
		_seq = DOTween.Sequence();
		transform.localScale = Vector3.zero;
		gameObject.SetActive(true);
		_text.text = name;
		_seq.Append(transform.DOScale(1, Duration/2).SetEase(Ease.OutElastic));
		_seq.AppendInterval(Duration);
		_seq.Append(transform.DOScale(0, Duration/2).SetEase(Ease.InElastic));
	}
}
