using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour {
	public UnityEvent OnDamage;
	public UnityEvent OnDestroy;
	public float HP;
	public float MaxHP;
	public bool CanDamage = true;

	public float NormalizedHP {
		get {
			return HP / MaxHP;
		}
	}
	 
	// Use this for initialization
	void Start () {
		HP = MaxHP;
	}

	void OnDisable() {
		if( HP > 0 ) {
			OnDestroy.Invoke();
		}
	}
	
	public void GiveDamage(float value) {
		if( !CanDamage ) {
			return;
		}
		HP -= value;
		if( HP < 0 ) {
			ObjectManager.Instance.TryHide(gameObject);
			OnDestroy.Invoke();
		} else {
			OnDamage.Invoke();
		}
	}
}
