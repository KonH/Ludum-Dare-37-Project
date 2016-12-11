using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBonus : MonoBehaviour {

	public SpellType Spell;

	void OnCollisionEnter(Collision other) {
		if( other.gameObject.CompareTag("Player") ) {
			AddBonus();
			ObjectManager.Instance.TryHide(gameObject);
		}
	}

	void AddBonus() {
		SpellManager.Instance.ApplySpell(Spell);
	}
}
