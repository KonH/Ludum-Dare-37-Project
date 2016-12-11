using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDamagable : MonoBehaviour {
	
	public float Damage;
	public float Cooldown;

	public UnityEvent OnAttack;

	float _lastDamageTime;

	void Start() {
	}

	bool CanDamage() {
		return enabled && (Time.time > (_lastDamageTime + Cooldown));
	}

    void OnCollisionStay(Collision other) {
		if( CanDamage() ) {
			TryToGiveDamage(other.gameObject);
		}
    }

	void TryToGiveDamage(GameObject go) {
		var destroyable = go.GetComponent<Destroyable>();
		if( destroyable ) {
			destroyable.GiveDamage(Damage);
			_lastDamageTime = Time.time;
			OnAttack.Invoke();
		}
	}
}
