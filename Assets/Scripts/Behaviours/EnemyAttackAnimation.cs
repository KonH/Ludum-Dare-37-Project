using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAttackAnimation : MonoBehaviour {

	public float Duration;
	public Transform Left;
	public Transform Right;

	Sequence _seq;

	public void Animate() {
		if( _seq != null ) {
			_seq.Complete();
			_seq.Kill();
			_seq = null;
		}
		_seq = DOTween.Sequence();
		var leftOriginal = Left.localEulerAngles;
		var rightOriginal = Right.localEulerAngles;
		_seq.Append(Left.DOLocalRotate(Vector3.zero, Duration));
		_seq.Insert(0, Right.DOLocalRotate(Vector3.zero, Duration));
		_seq.Append(Left.DOLocalRotate(leftOriginal, Duration));
		_seq.Insert(Duration, Right.DOLocalRotate(rightOriginal, Duration));
	}
}
