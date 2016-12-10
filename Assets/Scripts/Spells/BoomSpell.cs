using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoomSpell : MonoBehaviour {
	public float MaxDamage;
	public float SizeTime;

	float _startTime;

	void Awake() {
		_startTime = Time.time;
		var endScale = transform.localScale;
		transform.localScale = Vector3.zero;
		transform.DOScale(endScale, SizeTime).OnComplete(() => gameObject.SetActive(false));
	}
		
	void OnCollisionEnter(Collision other) {
		var go = other.gameObject;
		var destroyable = go.GetComponent<Destroyable>();
		var rb = go.GetComponent<Rigidbody>();
		var coeff = 1 - (Time.time - _startTime) / SizeTime;
		if( destroyable ) {
			destroyable.GiveDamage(MaxDamage * coeff);
		}
	}
}
