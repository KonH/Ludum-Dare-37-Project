using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleTween : ObjectTween {

	public float Duration = 0.5f;

	public override void OnShow() {
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
