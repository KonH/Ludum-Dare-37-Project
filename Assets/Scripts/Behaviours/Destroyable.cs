using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour {
	public UnityEvent OnDamage;
	public UnityEvent OnDestroy;
	public float HP;
	public float MaxHP;

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
		HP -= value;
		if( HP < 0 ) {
			gameObject.SetActive(false);
			OnDestroy.Invoke();
		} else {
			OnDamage.Invoke();
		}
	}
}
