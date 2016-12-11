using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleTween : ObjectTween {

	public float Duration = 0.5f;

	public bool Auto;
	public float MinStep;
	public float MaxStep;

	Sequence _seq;

	void Start() {
		if( Auto ) {
			gameObject.SetActive(false);
			_seq = DOTween.Sequence();
			_seq.AppendInterval(Random.Range(MinStep, MaxStep));
			_seq.AppendCallback(() => transform.localScale = Vector3.one);
			_seq.AppendCallback(OnShow);
			_seq.AppendInterval(Random.Range(MinStep, MaxStep));
			_seq.AppendCallback(OnHide);
			_seq.SetLoops(-1);
		}
	}

	void OnDestroy() {
		if( _seq != null ) {
			_seq.Kill();
		}
	}

	public override void OnShow() {
		if( !gameObject.activeSelf ) {
			gameObject.SetActive(true);
		}
		var collider = GetComponent<Collider>();
		if( collider ) {
			collider.enabled = false;
		}
		var scale = transform.localScale;
		transform.localScale = Vector3.zero;
		transform.DOScale(scale, Duration).
		SetEase(Ease.InElastic).
		OnComplete(() => {
			if( collider ) { 
				collider.enabled = true; 
			}
		}
		);
	}

	public override void OnHide() {
		var collider = GetComponent<Collider>();
		if( collider ) {
			collider.enabled = false;
		}
		transform.DOScale(0, Duration).
		SetEase(Ease.InElastic).
		OnComplete(() => gameObject.SetActive(false));
	}
}
