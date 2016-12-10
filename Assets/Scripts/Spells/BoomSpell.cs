using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoomSpell : MonoBehaviour {
	public float MaxDamage;
	public float SizeTime;

	float _startTime;
	Light _light;

	void Awake() {
		_light = GetComponentInChildren<Light>();
		_startTime = Time.time;
		var endScale = transform.localScale;
		transform.localScale = Vector3.zero;
		transform.DOScale(endScale, SizeTime).
		SetEase(Ease.OutBounce).
		OnComplete(() => OnComplete());
		var endIntensity = _light.intensity;
		_light.intensity = 0;
		_light.DOIntensity(endIntensity, SizeTime);
	}
		
	void OnCollisionEnter(Collision other) {
		var go = other.gameObject;
		var destroyable = go.GetComponent<Destroyable>();
		var coeff = 1 - (Time.time - _startTime) / SizeTime;
		if( destroyable ) {
			destroyable.GiveDamage(MaxDamage * coeff);
		}
	}

	void OnComplete() {
		GetComponent<Collider>().enabled = false;
		transform.DOScale(0, SizeTime/2);
		_light.DOIntensity(0, SizeTime/3);
	}
}
