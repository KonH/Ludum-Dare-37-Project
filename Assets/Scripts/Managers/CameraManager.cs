using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
using DG.Tweening;

public class CameraManager : MonoBehaviour {
	public static CameraManager Instance;

	public float BackTime = 1f;
	public AutoCam Camera;

	Sequence _seq;

	void Awake() {
		Instance = this;
	}

	public void LookAt(Transform trans) {
		if( _seq != null ) {
			_seq.Kill();
			_seq = null;
		}
		_seq = DOTween.Sequence();
		Camera.SetTarget(trans);
		_seq.AppendInterval(BackTime);
		_seq.AppendCallback(() => Back());
	}

	void Back() {
		Camera.SetTarget(PlayerManager.Instance.PlayerTransform);
	}
}
