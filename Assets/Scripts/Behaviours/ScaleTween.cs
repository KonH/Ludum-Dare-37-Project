using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleTween : ObjectTween {

	public float Duration = 0.5f;

	public override void OnShow() {
		var scale = transform.localScale;
		transform.localScale = Vector3.zero;
		transform.DOScale(scale, Duration).
		SetEase(Ease.InElastic);
	}

	public override void OnHide() {
		transform.DOScale(0, Duration).
		SetEase(Ease.InElastic).
		OnComplete(() => gameObject.SetActive(false));
	}
}
