using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;

public class SpellManager : MonoBehaviour {

	public static SpellManager Instance;

	List<Spell> _spells = new List<Spell>();

	void Awake() {
		Instance = this;
		CreateSpells();
	}

	void AddSpell(string name, Action callback) {
		_spells.Add(new Spell(name, callback));
	}

	void CreateSpells() {
		AddSpell("Transform", Spell_Transform);
	}

	void Spell_Transform() {
		var om = ObjectManager.Instance;
		var sourceObj = RandomUtils.GetItem(RoomObject.Objects);
		if( sourceObj != null ) {
			var prefab = RandomUtils.GetItem(ObjectManager.Instance.Prefabs);
			om.TransformObject(sourceObj.gameObject, prefab);
		}
	}

	public void ApplySpell() {
		var spell = RandomUtils.GetItem(_spells);
		spell.Callback.Invoke();
	}
}
