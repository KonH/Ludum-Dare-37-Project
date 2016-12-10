using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;
using DG.Tweening;

public class SpellManager : MonoBehaviour {

	public static SpellManager Instance;

	public float SizeDelta;
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
		AddSpell("MassTransform", Spell_MassTransform);
		AddSpell("Boom", Spell_Boom);
		AddSpell("Kaboom", Spell_Kaboom);
		AddSpell("RoomShake", Spell_RoomShake);
		AddSpell("FloorChange", Spell_FloorChange);
		AddSpell("MassFloorChange", Spell_MassFloorChange);
	}

	void Spell_Transform() {
		var om = ObjectManager.Instance;
		var sourceObj = RandomUtils.GetItem(RoomObject.Objects);
		if( sourceObj != null ) {
			var randObj = ObjectManager.Instance.GetPrefabExcept(sourceObj.Type);
			if( randObj ) {
				om.TransformObject(sourceObj.gameObject, randObj);
			}
		}
	}

	void Spell_MassTransform() {
		MultiplySpell(Spell_Transform);
	}

	void Spell_Boom() {
		var x = UnityEngine.Random.Range(-SizeDelta, SizeDelta);
		var y = 0;
		var z = UnityEngine.Random.Range(-SizeDelta, SizeDelta);
		var position = new Vector3(x, y, z);
		var om = ObjectManager.Instance;
		om.CreateObject(om.BoomPrefab, position);
	}

	void Spell_Kaboom() {
		MultiplySpell(Spell_Boom);
	}

	void Spell_RoomShake() {
		var force = Vector3.up * 500;
		var rbs = FindObjectsOfType<Rigidbody>();
		for( int i = 0; i < rbs.Length; i++ ) {
			rbs[i].AddForce(force);
		}
	}

	void Spell_FloorChange() {
		var om = ObjectManager.Instance;
		var sourceObj = RandomUtils.GetItem(FloorItem.Items);
		if( sourceObj != null ) {
			var randObj = ObjectManager.Instance.GetPrefabExcept(sourceObj.Type);
			if( randObj ) {
				om.TransformObject(sourceObj.gameObject, randObj);
			}
		}
	}

	void Spell_MassFloorChange() {
		MultiplySpell(Spell_FloorChange);
	}

	void MultiplySpell(Action action, int count = 5, float interval = 0.25f) {
		var seq = DOTween.Sequence();
		for( int i = 0; i < count; i++) {
			seq.AppendCallback(() => action.Invoke());
			seq.AppendInterval(interval);
		}
	}

	public void ApplySpell() {
		var spell = RandomUtils.GetItem(_spells);
		spell.Callback.Invoke();
	}
}
